using System;
using System.Collections.Generic;

// TODO: Reuse this across solution instead of SortableDouble

namespace opt.DataModel.New
{
    /// <summary>
    /// Helper data structure to use when sorting different <see cref="Real"/>-valued entities
    /// </summary>
    /// <remarks>Immutable</remarks>
    public struct SortableReal : IComparable, IComparable<SortableReal>
    {
        /// <summary>
        /// Gets entity identifier
        /// </summary>
        public TId Id { get; private set; }

        /// <summary>
        /// Gets entity value
        /// </summary>
        public Real Value { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="SortableReal"/>
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="value">Entity value</param>
        public SortableReal(TId id, Real value)
            : this()
        {
            // Call to the default ctor of this is required
            // http://stackoverflow.com/questions/7670780/automatically-implemented-property-in-struct-can-not-be-assigned

            Id = id;
            Value = value;
        }

        /// <summary>
        /// Initializes new instance of <see cref="SortableReal"/> with
        /// identifier and value taken from <paramref name="pair"/>
        /// </summary>
        /// <param name="pair">A pair of entity identifier and value</param>
        /// <returns>New instance of <see cref="SortableReal"/></returns>
        public static SortableReal Create(KeyValuePair<TId, Real> pair)
        {
            return new SortableReal(pair.Key, pair.Value);
        }

        #region IComparable

        /// <summary>
        /// Compares the current <see cref="SortableReal"/> instance with another instance of the same type
        /// </summary>
        /// <param name="obj">An object referencing <see cref="SortableReal"/> instance to compare 
        /// with this instance</param>
        /// <returns>A value that indicates the relative order of the objects being compared. 
        /// The return value has the following meanings: Less than zero - 
        /// this object is less than the other parameter. Zero - This object is equal to 
        /// other. Greater than zero - This object is greater than other</returns>
        public Int32 CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is SortableReal))
            {
                // Message in the exception below has to stay
                throw new ArgumentException("Parameter type must be " + this.GetType().Name, "obj");
            }

            SortableReal sr = (SortableReal)obj;
            if (this == sr)
            {
                return 0;
            }

            if (this < sr)
            {
                return -1;
            }

            // this > sr
            return 1;
        }

        #endregion

        #region IComparable<SortableReal>

        /// <summary>
        /// Compares the current <see cref="SortableReal"/> instance with another instance of the same type
        /// </summary>
        /// <param name="other">A <see cref="SortableReal"/> instance to compare with this instance</param>
        /// <returns>A value that indicates the relative order of the objects being compared. 
        /// The return value has the following meanings: Less than zero - 
        /// this object is less than the other parameter. Zero - This object is equal to 
        /// other. Greater than zero - This object is greater than other</returns>
        public Int32 CompareTo(SortableReal other)
        {
            if (this == other)
            {
                return 0;
            }

            if (this < other)
            {
                return -1;
            }

            // this > other
            return 1;
        }

        #endregion

        #region ValueType overrides

        /// <summary>
        /// Determines whether the specified <see cref="SortableReal"/> is equal to the current one
        /// </summary>
        /// <param name="obj">The <see cref="SortableReal"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="SortableReal"/> is equal to the current one;
        /// otherwise, False</returns>
        public override Boolean Equals(Object obj)
        {
            if (!(obj is SortableReal))
            {
                return false;
            }

            SortableReal r = (SortableReal)obj;
            return r == this;
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="SortableReal"/></returns>
        public override Int32 GetHashCode()
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked
            {
                Int32 hash = 17;
                hash = hash * 29 + Value.GetHashCode();
                hash = hash * 29 + Id.GetHashCode();

                return hash;
            }
        }

        #endregion

        #region Operator overrides

        /// <summary>
        /// Determines whether values of two instances of <see cref="SortableReal"/> are equal
        /// </summary>
        /// <param name="left">First instance of <see cref="SortableReal"/></param>
        /// <param name="right">Second instance of <see cref="SortableReal"/></param>
        /// <returns>True if <paramref name="left"/> value is equal to the <paramref name="right"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator ==(SortableReal left, SortableReal right)
        {
            // Only compare values because only values matter for sorting
            return left.Value == right.Value;
        }

        /// <summary>
        /// Determines whether values of two instances of <see cref="SortableReal"/> are not equal
        /// </summary>
        /// <param name="left">First instance of <see cref="SortableReal"/></param>
        /// <param name="right">Second instance of <see cref="SortableReal"/></param>
        /// <returns>True if <paramref name="left"/> value is not equal to the <paramref name="right"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator !=(SortableReal left, SortableReal right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether value of <paramref name="left"/> is less than value of 
        /// <paramref name="right"/>
        /// </summary>
        /// <param name="left">First instance of <see cref="SortableReal"/></param>
        /// <param name="right">Second instance of <see cref="SortableReal"/></param>
        /// <returns>True if <paramref name="left"/> is less than value of 
        /// <paramref name="right"/>; otherwise, False</returns>
        public static Boolean operator <(SortableReal left, SortableReal right)
        {
            return left.Value < right.Value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="left"/> is greater than value of 
        /// <paramref name="right"/>
        /// </summary>
        /// <param name="left">First instance of <see cref="SortableReal"/></param>
        /// <param name="right">Second instance of <see cref="SortableReal"/></param>
        /// <returns>True if <paramref name="left"/> is greater than value of 
        /// <paramref name="right"/>; otherwise, False</returns>
        public static Boolean operator >(SortableReal left, SortableReal right)
        {
            return left.Value > right.Value;
        }

        #endregion
    }
}