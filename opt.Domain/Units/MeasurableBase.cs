using System;

namespace opt.Units
{
    /// <summary>
    /// Class that can be used as a base for entity representing measurable value
    /// (i.e. quantity measured in some units)
    /// </summary>
    /// <typeparam name="TValue">Type used to represent quantity (e.g. <see cref="Double"/>)</typeparam>
    public abstract class MeasurableBase<TValue> : IMeasurable<TValue>
        where TValue : struct, IComparable<TValue>, IEquatable<TValue>
    {
        /// <summary>
        /// Gets unit of measurement
        /// </summary>
        public IUnit Unit { get; private set; }

        /// <summary>
        /// Gets or sets quantity
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="MeasurableBase<TValue>"/> with
        /// unit of measurement and quantity
        /// </summary>
        /// <param name="unit">Unit of measurement for this instance</param>
        /// <param name="value">Quantity</param>
        /// <exception cref="ArgumentNullException">If <paramref name="unit"/> is null</exception>
        protected MeasurableBase(IUnit unit, TValue value)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            Unit = unit;
            Value = value;
        }

        /// <summary>
        /// Initializes new instance of <see cref="MeasurableBase<TValue>"/> with
        /// quantity and <see cref="ArbitraryUnit"/>
        /// </summary>
        /// <param name="value">Quantity</param>
        protected MeasurableBase(TValue value) :
            this(ArbitraryUnit.Instance, value)
        {
        }

        #region IComparable<IMeasurable<TValue>>

        /// <summary>
        /// Compares the current measurable with another measurable of the same type
        /// </summary>
        /// <param name="other">A measurable to compare with this one</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        /// The return value has the following meanings: Value Meaning Less than zero
        /// This object is less than the other parameter.Zero This object is equal to
        /// other. Greater than zero This object is greater than other</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="other"/> is null</exception>
        /// <exception cref="InvalidOperationException">If units of measurement of this measurable
        /// and <paramref name="other"/> measurable do not match</exception>
        public virtual Int32 CompareTo(IMeasurable<TValue> other)
        {
            if (object.ReferenceEquals((object)other, (object)null))
            {
                throw new ArgumentNullException("other");
            }

            if (object.ReferenceEquals((object)other, (object)this))
            {
                return 0;
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

        /// <summary>
        /// Indicates whether the current measurable is equal to another measurable of the same
        /// type
        /// </summary>
        /// <param name="other">A measurable to compare with this one</param>
        /// <returns>True if the current measurable is equal to the <paramref name="other"/>
        /// (i.e. units of measurement are the same and values are equal); otherwise, false</returns>
        public virtual Boolean Equals(IMeasurable<TValue> other)
        {
            if (object.ReferenceEquals((object)other, (object)null))
            {
                return false;
            }

            if (object.ReferenceEquals((object)other, (object)this))
            {
                return true;
            }

            return Unit.Equals(other.Unit) && Value.Equals(other.Value);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Checks whether <paramref name="left"/> and <paramref name="right"/> measurables
        /// are equal
        /// </summary>
        /// <param name="left">A measurable to compare to <paramref name="right"/></param>
        /// <param name="right">A measurable to compare to <paramref name="left"/></param>
        /// <returns>True if the current measurable is equal to the <paramref name="other"/>
        /// (i.e. units of measurement are the same and values are equal); otherwise, false</returns>
        public static Boolean operator ==(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return object.ReferenceEquals((object)right, (object)null);
            }

            return left.Equals((IMeasurable<TValue>)right);
        }

        /// <summary>
        /// Checks whether <paramref name="left"/> and <paramref name="right"/> measurables
        /// are not equal
        /// </summary>
        /// <param name="left">A measurable to compare to <paramref name="right"/></param>
        /// <param name="right">A measurable to compare to <paramref name="left"/></param>
        /// <returns>True if the current measurable is not equal to the <paramref name="other"/>
        /// (i.e. units of measurement are different or values are not equal); otherwise, false</returns>
        public static Boolean operator !=(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null))
            {
                return !object.ReferenceEquals((object)right, (object)null);
            }

            return !left.Equals((IMeasurable<TValue>)right);
        }

        /// <summary>
        /// Checks whether <paramref name="left"/> is less than <paramref name="right"/>
        /// </summary>
        /// <param name="left">A measurable to compare to <paramref name="right"/></param>
        /// <param name="right">A measurable to compare to <paramref name="left"/></param>
        /// <returns>True if <paramref name="left"/> is less than <paramref name="right"/>;
        /// otherwise, false</returns>
        /// <exception cref="InvalidOperationException">If units of measurement of this measurable
        /// and <paramref name="other"/> measurable do not match</exception>
        public static Boolean operator >(MeasurableBase<TValue> left, MeasurableBase<TValue> right)
        {
            if (object.ReferenceEquals((object)left, (object)null) ||
                object.ReferenceEquals((object)right, (object)null))
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Checks whether <paramref name="left"/> is greater than <paramref name="right"/>
        /// </summary>
        /// <param name="left">A measurable to compare to <paramref name="right"/></param>
        /// <param name="right">A measurable to compare to <paramref name="left"/></param>
        /// <returns>True if <paramref name="left"/> is greater than <paramref name="right"/>;
        /// otherwise, false</returns>
        /// <exception cref="InvalidOperationException">If units of measurement of this measurable
        /// and <paramref name="other"/> measurable do not match</exception>
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

        /// <summary>
        /// Determines whether the specified <see cref="Object"/> is equal to the current <see cref="Object"/>
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare with the current <see cref="Object"/></param>
        /// <returns>True if the specified <see cref="Object"/> is equal to the current <see cref="Object"/>;
        ///     otherwise, false</returns>
        public override Boolean Equals(object obj)
        {
            return Equals(obj as IMeasurable<TValue>);
        }

        /// <summary>
        /// Serves as a hash function for <see cref="MeasurableBase<TValue>"/>
        /// </summary>
        /// <returns>A hash code for the current <see cref="MeasurableBase<TValue>"/></returns>
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

        #region Explicit cast to TValue

        /// <summary>
        /// Converts <see cref="MeasurableBase<TValue>"/> to <typeparamref name="TValue"/>
        /// </summary>
        /// <param name="measurable"><see cref="MeasurableBase<TValue>"/> to be converted
        /// to <typeparamref name="TValue"/></param>
        /// <returns><typeparamref name="TValue"/></returns>
        public static explicit operator TValue(MeasurableBase<TValue> measurable)
        {
            if (measurable == null)
            {
                throw new InvalidCastException();
            }

            return measurable.Value;
        }

        /// <summary>
        /// Converts current <see cref="MeasurableBase<TValue>"/> to <typeparamref name="TValue"/>
        /// </summary>
        /// <returns><typeparamref name="TValue"/></returns>
        public virtual TValue ToValueType()
        {
            return (TValue)this;
        }

        #endregion
    }
}