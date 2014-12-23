using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents model entity identifier
    /// </summary>
    /// <remarks>Immutable</remarks>
    [Serializable]
    public struct TId : IEquatable<TId>, IComparable, IComparable<TId>
    {
        /// <summary>
        /// Id value storage
        /// </summary>
        private readonly Int32 value;

        /// <summary>
        /// Initializes new instance of <see cref="TId"/> structure with value of <paramref name="idValue"/>
        /// </summary>
        /// <param name="idValue">Id value to use for initialization</param>
        public TId(Int32 idValue)
        {
            value = idValue;
        }

        /// <summary>
        /// Initializes new instance of <see cref="TId"/> structure with value of <paramref name="anotherId"/>
        /// </summary>
        /// <param name="anotherId"><see cref="TId"/> instance to copy value from</param>
        public TId(TId anotherId)
        {
            value = anotherId.value;
        }

        /// <summary>
        /// Creates new instance of <see cref="TId"/> and initializes it with <paramref name="value"/>
        /// </summary>
        /// <param name="value">String representation of Id to parse</param>
        /// <returns>New instance of <see cref="TId"/> with <paramref name="value"/> value</returns>
        public static TId Parse(String value)
        {
            // Using invariant culture here because ID type has to be culture-independent
            return new TId(Int32.Parse(value, CultureInfo.InvariantCulture));
        }

        #region IEquatable<TId>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>True if the current object is equal to the other parameter; otherwise, False</returns>
        public Boolean Equals(TId other)
        {
            return this == other;
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares this instance to a specified <see cref="TId"/> object and returns an
        /// integer that indicates their relationship to one another
        /// </summary>
        /// <param name="obj">A <see cref="TId"/> object to compare to this instance</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        /// The return value has these meanings: Value Meaning Less than zero This instance
        /// precedes object in the sort order. Zero This instance occurs in the same position
        /// in the sort order as obj. Greater than zero This instance follows object in
        /// the sort order</returns>
        public Int32 CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is TId))
            {
                // Message in the exception below has to stay
                throw new ArgumentException("Parameter type must be " + this.GetType().Name, "obj");
            }

            int val = (int)obj;
            if (this < val)
            {
                return -1;
            }

            return this > val ? 1 : 0;
        }

        #endregion

        #region IComparable<TId>

        /// <summary>
        /// Compares this instance to a specified <see cref="TId"/> object and returns an
        /// integer that indicates their relationship to one another
        /// </summary>
        /// <param name="other">A <see cref="TId"/> object to compare to this instance</param>
        /// <returns>A value that indicates the relative order of the objects being compared.
        /// The return value has these meanings: Value Meaning Less than zero This instance
        /// precedes object in the sort order. Zero This instance occurs in the same position
        /// in the sort order as obj. Greater than zero This instance follows object in
        /// the sort order</returns>
        public Int32 CompareTo(TId other)
        {
            if (this < other)
            {
                return -1;
            }

            return this > other ? 1 : 0;
        }

        #endregion

        #region ValueType overrides

        /// <summary>
        /// Determines whether the specified <see cref="TId"/> is equal to the current one
        /// </summary>
        /// <param name="obj">The <see cref="TId"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="TId"/> is equal to the current one;
        /// otherwise, False</returns>
        public override Boolean Equals(Object obj)
        {
            if (!(obj is TId))
            {
                return false;
            }
            else
            {
                return this == (TId)obj;
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="TId"/></returns>
        public override Int32 GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="TId"/> instance
        /// </summary>
        /// <returns>A string that represents the current <see cref="TId"/> instance</returns>
        public override String ToString()
        {
            // Using invariant culture here because ID type has to be culture-independent
            return value.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

        #region Comparison operators

        /// <summary>
        /// Determines whether values of two instances of <see cref="TId"/> are equal
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> value is equal to the <paramref name="id2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator ==(TId id1, TId id2)
        {
            return id1.value == id2.value;
        }

        /// <summary>
        /// Determines whether values of two instances of <see cref="TId"/> are not equal
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> value is not equal to the <paramref name="id2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator !=(TId id1, TId id2)
        {
            return !(id1 == id2);
        }

        /// <summary>
        /// Determines whether value of <paramref name="id1"/> is less than value of 
        /// <paramref name="id2"/>
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> is less than value of 
        /// <paramref name="id2"/>; otherwise, False</returns>
        public static Boolean operator <(TId id1, TId id2)
        {
            return id1.value < id2.value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="id1"/> is less or equal than value of 
        /// <paramref name="id2"/>
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> is less or equal than value of 
        /// <paramref name="id2"/>; otherwise, False</returns>
        public static Boolean operator <=(TId id1, TId id2)
        {
            return id1.value <= id2.value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="id1"/> is greater than value of 
        /// <paramref name="id2"/>
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> is greater than value of 
        /// <paramref name="id2"/>; otherwise, False</returns>
        public static Boolean operator >(TId id1, TId id2)
        {
            return id1.value > id2.value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="id1"/> is greater or equal than value of 
        /// <paramref name="id2"/>
        /// </summary>
        /// <param name="id1">First instance of <see cref="TId"/></param>
        /// <param name="id2">Second instance of <see cref="TId"/></param>
        /// <returns>True if <paramref name="id1"/> is greater or equal than value of 
        /// <paramref name="id2"/>; otherwise, False</returns>
        public static Boolean operator >=(TId id1, TId id2)
        {
            return id1.value >= id2.value;
        }

        #endregion

        #region T(x) operators

        /// <summary>
        /// Implicitly converts <see cref="Int32"/> value to <see cref="TId"/>
        /// </summary>
        /// <param name="idValue"><see cref="Int32"/> value to convert</param>
        /// <returns>New instance of <see cref="TId"/></returns>
        public static implicit operator TId(Int32 idValue)
        {
            return new TId(idValue);
        }

        /// <summary>
        /// Implicitly converts <see cref="TId"/> to <see cref="Int32"/> value
        /// </summary>
        /// <param name="instance"><see cref="TId"/> to convert</param>
        /// <returns><see cref="Int32"/> value</returns>
        public static implicit operator Int32(TId instance)
        {
            return instance.value;
        }

        /// <summary>
        /// Implicitly converts <see cref="TId"/> to <see cref="String"/> value
        /// </summary>
        /// <param name="instance"><see cref="TId"/> to convert</param>
        /// <returns><see cref="String"/> value</returns>
        public static implicit operator String(TId instance)
        {
            return instance.ToString();
        }

        #endregion
    }
}