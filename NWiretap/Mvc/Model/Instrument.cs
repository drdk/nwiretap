using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWiretap.Measurement;

namespace NWiretap.Mvc.Model
{
    public class Instrument
    {
        public int InstrumentID { get; set; }
        public string InstrumentIdent { get; set; }
        public InstrumentMeasurementBase Measurement { get; set; }
    }
}
