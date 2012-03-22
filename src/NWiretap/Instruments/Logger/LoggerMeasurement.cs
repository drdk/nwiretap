using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWiretap.Instruments.Logger
{
    public class LoggerMeasurement : InstrumentMeasurementBase 
    {
        public ConcurrentList<LogEntry> Entries { get; private set; }

        public LoggerMeasurement(ConcurrentList<LogEntry> entries)
        {
            Entries = entries;
        }
    }
}
