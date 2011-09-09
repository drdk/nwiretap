using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Measurement
{
    public static class InstrumentTracker
    {
        public static IList<IInstrument> Instruments = new List<IInstrument>();

        public static void TrackInstrument(IInstrument instrument)
        {
            Instruments.Add(instrument);
        }

        public static void RemoveInstrument(IInstrument instrument)
        {
            Instruments.Remove(instrument);
        }
    }
}
