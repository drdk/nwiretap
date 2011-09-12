using System;
using NWiretap.Instruments.Logger;
using NWiretap.Instruments.Meter;
using NWiretap.Instruments.Timer;

namespace NWiretap
{
    public static class Instrument
    {
        public static IMeter Meter(Type owningType, string groupName, string counterName, int sampleLengthMs)
        {
            var ticker = new Meter(owningType, groupName, counterName, sampleLengthMs);
            InstrumentTracker.TrackInstrument(ticker);

            return ticker;
        }

        public static IInvocationTimer Timer(Type owningType, string groupName, string timerName, int sampleLengthMs)
        {
            var timer = new InvocationTimer(owningType, groupName, timerName, sampleLengthMs);
            InstrumentTracker.TrackInstrument(timer);

            return timer;
        }

        public static ILogger Logger(Type owningType, string groupName, string loggerName, int logSize)
        {
            var logger = new Logger(owningType, groupName, loggerName, logSize);
            InstrumentTracker.TrackInstrument(logger);

            return logger;
        }
    }
}
