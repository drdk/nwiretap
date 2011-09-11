using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Measurement
{
    public abstract class InstrumentBase : IInstrument
    {
        private readonly string _instrumentIdent;

        protected InstrumentBase(string instrumentName)
        {
            _instrumentIdent = instrumentName;
        }

        public string InstrumentIdent
        {
            get { return _instrumentIdent; }
        }

        public abstract string InstrumentType { get; }

        public abstract InstrumentMeasurementBase GetMeasurement();
    }
}
