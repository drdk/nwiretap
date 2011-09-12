using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWiretap.Instruments.Meter;

namespace NWiretap.Instruments.Timer
{
    public class TimerMeasurement : MeterMeasurement
    {
        public IEnumerable<TimerSample> Samples { get; private set; }

        public TimerMeasurement(MeterMeasurement meterMeasurement, IEnumerable<TimerSample> samples) : base(meterMeasurement.CurrentFrequency, meterMeasurement.Ticks)
        {
            Samples = samples;
        }
    }
}
