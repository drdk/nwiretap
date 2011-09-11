$().ready(function () {
    var servers = [
        {
            name: "Server 1",
            url: "/nwiretap"
        },
        {
            name: "Server 2",
            url: "/nwiretap"
        },
        {
            name: "Server 3",
            url: "/nwiretap"
        },
        {
            name: "Server 4",
            url: "/nwiretap"
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
                    data: data
                });

                setTimeout(function () {
                    var ds = getData(servers);
                    updateData(ds);
                }, 3000);
            }
        });
    });

    return dataSets;
}

function initialize(dataSets) {
    $.each(dataSets, function (index, value) {
        $("#template-server").tmpl(value).appendTo("#main-content");
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
    var graph = $(instrumentDomId + " .graph")[0];
    if (!graph.isInitialized) {
        
    }
    else {
        //Update the data
    }
}