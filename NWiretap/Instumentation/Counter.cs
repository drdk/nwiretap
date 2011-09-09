using System;
using System.Collections.Generic;
using System.Threading;
using NWiretap.Measurement;

namespace NWiretap.Instumentation
{
    public class Counter : IInstrument, IFrequencyInstrument, ISummableInstrument, IDisposable
    {
        private static readonly IDictionary<string, Counter> Counters = new Dictionary<string, Counter>();
        
        public string CounterName { get; private set; }
        private int _ticks;
        public int Ticks { get { return _ticks; } }

        public int SampleLengthMs { get; private set; }
        private int _lastTicks;
        private readonly Timer _sampleTimer;

        private float _currentFrequency;

        protected Counter(string counterName, int sampleLengthMs)
        {
            CounterName = counterName;
            SampleLengthMs = sampleLengthMs;

            _sampleTimer = new Timer(state => CalculateFrequency(), null, SampleLengthMs, SampleLengthMs);
        }

        public static Counter Create(string counterName, int sampleLengthMs)
        {
            Counter counter;
            if(!Counters.TryGetValue(counterName, out counter))
            {
                counter = new Counter(counterName, sampleLengthMs);
                Counters.Add(counterName, counter);
            }

            return counter;
        }

        private void CalculateFrequency()
        {
            var ticksDelta = Ticks - _lastTicks;
            _lastTicks = Ticks;

            _currentFrequency = (ticksDelta*1000) / (SampleLengthMs*1f);
        }

        public void Count()
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

        public IEnumerable<IInstrument> GetInstruments()
        {
            return Counters.Values;
        }

        public string InstrumentName
        {
            get { return CounterName; }
        }

        public void Dispose()
        {
            _sampleTimer.Dispose();
        }
    }
}