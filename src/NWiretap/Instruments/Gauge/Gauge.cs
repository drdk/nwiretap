using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Instruments.Gauge
{
    public class Gauge : InstrumentBase, IGauge
    {
        private readonly Func<object> _gaugeCallout;
        public Gauge(Type owningType, string instrumentGroup, string instrumentName, Func<object> gaugeCallout) : base(owningType, instrumentGroup, instrumentName)
        {
            _gaugeCallout = gaugeCallout;
        }

        public override string InstrumentType
        {
            get { return "Gauge"; }
        }

        public override InstrumentMeasurementBase GetMeasurement()
        {
            return new GaugeMeasurement
                       {
                           Gauge = _gaugeCallout()
                       };
        }
    }
}