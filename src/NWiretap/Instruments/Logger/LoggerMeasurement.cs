using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Instruments.Logger
{
    public class LoggerMeasurement : InstrumentMeasurementBase 
    {
        public List<LogEntry> Entries { get; private set; }

        public LoggerMeasurement(List<LogEntry> entries)
        {
            Entries = entries;
        }
    }
}
