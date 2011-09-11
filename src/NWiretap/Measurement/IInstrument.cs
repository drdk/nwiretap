using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Measurement
{
    public interface IInstrument
    {
        string InstrumentIdent { get; }
        string InstrumentType { get; }
        InstrumentMeasurementBase GetMeasurement();
    }
}
