using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWiretap.Instruments;

namespace NWiretap.Mvc.Model
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string InstrumentIdent { get; set; }
        public string InstrumentType { get; set; }
        public string ImplementorType { get; set; }
        public string InstrumentGroup { get; set; }
        public InstrumentMeasurementBase Measurement { get; set; }
    }
}
