using System;
using System.Threading;

namespace NWiretap.Instruments.Meter
{
    public class Meter : InstrumentBase, IMeter, IDisposable
    {
        public string CounterName { get; private set; }
        public int SampleLengthMs { get; private set; }

        private int _ticks;
        public int Ticks { get { return _ticks; } }

        private int _lastTicks;
        private readonly System.Threading.Timer _sampleTimer;
        private float _currentFrequency;

        public Meter(Type owningType, string groupName, string counterName, int sampleLengthMs) : base(owningType, groupName, counterName)
        {
            CounterName = counterName;
            SampleLengthMs = sampleLengthMs;

            _sampleTimer = new System.Threading.Timer(state => CalculateValues(), null, SampleLengthMs, SampleLengthMs);
        }

        protected virtual void CalculateValues()
        {
            var ticksDelta = Ticks - _lastTicks;
            _lastTicks = Ticks;

            _currentFrequency = (ticksDelta*1000) / (SampleLengthMs*1f);
        }

        public void Tick()
        {
            Interlocked.Increment(ref _ticks);
        }

        public override string InstrumentType
        {
            get { return "Meter"; }
        }

        public override InstrumentMeasurementBase GetMeasurement()
        {
            return new MeterMeasurement(_currentFrequency, _ticks);
        }

        public void Dispose()
        {
            _sampleTimer.Dispose();
            InstrumentTracker.RemoveInstrument(this);
        }
    }
}