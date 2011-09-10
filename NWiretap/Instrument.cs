using NWiretap.Instruments.Ticker;
using NWiretap.Instruments.Timer;

namespace NWiretap
{
    public static class Instrument
    {
        public static IMeter Ticker(string counterName, int sampleLengthMs)
        {
            var ticker = new Meter(counterName, sampleLengthMs);
            InstrumentTracker.TrackInstrument(ticker);

            return ticker;
        }

        public static IInvocationTimer Timer(string timerName, int sampleLengthMs)
        {
            var timer = new InvocationTimer(timerName, sampleLengthMs);
            InstrumentTracker.TrackInstrument(timer);

            return timer;
        }
    }
}
