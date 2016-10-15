using System;

// TODO: Reuse this struct in the genes encoding

namespace opt.Solvers.Genetics
{
    /// <summary>
    /// Represents single bit
    /// </summary>
    /// <remarks>Immutable</remarks>
    public struct Bit : IComparable, IEquatable<Bit>
    {
        /// <summary>
        /// Bit value storage
        /// </summary>
        private readonly Boolean value;

        /// <summary>
        /// Initializes new instance of <see cref="Bit"/> structure with value of <paramref name="anotherBit"/>
        /// </summary>
        /// <param name="anotherBit"><see cref="Bit"/> instance to copy value from</param>
        public Bit(Bit anotherBit)
        {
            value = anotherBit.value;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Bit"/> structure
        /// </summary>
        /// <param name="bitValue">True is 1, False is 0</param>
        public Bit(Boolean bitValue)
        {
            value = bitValue;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Bit"/> structure
        /// </summary>
        /// <param name="bitValue">1 is 1, 0 is 0, other values cause an exception</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="bitValue"/> is neither 1 nor 0</exception>
        public Bit(Int32 bitValue)
        {
            if (bitValue == 0)
            {
                value = false;
            }
            else if (bitValue == 1)
            {
                value = true;
            }

            throw new ArgumentOutOfRangeException("bitValue", "This constructor accepts only 0 or 1 as a bitValue parameter value");
        }

        /// <summary>
        /// Initializes new instance of <see cref="Bit"/> structure
        /// </summary>
        /// <param name="bitValue">'1' is 1, '0' is 0, other values cause an exception</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="bitValue"/> is neither '1' nor '0'</exception>
        public Bit(Char bitValue)
        {
            if (bitValue == '0')
            {
                value = false;
            }
            else if (bitValue == '1')
            {
                value = true;
            }

            throw new ArgumentOutOfRangeException("bitValue", "This constructor accepts only '0' or '1' as a bitValue parameter value");
        }

        /// <summary>
        /// Creates new instance of <see cref="Bit"/> structure. Value of the new instance is opposite to the 
        /// value of current instance
        /// </summary>
        /// <returns>New instance of <see cref="Bit"/> with opposite value</returns>
        public Bit Invert()
        {
            return new Bit(!value);
        }

        #region IComparable

        /// <summary>
        /// Compares this instance to a specified <see cref="Bit"/> object and returns an
        /// integer that indicates their relationship to one another
        /// </summary>
        /// <param name="obj">A <see cref="Bit"/> object to compare to this instance</param>
        /// <returns>A signed integer that indicates the relative values of this instance and
        /// <paramref name="obj"/>. Return Value Condition Less than zero This instance is 0 and 
        /// <paramref name="obj"/> is 1. Zero This instance and <paramref name="obj"/> are equal 
        /// (either both are 1 or both are 0). Greater than zero This instance is 1 and 
        /// <paramref name="obj"/> is 0</returns>
        public Int32 CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Bit otherBit = (Bit)obj;
            return value.CompareTo(otherBit.value);
        }

        #endregion

        #region IEquatable<Bit>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the <see cref="Bit"/>
        /// type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>True if the current object is equal to the <paramref name="other"/> parameter; otherwise, False</returns>
        public Boolean Equals(Bit other)
        {
            return this == other;
        }

        #endregion

        #region object overrides

        /// <summary>
        /// Determines whether the specified <see cref="Bit"/> is equal to the current one
        /// </summary>
        /// <param name="obj">The <see cref="Bit"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="Bit"/> is equal to the current one;
        /// otherwise, False</returns>
        public override Boolean Equals(Object obj)
        {
            return (obj is Bit) && (this == (Bit)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="Bit"/></returns>
        public override Int32 GetHashCode()
        {
            return value.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Bit"/> instance
        /// </summary>
        /// <returns>"1" if bit value is 1 and "0" if bit value is 0</returns>
        public override String ToString()
        {
            return (value == true ? "1" : "0");
        }

        #endregion

        #region Comparison operators

        /// <summary>
        /// Determines whether values of two instances of <see cref="Bit"/> are equal
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is equal to the <paramref name="bit2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator ==(Bit bit1, Bit bit2)
        {
            return bit1.value == bit2.value;
        }

        /// <summary>
        /// Determines whether values of two instances of <see cref="Bit"/> are not equal
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is not equal to the <paramref name="bit2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator !=(Bit bit1, Bit bit2)
        {
            return !(bit1 == bit2);
        }

        /// <summary>
        /// Determines whether value of <paramref name="bit1"/> is less than value of 
        /// <paramref name="bit2"/>
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is 0 and <paramref name="bit2"/> 
        /// value is 1; otherwise, False</returns>
        public static Boolean operator <(Bit bit1, Bit bit2)
        {
            return ((bit1.value == false) && (bit2.value == true));
        }

        /// <summary>
        /// Determines whether value of <paramref name="bit1"/> is less or equal than value of 
        /// <paramref name="bit2"/>
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is 0 and <paramref name="bit2"/> 
        /// value is 1 OR if both bits are equal; otherwise, False</returns>
        public static Boolean operator <=(Bit bit1, Bit bit2)
        {
            return (bit1 < bit2) || (bit1.value == bit2.value);
        }

        /// <summary>
        /// Determines whether value of <paramref name="bit1"/> is greater than value of 
        /// <paramref name="bit2"/>
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is 1 and <paramref name="bit2"/> 
        /// value is 0; otherwise, False</returns>
        public static Boolean operator >(Bit bit1, Bit bit2)
        {
            return ((bit1.value == true) && (bit2.value == false));
        }

        /// <summary>
        /// Determines whether value of <paramref name="bit1"/> is greater or equal than value of 
        /// <paramref name="bit2"/>
        /// </summary>
        /// <param name="bit1">First instance of <see cref="Bit"/></param>
        /// <param name="bit2">Second instance of <see cref="Bit"/></param>
        /// <returns>True if <paramref name="bit1"/> value is 1 and <paramref name="bit2"/> 
        /// value is 0 OR if both bits are equal; otherwise, False</returns>
        public static Boolean operator >=(Bit bit1, Bit bit2)
        {
            return (bit1 > bit2) || (bit1.value == bit2.value);
        }

        #endregion

        #region T(x) operators

        /// <summary>
        /// Implicitly converts <see cref="Boolean"/> value to <see cref="Bit"/>
        /// </summary>
        /// <param name="bitValue"><see cref="Boolean"/> value to convert</param>
        /// <returns>New instance of <see cref="Bit"/> which value is 1 if
        /// <paramref name="bitValue"/> is True and 0 if <paramref name="bitValue"/>
        /// is False</returns>
        public static implicit operator Bit(Boolean bitValue)
        {
            return new Bit(bitValue);
        }

        /// <summary>
        /// Implicitly converts <see cref="Int32"/> value to <see cref="Bit"/>
        /// </summary>
        /// <param name="bitValue"><see cref="Int32"/> value to convert</param>
        /// <returns>New instance of <see cref="Bit"/> which value is 1 if
        /// <paramref name="bitValue"/> is 1 and 0 if <paramref name="bitValue"/>
        /// is 0. Other <paramref name="bitValue"/> values will cause exception</returns>
        public static implicit operator Bit(Int32 bitValue)
        {
            return new Bit(bitValue);
        }

        /// <summary>
        /// Implicitly converts <see cref="Bit"/> to <see cref="Boolean"/> value
        /// </summary>
        /// <param name="instance"><see cref="Bit"/> to convert</param>
        /// <returns><see cref="Boolean"/> value which is True if
        /// <paramref name="instance"/> is 1 and False if <paramref name="instance"/>
        /// is 0</returns>
        public static implicit operator Boolean(Bit instance)
        {
            return instance.value;
        }

        /// <summary>
        /// Implicitly converts <see cref="Bit"/> to <see cref="Char"/> value
        /// </summary>
        /// <param name="instance"><see cref="Bit"/> to convert</param>
        /// <returns><see cref="Char"/> value which is '1' if
        /// <paramref name="instance"/> is 1 and '0' if <paramref name="instance"/>
        /// is 0</returns>
        public static implicit operator Char(Bit instance)
        {
            return (instance.value ? '1' : '0');
        }

        /// <summary>
        /// Implicitly converts <see cref="Bit"/> to <see cref="String"/> value
        /// </summary>
        /// <param name="instance"><see cref="Bit"/> to convert</param>
        /// <returns><see cref="String"/> value which is "1" if
        /// <paramref name="instance"/> is 1 and "0" if <paramref name="instance"/>
        /// is 0</returns>
        public static implicit operator String(Bit instance)
        {
            return instance.ToString();
        }

        #endregion
    }
}