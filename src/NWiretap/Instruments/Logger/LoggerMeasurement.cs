using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Instruments.Logger
{
    public class LoggerMeasurement : InstrumentMeasurementBase 
    {
        public IList<LogEntry> Entries { get; private set; }

        public LoggerMeasurement(IList<LogEntry> entries)
        {
            Entries = entries;
        }
    }
}
