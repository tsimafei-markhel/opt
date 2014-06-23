using System;

// Omitting unit tests for this class as long as everything is tested by MeasurableBase<Double> test in opt.Domain

namespace opt.Units
{
    public class DoubleMeasurable : MeasurableBase<Double>
    {
        public DoubleMeasurable(IUnit unit, Double value) :
            base(unit, value)
        {
        }

        public DoubleMeasurable(Double value) :
            base(value)
        {
        }
    }
}