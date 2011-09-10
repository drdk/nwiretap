using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using NWiretap.Measurement;

namespace NWiretap.Instumentation
{
    public class Counter : IInstrument, ICounter, IFrequencyInstrument, ISummableInstrument, IDisposable
    {
        public static ICounter Create(string counterName, int sampleLengthMs)
        {
            var counter = new Counter(counterName, sampleLengthMs);
            InstrumentTracker.TrackInstrument(counter);

            return counter;
        }

        public string CounterName { get; private set; }
        public int SampleLengthMs { get; private set; }
        
        private int _ticks;
        public int Ticks { get { return _ticks; } }

        private int _lastTicks;
        private readonly Timer _sampleTimer;
        private float _currentFrequency;

        protected Counter(string counterName, int sampleLengthMs)
        {
            CounterName = counterName;
            SampleLengthMs = sampleLengthMs;

            _sampleTimer = new Timer(state => CalculateFrequency(), null, SampleLengthMs, SampleLengthMs);
        }

        private void CalculateFrequency()
        {
            var ticksDelta = Ticks - _lastTicks;
            _lastTicks = Ticks;

            _currentFrequency = (ticksDelta*1000) / (SampleLengthMs*1f);
        }

        public void Increment()
        {
            Interlocked.Increment(ref _ticks);
        }

        public float GetCurrentFrequency()
        {
            return _currentFrequency;
        }

        public int GetCurrentSum()
        {
            return Ticks;
        }

        public string InstrumentName
        {
            get { return CounterName; }
        }

        public string InstrumentVisualizer
        {
            get { return "NWiretapCounter"; }
        }

        public void Dispose()
        {
            _sampleTimer.Dispose();
            InstrumentTracker.RemoveInstrument(this);
        }
    }
}