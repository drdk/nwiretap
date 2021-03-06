﻿namespace NWiretap.Instruments.Meter
{
    public class MeterMeasurement : InstrumentMeasurementBase
    {
        public float CurrentFrequency { get; private set; }
        public int Ticks { get; private set; }

        public MeterMeasurement(float currentFrequency, int ticks)
        {
            CurrentFrequency = currentFrequency;
            Ticks = ticks;
        }
    }
}
