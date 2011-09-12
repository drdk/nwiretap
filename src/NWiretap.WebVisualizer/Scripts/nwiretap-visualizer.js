$().ready(function () {
    var servers = [
        {
            name: "VALGOL 10",
            url: "http://172.18.64.120/nyheder/valgol/nwiretap"
        },
        {
            name: "VALGOL 11",
            url: "http://172.18.64.121/nyheder/valgol/nwiretap"
        }
        ,
        {
            name: "VALGOL 12",
            url: "http://172.18.64.122/nyheder/valgol/nwiretap"
        }
        ,
        {
            name: "VALGOL 13",
            url: "http://172.18.64.123/nyheder/valgol/nwiretap"
        }
    ];

    var dataSets = getData(servers);

    initialize(dataSets);
    updateData(dataSets);
});

function getData(servers) {
    var dataSets = [];

    $.each(servers, function (index, value) {
        $.ajax({
            url: value.url,
            async: false,
            success: function (data) {
                dataSets.push({
                    name: value.name,
                    serverIndex: index,
                    data: eval(data)
                });
            }
        });
    });

    setTimeout(function () {
        var ds = getData(servers);
        updateData(ds);
    }, 3000);
    
    return dataSets;
}

function initialize(dataSets) {
    $.each(dataSets, function (index, val) {
        $("#template-server").tmpl(val).appendTo("#main-content");
    });
}

function updateData(dataSets) {
    $.each(dataSets, function (serverIndex, dataSet) {
        $.each(dataSet.data, function (instrumentIndex, data) {
            var instrument = "#instrument-" + dataSet.serverIndex + "-" + instrumentIndex;
            var container = $(instrument);
            if (data.InstrumentType == "Meter") {
                updateMeter(instrument, data);
            }
            else if (data.InstrumentType == "InvocationTimer") {
                updateInvocationTimer(instrument, data);
            }
        });
    });
}

function updateMeter(instrumentDomId, data) {
    var ticks = $(instrumentDomId + " .ticks")[0];
    var frequency = $(instrumentDomId + " .frequency")[0];
    $(ticks).html(data.Measurement.Ticks);
    $(frequency).html(data.Measurement.CurrentFrequency);
}

function updateInvocationTimer(instrumentDomId, data) {
    updateMeter(instrumentDomId, data);

    //Update dat graph.
    var graphDom = $(instrumentDomId + " .graph")[0];
    $(graphDom).empty();
    var r = new Raphael(graphDom);
    
    var yPlots = [];
    var xPlots = [];

    $.each(data.Measurement.Samples, function (index, sample) {
        yPlots.push(sample.AverageInvokationTimeMs);
        xPlots.push(index);
    });

    r.g.linechart(20, 0, 230, 75, xPlots, yPlots, { axis: "0 0 1 1", smooth: true, shade: true });
}