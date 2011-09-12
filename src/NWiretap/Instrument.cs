using System;
using NWiretap.Instruments.Gauge;
using NWiretap.Instruments.Logger;
using NWiretap.Instruments.Meter;
using NWiretap.Instruments.Timer;

namespace NWiretap
{
    public static class Instrument
    {
        public static IMeter Meter(Type owningType, string groupName, string name, int sampleLengthMs)
        {
            var ticker = new Meter(owningType, groupName, name, sampleLengthMs);
            InstrumentTracker.TrackInstrument(ticker);

            return ticker;
        }

        public static IInvocationTimer Timer(Type owningType, string groupName, string name, int sampleLengthMs)
        {
            var timer = new InvocationTimer(owningType, groupName, name, sampleLengthMs);
            InstrumentTracker.TrackInstrument(timer);

            return timer;
        }

        public static ILogger Logger(Type owningType, string groupName, string name, int logSize)
        {
            var logger = new Logger(owningType, groupName, name, logSize);
            InstrumentTracker.TrackInstrument(logger);

            return logger;
        }

        public static IGauge Gauge(Type owningType, string groupName, string name, Func<object> gaugeCallout)
        {
            var gauge = new Gauge(owningType, groupName, name, gaugeCallout);
            InstrumentTracker.TrackInstrument(gauge);

            return gauge;
        }
    }
}
