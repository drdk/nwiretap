using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Measurement
{
    public interface IInstrument
    {
        IEnumerable<IInstrument> GetInstruments();
        string InstrumentName { get; }
    }
}
