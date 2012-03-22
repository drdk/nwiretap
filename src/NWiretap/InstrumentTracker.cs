using System.Collections.Generic;
using System.Linq;
using NWiretap.Instruments;

namespace NWiretap
{
    internal static class InstrumentTracker
    {
        public static IList<TrackedInstrument> Instruments = new ConcurrentList<TrackedInstrument>();

        public static void TrackInstrument(IInstrument instrument)
        {
            Instruments.Add(new TrackedInstrument(instrument));
        }

        public static void RemoveInstrument(IInstrument instrument)
        {
            var trackedInstrument = Instruments.Single(a => a.Instrument == instrument);
            Instruments.Remove(trackedInstrument);
        }
    }

    internal class TrackedInstrument
    {
        private static int _instrumentId;

        public IInstrument Instrument { get; private set; }
        public int InstrumentID { get; private set; }

        public TrackedInstrument(IInstrument instrument)
        {
            Instrument = instrument;
            InstrumentID = _instrumentId++;
        }
    }
}
