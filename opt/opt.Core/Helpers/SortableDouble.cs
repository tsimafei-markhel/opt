using System;
using System.Diagnostics.CodeAnalysis;
using opt.DataModel;

// TODO: Reuse opt.DataModel.New.SortableReal across solution instead of this

namespace opt.Helpers
{
    /// <summary>
    /// Helper data storage class to use when sorting different <see cref="Double"/>-valued entities
    /// </summary>
    /// <remarks>Class, not a structure, because instances are expected to be copied a lot</remarks>
    public sealed class SortableDouble : IComparable<SortableDouble>
    {
        /// <summary>
        /// Gets or sets direction of sorting
        /// </summary>
        public SortDirection Direction { get; set; }

        /// <summary>
        /// Gets or sets entity ID
        /// </summary>
        public TId Id { get; set; }

        /// <summary>
        /// Gets or sets entity value
        /// </summary>
        public Double Value { get; set; }

        #region IComparable<SortableDouble>

        /// <summary>
        /// Compares the current <see cref="SortableDouble"/> instance with another instance of the same type 
        /// with regard to <see cref="SortableDouble.Direction"/>
        /// </summary>
        /// <param name="other">A <see cref="SortableDouble"/> instance to compare with this instance</param>
        /// <returns>A value that indicates the relative order of the objects being compared. 
        /// The return value has the following meanings: Less than zero - 
        /// this object is less than the other parameter. Zero - This object is equal to 
        /// other. Greater than zero - This object is greater than other</returns>
        public Int32 CompareTo(SortableDouble other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this == other)
            {
                return 0;
            }

            switch (Direction)
            {
                case SortDirection.Ascending:
                    return Value.CompareTo(other.Value);

                case SortDirection.Descending:
                    return -Value.CompareTo(other.Value);
            }

            return 0;
        }

        #endregion

        #region Object overrides

        /// <summary>
        /// Determines whether the specified <see cref="SortableDouble"/> is equal to the current one
        /// </summary>
        /// <param name="obj">The <see cref="SortableDouble"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="SortableDouble"/> is equal to the current one;
        /// otherwise, False</returns>
        public override Boolean Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            SortableDouble sdObj = obj as SortableDouble;
            if (sdObj == null)
            {
                return false;
            }
            else
            {
                return this == sdObj;
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="SortableDouble"/></returns>
        public override Int32 GetHashCode()
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked
            {
                Int32 hash = 17;
                hash = hash * 29 + Value.GetHashCode();
                hash = hash * 29 + Direction.GetHashCode();
                hash = hash * 29 + Id.GetHashCode();

                return hash;
            }
        }

        #endregion

        #region Comparison operators

        /// <summary>
        /// Determines whether values of two instances of <see cref="SortableDouble"/> are equal
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> value is equal to the <paramref name="value2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator ==(SortableDouble value1, SortableDouble value2)
        {
            if (Object.ReferenceEquals(value1, value2))
            {
                return true;
            }

            if (((Object)value1 == null) ||
                ((Object)value2 == null))
            {
                return false;
            }

            // The below clause will be changed once Double is replaced with Real
            if (Math.Abs(value1.Value - value2.Value) < Double.Epsilon)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether values of two instances of <see cref="SortableDouble"/> are not equal
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> value is not equal to the <paramref name="value2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator !=(SortableDouble value1, SortableDouble value2)
        {
            return !(value1 == value2);
        }

        /// <summary>
        /// Determines whether value of <paramref name="value1"/> is less than value of 
        /// <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> is less than value of 
        /// <paramref name="value2"/>; otherwise, False</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Validation is done in operator==")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "Validation is done in operator==")]
        public static Boolean operator <(SortableDouble value1, SortableDouble value2)
        {
            // The below clause will be removed once Double is replaced with Real
            if (value1 == value2)
            {
                return false;
            }

            return value1.Value < value2.Value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="value1"/> is less or equal than value of 
        /// <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> is less or equal than value of 
        /// <paramref name="value2"/>; otherwise, False</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Validation is done in operator==")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "Validation is done in operator==")]
        public static Boolean operator <=(SortableDouble value1, SortableDouble value2)
        {
            // The below clause will be removed once Double is replaced with Real
            if (value1 == value2)
            {
                return true;
            }

            return value1.Value <= value2.Value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="value1"/> is greater than value of 
        /// <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> is greater than value of 
        /// <paramref name="value2"/>; otherwise, False</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Validation is done in operator==")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "Validation is done in operator==")]
        public static Boolean operator >(SortableDouble value1, SortableDouble value2)
        {
            // The below clause will be removed once Double is replaced with Real
            if (value1 == value2)
            {
                return false;
            }

            return value1.Value > value2.Value;
        }

        /// <summary>
        /// Determines whether value of <paramref name="value1"/> is greater or equal than value of 
        /// <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">First instance of <see cref="SortableDouble"/></param>
        /// <param name="value2">Second instance of <see cref="SortableDouble"/></param>
        /// <returns>True if <paramref name="value1"/> is greater or equal than value of 
        /// <paramref name="value2"/>; otherwise, False</returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Validation is done in operator==")]
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
            Justification = "Validation is done in operator==")]
        public static Boolean operator >=(SortableDouble value1, SortableDouble value2)
        {
            // The below clause will be removed once Double is replaced with Real
            if (value1 == value2)
            {
                return true;
            }

            return value1.Value >= value2.Value;
        }

        #endregion
    }
}