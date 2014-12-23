using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents an interval (range)
    /// </summary>
    /// <remarks>Immutable</remarks>
    [Serializable]
    public struct Range : IEquatable<Range>, IFormattable
    {
        /// <summary>
        /// Stores string format of the <see cref="Range"/> determined
        /// during initialization. It should be used when interval boundaries
        /// have to be formatted
        /// </summary>
        private String cachedStringFormat;

        /// <summary>
        /// Gets lower boundary of the <see cref="Range"/>
        /// </summary>
        public Real Minimum { get; private set; }

        /// <summary>
        /// Gets upper boundary of the <see cref="Range"/>
        /// </summary>
        public Real Maximum { get; private set; }

        /// <summary>
        /// Gets <see cref="Range"/> length. Always positive
        /// </summary>
        /// <remarks><see cref="Range.Length"/> = <see cref="Math.Abs"/>(
        /// <see cref="Range.Maximum"/> - <see cref="Range.Minimum"/>)</remarks>
        public Real Length { get; private set; }

        /// <summary>
        /// Gets whether a lower boundary of <see cref="Range"/> is open
        /// </summary>
        public Boolean IsMinimumOpen { get; private set; }

        /// <summary>
        /// Gets whether an upper boundary of <see cref="Range"/> is open
        /// </summary>
        public Boolean IsMaximumOpen { get; private set; }

        /// <summary>
        /// Gets whether <see cref="Range"/> is open. True if both 
        /// <see cref="Range.IsMinimumOpen"/> and <see cref="Range.IsMaximumOpen"/>
        /// are True
        /// </summary>
        public Boolean IsOpen { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Range"/>
        /// </summary>
        /// <param name="minimum">Lower boundary</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="maximum">Upper boundary</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/> or
        /// <paramref name="maximum"/> is <see cref="Real.NaN"/>. If <paramref name="minimum"/>
        /// is greater than <paramref name="maximum"/></exception>
        /// <remarks><see cref="Real.NegativeInfinity"/> and <see cref="Real.PositiveInfinity"/>
        /// boundaries will be always open</remarks>
        public Range(
            Real minimum,
            Boolean isMinimumOpen,
            Real maximum,
            Boolean isMaximumOpen)
            : this()
        {
            ValidateBoundaries(minimum, maximum);

            Minimum = minimum;
            Maximum = maximum;
            Length = Math.Abs(Maximum - Minimum);
            IsMinimumOpen = Real.IsNegativeInfinity(Minimum) ? true : isMinimumOpen;
            IsMaximumOpen = Real.IsPositiveInfinity(Maximum) ? true : isMaximumOpen;
            IsOpen = IsMinimumOpen && IsMaximumOpen;

            cachedStringFormat = (IsMinimumOpen ? "(" : "[") + "{1}, {2}" + (IsMaximumOpen ? ")" : "]");
        }

        /// <summary>
        /// Initializes new instance of <see cref="Range"/> which is
        /// closed from both sides
        /// </summary>
        /// <param name="minimum">Lower boundary</param>
        /// <param name="maximum">Upper boundary</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/> or
        /// <paramref name="maximum"/> is <see cref="Real.NaN"/>. If <paramref name="minimum"/>
        /// is greater than <paramref name="maximum"/></exception>
        public Range(
            Real minimum,
            Real maximum)
            : this(minimum, false, maximum, false)
        {
        }

        /// <summary>
        /// Checks whether a <paramref name="value"/> belongs to the <see cref="Range"/>
        /// </summary>
        /// <param name="value">Value that needs to be tested</param>
        /// <returns>True if <paramref name="value"/> belongs to the <see cref="Range"/>;
        /// otherwise False</returns>
        public Boolean IsInRange(Real value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            if (value > Minimum && value < Maximum)
            {
                return true;
            }

            Boolean isMinEdge = value == Minimum;
            if (IsMinimumOpen && isMinEdge)
            {
                return false;
            }

            Boolean isMaxEdge = value == Maximum;
            if (IsMaximumOpen && isMaxEdge)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether an <paramref name="otherRange"/> belongs to the <see cref="Range"/>
        /// </summary>
        /// <param name="otherRange"><see cref="Range"/> that needs to be tested</param>
        /// <returns>True if both <see cref="Range.Minimum"/> and <see cref="Range.Maximum"/>
        /// of <paramref name="otherRange"/> belong to the <see cref="Range"/>;
        /// otherwise False</returns>
        public Boolean IsInRange(Range otherRange)
        {
            // TODO: This is questionable...
            return IsInRange(otherRange.Minimum) && IsInRange(otherRange.Maximum);
        }

        #region ToString() overloads

        /// <summary>
        /// Converts <see cref="Range"/> value to string with desired <paramref name="format"/> 
        /// for <see cref="Real"/> to <see cref="String"/> conversion
        /// </summary>
        /// <param name="format"><see cref="Real"/> to <see cref="String"/> format</param>
        /// <returns>String representation of this <see cref="Range"/> instance. Boundaries
        /// are formatted with <paramref name="format"/></returns>
        public String ToString(String format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format
        /// </summary>
        /// <param name="format">The format to use or a null reference to use
        /// the default format</param>
        /// <param name="formatProvider">The provider to use to format the value or a null reference
        /// to obtain the numeric format information from the current locale
        /// setting of the operating system</param>
        /// <returns>The value of the current instance in the specified format</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
            MessageId = "System.String.Format(System.String,System.Object,System.Object)",
            Justification = "This behavior is intended")]
        public String ToString(String format, IFormatProvider formatProvider)
        {
            return String.Format(cachedStringFormat, Minimum.ToString(format, formatProvider), Maximum.ToString(format, formatProvider));
        }

        /// <summary>
        /// Converts <see cref="Range"/> value to <see cref="String"/> 
        /// with <see cref="CultureInfo.Invariant"/>
        /// </summary>
        /// <returns>String representation of this <see cref="Range"/> 
        /// instance - for <see cref="CultureInfo.Invariant"/></returns>
        public String ToStringInvariant()
        {
            return ToStringInvariant((String)null);
        }

        /// <summary>
        /// Converts <see cref="Range"/> value to string with desired <paramref name="format"/> 
        /// for <see cref="Real"/> to <see cref="String"/> conversion and <see cref="CultureInfo.Invariant"/>
        /// </summary>
        /// <param name="format"><see cref="Real"/> to <see cref="String"/> format</param>
        /// <returns>String representation of this <see cref="Range"/> instance. Boundaries
        /// are formatted with <paramref name="format"/> - for <see cref="CultureInfo.Invariant"/></returns>
        [SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider",
            MessageId = "System.String.Format(System.String,System.Object,System.Object)",
            Justification = "This behavior is intended")]
        public String ToStringInvariant(String format)
        {
            return String.Format(cachedStringFormat, Minimum.ToStringInvariant(format), Maximum.ToStringInvariant(format));
        }

        #endregion

        #region Factory methods

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/>; ends are closed
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Range.Length"/> / 2</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// <paramref name="mean"/> - <paramref name="deviationValue"/> and its
        /// maximum is <paramref name="mean"/> + <paramref name="deviationValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> 
        /// or <paramref name="deviationValue"/> is <see cref="Real.NaN"/>. If 
        /// <paramref name="mean"/> or <paramref name="deviationValue"/> is 
        /// <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>.
        /// If <paramref name="deviationValue"/> is below zero</exception>
        public static Range Create(Real mean, Real deviationValue)
        {
            return Create(mean, deviationValue, false, false);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/>
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Range.Length"/> / 2</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// <paramref name="mean"/> - <paramref name="deviationValue"/> and its
        /// maximum is <paramref name="mean"/> + <paramref name="deviationValue"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or 
        /// <paramref name="deviationValue"/> is <see cref="Real.NaN"/>. If 
        /// <paramref name="mean"/> or <paramref name="deviationValue"/> is 
        /// <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>.
        /// If <paramref name="deviationValue"/> is below zero</exception>
        public static Range Create(Real mean, Real deviationValue, Boolean isMinimumOpen, Boolean isMaximumOpen)
        {
            ValidateMean(mean);
            ValidateDeviationValue(deviationValue);

            Real min = mean - deviationValue;
            Real max = mean + deviationValue;

            return new Range(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/>; ends are closed
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Range.Minimum"/> (or <see cref="Range.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/></returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> is 
        /// <see cref="Real.NaN"/>. If <paramref name="mean"/> is <see cref="Real.NegativeInfinity"/>
        /// or <see cref="Real.PositiveInfinity"/>. If <paramref name="deviationPercent"/> is below zero
        /// </exception>
        public static Range Create(Real mean, Int32 deviationPercent)
        {
            return Create(mean, deviationPercent, false, false);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/>
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Range.Minimum"/> (or <see cref="Range.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> is <see cref="Real.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> is
        /// <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>.
        /// If <paramref name="deviationPercent"/> is below zero</exception>
        public static Range Create(Real mean, Int32 deviationPercent, Boolean isMinimumOpen, Boolean isMaximumOpen)
        {
            ValidateMean(mean);
            ValidateDeviationPercent(deviationPercent);

            Real min = Real.NaN;
            Real max = Real.NaN;
            Real deviationValue = deviationPercent / 100.0;

            if (mean >= 0)
            {
                min = mean - deviationValue * mean;
                max = mean + deviationValue * mean;
            }
            else
            {
                min = mean + deviationValue * mean;
                max = mean - deviationValue * mean;
            }

            return new Range(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/> but never exceed
        /// the restrictions; ends are closed
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Range.Length"/> / 2</param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Range.Minimum"/>
        /// of the resulting <see cref="Range"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Range.Maximum"/>
        /// of the resulting <see cref="Range"/> instance will not be greater than this value</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// MAX(<paramref name="mean"/> - <paramref name="deviationValue"/>; <paramref name="minRestriction"/>)
        /// and its maximum is MIN(<paramref name="mean"/> + <paramref name="deviationValue"/>;
        /// <paramref name="maxRestriction"/>)</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or 
        /// <paramref name="deviationValue"/> or <paramref name="minRestriction"/> or 
        /// <paramref name="maxRestriction"/> is <see cref="Real.NaN"/>. If 
        /// <paramref name="mean"/> or <paramref name="deviationValue"/> is 
        /// <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>.
        /// If <paramref name="deviationValue"/> is below zero.
        /// If <paramref name="minRestriction"/> is greater than <paramref name="maxRestriction"/>
        /// </exception>
        public static Range CreateWithRestrictions(
            Real mean,
            Real deviationValue,
            Real minRestriction,
            Real maxRestriction)
        {
            return CreateWithRestrictions(mean, deviationValue, minRestriction, maxRestriction, false, false);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/> but never exceed
        /// the restrictions
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Range.Length"/> / 2</param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Range.Minimum"/>
        /// of the resulting <see cref="Range"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Range.Maximum"/>
        /// of the resulting <see cref="Range"/> instance will not be greater than this value</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// MAX(<paramref name="mean"/> - <paramref name="deviationValue"/>; <paramref name="minRestriction"/>)
        /// and its maximum is MIN(<paramref name="mean"/> + <paramref name="deviationValue"/>;
        /// <paramref name="maxRestriction"/>)</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or 
        /// <paramref name="deviationValue"/> or <paramref name="minRestriction"/> or 
        /// <paramref name="maxRestriction"/> is <see cref="Real.NaN"/>. If <paramref name="mean"/>
        /// or <paramref name="deviationValue"/> is <see cref="Real.NegativeInfinity"/> or
        /// <see cref="Real.PositiveInfinity"/>. If <paramref name="deviationValue"/> is
        /// below zero. If <paramref name="minRestriction"/> is greater than
        /// <paramref name="maxRestriction"/></exception>
        public static Range CreateWithRestrictions(
            Real mean,
            Real deviationValue,
            Real minRestriction,
            Real maxRestriction,
            Boolean isMinimumOpen,
            Boolean isMaximumOpen)
        {
            ValidateMean(mean);
            ValidateDeviationValue(deviationValue);
            ValidateBoundaries(minRestriction, maxRestriction);

            Real min = mean - deviationValue;
            if (min < minRestriction)
            {
                min = minRestriction;
            }

            Real max = mean + deviationValue;
            if (max > maxRestriction)
            {
                max = maxRestriction;
            }

            return new Range(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/> but never exceed
        /// the restrictions
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Range.Minimum"/> (or <see cref="Range.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Range.Minimum"/>
        /// of the resulting <see cref="Range"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Range.Maximum"/>
        /// of the resulting <see cref="Range"/> instance will not be greater than this value</param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/>. Restrictions
        /// are applied and can replace <see cref="Range.Minimum"/> and <see cref="Range.Maximum"/>
        /// in the result</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or 
        /// <paramref name="minRestriction"/> or <paramref name="maxRestriction"/> is 
        /// <see cref="Real.NaN"/>. If <paramref name="mean"/> is <see cref="Real.NegativeInfinity"/>
        /// or <see cref="Real.PositiveInfinity"/>. If <paramref name="deviationPercent"/> is below 
        /// zero. If <paramref name="minRestriction"/> is greater than <paramref name="maxRestriction"/>
        /// </exception>
        public static Range CreateWithRestrictions(
            Real mean,
            Int32 deviationPercent,
            Real minRestriction,
            Real maxRestriction)
        {
            return CreateWithRestrictions(mean, deviationPercent, minRestriction, maxRestriction, false, false);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/> but never exceed
        /// the restrictions
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Range.Minimum"/> (or <see cref="Range.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Range.Minimum"/>
        /// of the resulting <see cref="Range"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Range.Maximum"/>
        /// of the resulting <see cref="Range"/> instance will not be greater than this value</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/>. Restrictions
        /// are applied and can replace <see cref="Range.Minimum"/> and <see cref="Range.Maximum"/>
        /// in the result</returns>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or 
        /// <paramref name="minRestriction"/> or <paramref name="maxRestriction"/> is 
        /// <see cref="Real.NaN"/>. If <paramref name="mean"/> is <see cref="Real.NegativeInfinity"/>
        /// or <see cref="Real.PositiveInfinity"/>. If <paramref name="deviationPercent"/> 
        /// is below zero. If <paramref name="minRestriction"/> is greater than <paramref name="maxRestriction"/>
        /// </exception>
        public static Range CreateWithRestrictions(
            Real mean,
            Int32 deviationPercent,
            Real minRestriction,
            Real maxRestriction,
            Boolean isMinimumOpen,
            Boolean isMaximumOpen)
        {
            ValidateMean(mean);
            ValidateDeviationPercent(deviationPercent);
            ValidateBoundaries(minRestriction, maxRestriction);

            Real min = Real.NaN;
            Real max = Real.NaN;
            Real deviationValue = deviationPercent / 100.0;

            if (mean >= 0)
            {
                min = mean - deviationValue * mean;
                max = mean + deviationValue * mean;
            }
            else
            {
                min = mean + deviationValue * mean;
                max = mean - deviationValue * mean;
            }

            if (min < minRestriction)
            {
                min = minRestriction;
            }

            if (max > maxRestriction)
            {
                max = maxRestriction;
            }

            return new Range(min, isMinimumOpen, max, isMaximumOpen);
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validates mean (middle) value of the <see cref="Range"/>
        /// </summary>
        /// <param name="mean">Mean (middle) value of the <see cref="Range"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> is
        /// <see cref="Real.NaN"/>. If <paramref name="mean"/> is 
        /// <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>
        /// </exception>
        private static void ValidateMean(Real mean)
        {
            if (Real.IsNaN(mean))
            {
                throw new ArgumentOutOfRangeException("mean");
            }

            if (Real.IsInfinity(mean))
            {
                throw new ArgumentOutOfRangeException("mean");
            }
        }

        /// <summary>
        /// Validates deviation value of the <see cref="Range"/>
        /// </summary>
        /// <param name="deviationValue">Deviation value of the <see cref="Range"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="deviationValue"/>
        /// is <see cref="Real.NaN"/>. If <paramref name="deviationValue"/>
        /// is <see cref="Real.NegativeInfinity"/> or <see cref="Real.PositiveInfinity"/>
        /// or is below zero</exception>
        private static void ValidateDeviationValue(Real deviationValue)
        {
            if (Real.IsNaN(deviationValue))
            {
                throw new ArgumentOutOfRangeException("deviationValue");
            }

            if (Real.IsInfinity(deviationValue))
            {
                throw new ArgumentOutOfRangeException("deviationValue");
            }

            if (deviationValue < 0)
            {
                throw new ArgumentOutOfRangeException("deviationValue");
            }
        }

        /// <summary>
        /// Validates deviation percent of the <see cref="Range"/>
        /// </summary>
        /// <param name="deviationPercent">Deviation percent of the <see cref="Range"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="deviationPercent"/>
        /// is below zero</exception>
        private static void ValidateDeviationPercent(Int32 deviationPercent)
        {
            if (deviationPercent < 0)
            {
                throw new ArgumentOutOfRangeException("deviationPercent");
            }
        }

        /// <summary>
        /// Validates lower and upper boundaries of the <see cref="Range"/>
        /// </summary>
        /// <param name="minimum">Lower boundary of the <see cref="Range"/>
        /// that needs to be validated</param>
        /// <param name="maximum">Upper boundary of the <see cref="Range"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/>
        /// or <paramref name="maximum"/> is <see cref="Real.NaN"/>. If 
        /// <paramref name="minimum"/> is greater than <paramref name="maximum"/>
        /// </exception>
        private static void ValidateBoundaries(Real minimum, Real maximum)
        {
            if (Real.IsNaN(minimum))
            {
                throw new ArgumentOutOfRangeException("minimum");
            }

            if (Real.IsNaN(maximum))
            {
                throw new ArgumentOutOfRangeException("maximum");
            }

            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("minimum");
            }
        }

        #endregion

        #region Object overrides

        /// <summary>
        /// Determines whether the specified <see cref="Range"/> is equal to the current one
        /// </summary>
        /// <param name="obj">The <see cref="Range"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="Range"/> is equal to the current one;
        /// otherwise, False</returns>
        public override Boolean Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Range))
            {
                return false;
            }

            Range otherRange = (Range)obj;
            return this == otherRange;
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="Range"/></returns>
        public override Int32 GetHashCode()
        {
            // http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
            unchecked
            {
                Int32 hash = 17;
                hash = hash * 29 + Minimum.GetHashCode();
                hash = hash * 29 + Maximum.GetHashCode();
                hash = hash * 29 + IsMinimumOpen.GetHashCode();
                hash = hash * 29 + IsMaximumOpen.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Range"/> instance
        /// </summary>
        /// <returns>A string that represents the current <see cref="Range"/> instance</returns>
        public override String ToString()
        {
            return ToString((String)null, CultureInfo.CurrentCulture);
        }

        #endregion

        #region Comparison operators

        /// <summary>
        /// Determines whether values of two instances of <see cref="Range"/> are equal
        /// </summary>
        /// <param name="range1">First instance of <see cref="Range"/></param>
        /// <param name="range2">Second instance of <see cref="Range"/></param>
        /// <returns>True if <paramref name="range1"/> value is equal to the <paramref name="range2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator ==(Range range1, Range range2)
        {
            return (range1.Minimum == range2.Minimum) &&
                   (range1.Maximum == range2.Maximum) &&
                   (range1.IsMinimumOpen == range2.IsMinimumOpen) &&
                   (range1.IsMaximumOpen == range2.IsMaximumOpen);
        }

        /// <summary>
        /// Determines whether values of two instances of <see cref="Range"/> are not equal
        /// </summary>
        /// <param name="range1">First instance of <see cref="Range"/></param>
        /// <param name="range2">Second instance of <see cref="Range"/></param>
        /// <returns>True if <paramref name="range1"/> value is not equal to the <paramref name="range2"/> 
        /// value; otherwise, False</returns>
        public static Boolean operator !=(Range range1, Range range2)
        {
            return !(range1 == range2);
        }

        #endregion

        #region IEquatable<Range>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type
        /// </summary>
        /// <param name="other">An object to compare with this object</param>
        /// <returns>True if the current object is equal to the other parameter; otherwise, False</returns>
        public Boolean Equals(Range other)
        {
            return this == other;
        }

        #endregion
    }
}