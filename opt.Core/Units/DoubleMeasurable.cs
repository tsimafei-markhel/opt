using System;

// Omitting unit tests for this class as long as everything is tested by MeasurableBase<Double> test in opt.Domain

namespace opt.Units
{
    // Had to implement IComparable<DoubleMeasurable>, IEquatable<DoubleMeasurable>, these implementations
    // just fall back to the MeasurableBase<Double> implementation
    public class DoubleMeasurable : MeasurableBase<Double>, IComparable<DoubleMeasurable>, IEquatable<DoubleMeasurable>
    {
        public DoubleMeasurable(IUnit unit, Double value) :
            base(unit, value)
        {
        }

        public DoubleMeasurable(Double value) :
            base(value)
        {
        }

        public virtual Boolean Equals(DoubleMeasurable other)
        {
            return Equals(other as IMeasurable<double>);
        }

        public virtual Int32 CompareTo(DoubleMeasurable other)
        {
            return CompareTo(other as IMeasurable<double>);
        }
    }
}