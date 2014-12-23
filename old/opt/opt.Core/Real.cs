using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

// TODO: Think over integrating precision into this type
// TODO: Add XML comments
// TODO: Reuse this type instead of Double everywhere across the Core etc.

namespace opt
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Interfaces that should be implemented (according to <see cref="Double"/>), but were
    /// not implemented yet: IConvertible</remarks>
    [Serializable]
    public struct Real : IComparable, IFormattable, IComparable<Real>, IEquatable<Real>
    {
        private Double value;

        public static readonly Real Epsilon = new Real(Double.Epsilon);
        public static readonly Real MaxValue = new Real(Double.MaxValue);
        public static readonly Real MinValue = new Real(Double.MinValue);
        public static readonly Real NaN = new Real(Double.NaN);
        public static readonly Real NegativeInfinity = new Real(Double.NegativeInfinity);
        public static readonly Real PositiveInfinity = new Real(Double.PositiveInfinity);

        private Real(Double realValue)
        {
            value = realValue;
        }

        public static Boolean IsInfinity(Real real)
        {
            return Double.IsInfinity(real.value);
        }

        public static Boolean IsNaN(Real real)
        {
            return Double.IsNaN(real.value);
        }

        public static Boolean IsNegativeInfinity(Real real)
        {
            return Double.IsNegativeInfinity(real.value);
        }

        public static Boolean IsPositiveInfinity(Real real)
        {
            return Double.IsPositiveInfinity(real.value);
        }

        public String ToStringInvariant()
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        public String ToStringInvariant(String format)
        {
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        #region Comparison operators

        public static Boolean operator ==(Real left, Real right)
        {
            return Math.Abs(left - right) < Double.Epsilon;
        }

        public static Boolean operator !=(Real left, Real right)
        {
            return !(left == right);
        }

        public static Boolean operator <(Real left, Real right)
        {
            if (left == right)
            {
                return false;
            }

            return left.value < right.value;
        }

        public static Boolean operator <=(Real left, Real right)
        {
            if (left == right)
            {
                return true;
            }

            return left.value < right.value;
        }

        public static Boolean operator >(Real left, Real right)
        {
            if (left == right)
            {
                return false;
            }

            return left.value > right.value;
        }

        public static Boolean operator >=(Real left, Real right)
        {
            if (left == right)
            {
                return true;
            }

            return left.value > right.value;
        }

        #endregion

        #region Arithmetics operators

        public static Real operator +(Real left, Real right)
        {
            return new Real(left.value + right.value);
        }

        public static Real operator -(Real left, Real right)
        {
            return new Real(left.value - right.value);
        }

        public static Real operator *(Real left, Real right)
        {
            return new Real(left.value * right.value);
        }

        public static Real operator /(Real left, Real right)
        {
            return new Real(left.value / right.value);
        }

        #endregion

        #region Arithmetics operators - friendly names per CA2225
        // See http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(CA2225);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.0)&rd=true

        public static Real Add(Real left, Real right)
        {
            return left + right;
        }

        public static Real Subtract(Real left, Real right)
        {
            return left - right;
        }

        public static Real Multiply(Real left, Real right)
        {
            return left * right;
        }

        public static Real Divide(Real left, Real right)
        {
            return left / right;
        }

        #endregion

        #region ValueType overrides

        public override Boolean Equals(Object obj)
        {
            if (!(obj is Real))
            {
                return false;
            }

            Real r = (Real)obj;
            if (r == this)
            {
                return true;
            }

            if (Real.IsNaN(r))
            {
                return Real.IsNaN(this);
            }
            else
            {
                return false;
            }
        }

        public override Int32 GetHashCode()
        {
            return value.GetHashCode();
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Double.ToString",
            Justification = "This is done intentionally, to reflect double-ish nature of the class")]
        public override String ToString()
        {
            return value.ToString();
        }

        #endregion

        #region IComparable

        public Int32 CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (!(obj is Real))
            {
                // Message in the exception below has to stay
                throw new ArgumentException("Parameter type must be " + this.GetType().Name, "obj");
            }

            Real r = (Real)obj;
            if (this == r)
            {
                return 0;
            }

            if (this < r)
            {
                return -1;
            }

            if (this > r)
            {
                return 1;
            }

            if (!Real.IsNaN(this))
            {
                return 1;
            }

            return !Real.IsNaN(r) ? -1 : 0;
        }

        #endregion

        #region IFormattable

        public String ToString(String format)
        {
            return ToString(format, NumberFormatInfo.CurrentInfo);
        }

        public String ToString(IFormatProvider provider)
        {
            return ToString((String)null, NumberFormatInfo.GetInstance(provider));
        }

        public String ToString(String format, IFormatProvider formatProvider)
        {
            return value.ToString(format, formatProvider);
        }

        #endregion

        #region IComparable<Real>

        public Int32 CompareTo(Real other)
        {
            if (this == value)
            {
                return 0;
            }

            if (this < value)
            {
                return -1;
            }

            if (this > value)
            {
                return 1;
            }

            if (!Real.IsNaN(this))
            {
                return 1;
            }

            return !Real.IsNaN(value) ? -1 : 0;
        }

        #endregion

        #region IEquatable<Real>

        public Boolean Equals(Real other)
        {
            if (other == this)
            {
                return true;
            }

            if (Real.IsNaN(other))
            {
                return Real.IsNaN(this);
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region T(x) operators

        public static implicit operator Real(Double realValue)
        {
            return new Real(realValue);
        }

        public static implicit operator Double(Real instance)
        {
            return instance.value;
        }

        #endregion

        #region Parsing

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Double.Parse(System.String)",
            Justification = "This is done intentionally, to reflect double-ish nature of the class")]
        public static Real Parse(String source)
        {
            return new Real(Double.Parse(source));
        }

        public static Real Parse(String source, IFormatProvider provider)
        {
            return new Real(Double.Parse(source, provider));
        }

        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
            MessageId = "System.Double.Parse(System.String,System.Globalization.NumberStyles)",
            Justification = "This is done intentionally, to reflect double-ish nature of the class")]
        public static Real Parse(String source, NumberStyles style)
        {
            return new Real(Double.Parse(source, style));
        }

        public static Real Parse(String source, NumberStyles style, IFormatProvider provider)
        {
            return new Real(Double.Parse(source, style, provider));
        }

        public static Boolean TryParse(String source, out Real result)
        {
            return Double.TryParse(source, out result.value);
        }

        public static Boolean TryParse(String source, NumberStyles style, IFormatProvider provider, out Real result)
        {
            return Double.TryParse(source, style, provider, out result.value);
        }

        #endregion
    }
}