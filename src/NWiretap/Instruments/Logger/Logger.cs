﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NWiretap.Measurement;

namespace NWiretap.Instruments.Logger
{
    public class Logger : InstrumentBase, ILogger
    {
        public int LogSize { get; private set; }
        private readonly List<LogEntry> _entries = new List<LogEntry>();

        public Logger(string instrumentName, int logSize) : base(instrumentName)
        {
            LogSize = logSize;
        }

        public override string InstrumentType
        {
            get { return "Logger"; }
        }

        public override InstrumentMeasurementBase GetMeasurement()
        {
            return new LoggerMeasurement(_entries);
        }

        public void Log(string message)
        {
            if(_entries.Count >= LogSize)
            {
                _entries.RemoveAt(_entries.Count-1);
            }

            _entries.Insert(0, new LogEntry(message));
        }
    }

    public class LogEntry
    {
        private DateTime _created = DateTime.Now;
        public string Created
        {
            get { return _created.ToString("o"); }
        }

        public string Line;

        public LogEntry(string line)
        {
            Line = line;
        }
    }
}