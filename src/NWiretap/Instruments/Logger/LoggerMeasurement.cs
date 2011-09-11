using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWiretap.Measurement;

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
