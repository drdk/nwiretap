using System;

namespace NWiretap.Instruments
{
    public interface IInstrument
    {
        Type OwningType { get; }
        string InstrumentGroup { get; }
        string InstrumentIdent { get; }
        string InstrumentType { get; }
        InstrumentMeasurementBase GetMeasurement();
    }
}
