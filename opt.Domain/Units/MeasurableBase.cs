using System;

// TODO: Add unit tests
// TODO: Add Equals(MeasurableBase<TValue>, IUnitConverter<TValue>) method?
// TODO: Add CompareTo(MeasurableBase<TValue>, IUnitConverter<TValue>) method?
// TODO: Add implicit or explicit cast operator MeasurableBase<TValue> ---> TValue?

namespace opt.Units
{
    public abstract class MeasurableBase<TValue> : IMeasurable<TValue>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        public IUnit Unit { get; private set; }

        public TValue Value { get; set; }

        protected MeasurableBase(IUnit unit, TValue value)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            Unit = unit;
            Value = value;
        }

        protected MeasurableBase(TValue value) :
            this(ArbitraryUnit.Instance, value)
        {
        }

        protected MeasurableBase(IUnit unit) :
            this(unit, default(TValue))
        {
        }

        protected MeasurableBase() :
            this(ArbitraryUnit.Instance, default(TValue))
        {
        }

        #region IComparable<IMeasurable<TValue>>

        public Int32 CompareTo(IMeasurable<TValue> other)
        {
            if (object.ReferenceEquals((object)other, (object)null))
            {
                throw new ArgumentNullException("other");
            }

            if (!Unit.Equals(other.Unit))
            {
                // Cannot compare two values measured in different units
                throw new InvalidOperationException();
            }

            return Value.CompareTo(other.Value);
        }

        #endregion

        #region IEquatable<IMeasurable<TValue>>

        public Boolean Equals(IMeasurable<TValue> other)
        {
            if (object.ReferenceEquals((object)other, (object)null))
            {
                return false;
            }

            return Unit.Equals(other.Unit) && Value.Equals(other.Value);
        }

        #endregion

        #region Operators

        public static Boolean operator ==(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return object.ReferenceEquals((object)right, (object)null);
            }

            return left.Equals((IMeasurable<TValue>)right);
        }

        public static Boolean operator !=(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return !object.ReferenceEquals((object)right, (object)null);
            }

            return !left.Equals((IMeasurable<TValue>)right);
        }

        public static Boolean operator >(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        public static Boolean operator <(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) < 0;
        }

        #endregion

        #region Object overrides

        public override Boolean Equals(object obj)
        {
            return Equals(obj as IMeasurable<TValue>);
        }

        public override Int32 GetHashCode()
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked
            {
                Int32 hash = 17;
                hash = hash * 29 + Unit.GetHashCode();
                hash = hash * 29 + Value.GetHashCode();

                return hash;
            }
        }

        #endregion
    }
}