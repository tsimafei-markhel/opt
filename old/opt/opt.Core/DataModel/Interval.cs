using System;
using System.Diagnostics.CodeAnalysis;
using opt.Extensions;

// TODO: Reuse across the solution

namespace opt.DataModel
{
    /// <summary>
    /// Represents an interval
    /// </summary>
    /// <remarks>Immutable</remarks>
    [SuppressMessage("Microsoft.Performance", "CA1815:OverrideEqualsAndOperatorEqualsOnValueTypes",
        Justification = "Fixed in opt.DataModel.New.Range class")]
    [Serializable]
    public struct Interval
    {
        /// <summary>
        /// Stores string representation of the <see cref="Interval"/> determined 
        /// during initialization
        /// </summary>
        /// <remarks>As long as <see cref="Interval"/> is immutable, we can determine
        /// its string representation on initialization and cache determined value</remarks>
        private string cachedString;

        /// <summary>
        /// Stores string representation of the <see cref="Interval"/> determined 
        /// during initialization - with <see cref="CultureInfo.Invariant"/>
        /// </summary>
        /// <remarks>As long as <see cref="Interval"/> is immutable, we can determine
        /// its string representation on initialization and cache determined value</remarks>
        private string cachedStringInvariant;

        /// <summary>
        /// Stores string format of the <see cref="Interval"/> determined
        /// during initialization. It should be used when interval boundaries
        /// have to be formatted
        /// </summary>
        private string cachedStringFormat;

        /// <summary>
        /// Gets lower boundary of the <see cref="Interval"/>
        /// </summary>
        public double Minimum { get; private set; }

        /// <summary>
        /// Gets upper boundary of the <see cref="Interval"/>
        /// </summary>
        public double Maximum { get; private set; }

        /// <summary>
        /// Gets <see cref="Interval"/> length. Always positive
        /// </summary>
        /// <remarks><see cref="Interval.Length"/> = <see cref="Math.Abs"/>(
        /// <see cref="Interval.Maximum"/> - <see cref="Interval.Minimum"/>)</remarks>
        public double Length { get; private set; }

        /// <summary>
        /// Gets whether a lower boundary of <see cref="Interval"/> is open
        /// </summary>
        public bool IsMinimumOpen { get; private set; }

        /// <summary>
        /// Gets whether an upper boundary of <see cref="Interval"/> is open
        /// </summary>
        public bool IsMaximumOpen { get; private set; }

        /// <summary>
        /// Gets whether <see cref="Interval"/> is open. True if both 
        /// <see cref="Interval.IsMinimumOpen"/> and <see cref="Interval.IsMaximumOpen"/>
        /// are True
        /// </summary>
        public bool IsOpen { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Interval"/>
        /// </summary>
        /// <param name="minimum">Lower boundary</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not</param>
        /// <param name="maximum">Upper boundary</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not</param>
        /// <exception cref="ArgumentException">If <paramref name="minimum"/> or
        /// <paramref name="maximum"/> is <see cref="double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/> is
        /// greater than <paramref name=""/></exception>
        /// <remarks><see cref="Double.NegativeInfinity"/> and <see cref="Double.PositiveInfinity"/>
        /// boundaries will be always open</remarks>
        public Interval(
            double minimum,
            bool isMinimumOpen,
            double maximum,
            bool isMaximumOpen)
            : this()
        {
            ValidateBoundaries(minimum, maximum);

            Minimum = minimum;
            Maximum = maximum;
            Length = Math.Abs(Maximum - Minimum);
            IsMinimumOpen = double.IsNegativeInfinity(Minimum) ? true : isMinimumOpen;
            IsMaximumOpen = double.IsPositiveInfinity(Maximum) ? true : isMaximumOpen;
            IsOpen = IsMinimumOpen && IsMaximumOpen;

            cachedStringFormat = (IsMinimumOpen ? "(" : "[") + "{1}, {2}" + (IsMaximumOpen ? ")" : "]");
            cachedString = string.Format(cachedStringFormat, Minimum.ToString(), Maximum.ToString());
            cachedStringInvariant = string.Format(cachedStringFormat, Minimum.ToStringInvariant(), Maximum.ToStringInvariant());
        }

        /// <summary>
        /// Initializes new instance of <see cref="Interval"/> which is
        /// closed from both sides
        /// </summary>
        /// <param name="minimum">Lower boundary</param>
        /// <param name="maximum">Upper boundary</param>
        /// <exception cref="ArgumentException">If <paramref name="minimum"/> or
        /// <paramref name="maximum"/> is <see cref="double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/> is
        /// greater than <paramref name=""/></exception>
        public Interval(
            double minimum,
            double maximum)
            : this(minimum, false, maximum, false)
        {
        }

        /// <summary>
        /// Checks whether a <paramref name="value"/> belongs to the <see cref="Interval"/>
        /// </summary>
        /// <param name="value">Value that needs to be tested</param>
        /// <returns>True if <paramref name="value"/> belongs to the <see cref="Interval"/>;
        /// otherwise False</returns>
        public bool InInterval(double value)
        {
            if (value < Minimum || value > Maximum)
            {
                return false;
            }

            if (value > Minimum && value < Maximum)
            {
                return true;
            }

            bool isMinEdge = value == Minimum;
            if (IsMinimumOpen && isMinEdge)
            {
                return false;
            }

            bool isMaxEdge = value == Maximum;
            if (IsMaximumOpen && isMaxEdge)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether an <paramref name="otherInterval"/> belongs to the <see cref="Interval"/>
        /// </summary>
        /// <param name="otherInterval"><see cref="Interval"/> that needs to be tested</param>
        /// <returns>True if both <see cref="Interval.Minimum"/> and <see cref="Interval.Maximum"/>
        /// of <paramref name="otherInterval"/> belong to the <see cref="Interval"/>;
        /// otherwise False</returns>
        public bool InInterval(Interval otherInterval)
        {
            // TODO: This is questionable...
            return InInterval(otherInterval.Minimum) && InInterval(otherInterval.Maximum);
        }

        #region ToString() overloads

        /// <summary>
        /// Converts <see cref="Interval"/> value to string with <see cref="CultureInfo.Invariant"/>
        /// </summary>
        /// <returns>String representation of this <see cref="Interval"/> instance for
        /// <see cref="CultureInfo.Invariant"/></returns>
        public string ToStringInvariant()
        {
            return cachedStringInvariant;
        }

        /// <summary>
        /// Converts <see cref="Interval"/> value to string with desired <paramref name="format"/> 
        /// for <see cref="Double"/> to <see cref="String"/> conversion
        /// </summary>
        /// <param name="doubleFormat"><see cref="Double"/> to <see cref="String"/> format</param>
        /// <returns>String representation of this <see cref="Interval"/> instance. Boundaries
        /// are formatted with <paramref name="doubleFormat"/></returns>
        public string ToString(string doubleFormat)
        {
            return string.Format(cachedStringFormat, Minimum.ToString(doubleFormat), Maximum.ToString(doubleFormat));
        }

        /// <summary>
        /// Converts <see cref="Interval"/> value to string with desired <paramref name="format"/> 
        /// for <see cref="Double"/> to <see cref="String"/> conversion and <see cref="CultureInfo.Invariant"/>
        /// </summary>
        /// <param name="doubleFormat"><see cref="Double"/> to <see cref="String"/> format</param>
        /// <returns>String representation of this <see cref="Interval"/> instance. Boundaries
        /// are formatted with <paramref name="doubleFormat"/> - for <see cref="CultureInfo.Invariant"/></returns>
        public string ToStringInvariant(string doubleFormat)
        {
            return string.Format(cachedStringFormat, Minimum.ToStringInvariant(doubleFormat), Maximum.ToStringInvariant(doubleFormat));
        }

        #endregion

        #region Factory methods

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/>
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Interval.Length"/> / 2</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not. Default is False</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not. Default is False</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// <paramref name="mean"/> - <paramref name="deviationValue"/> and its
        /// maximum is <paramref name="mean"/> + <paramref name="deviationValue"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> or <paramref name="deviationValue"/>
        /// is <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or
        /// <paramref name="deviationValue"/> is <see cref="Double.NegativeInfinity"/> or
        /// <see cref="Double.PositiveInfinity"/>. If <paramref name="deviationValue"/> is
        /// below zero</exception>
        public static Interval Create(double mean, double deviationValue, bool isMinimumOpen = false, bool isMaximumOpen = false)
        {
            ValidateMean(mean);
            ValidateDeviationValue(deviationValue);

            double min = mean - deviationValue;
            double max = mean + deviationValue;

            return new Interval(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/>
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Interval.Minimum"/> (or <see cref="Interval.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not. Default is False</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not. Default is False</param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> is <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> is
        /// <see cref="Double.NegativeInfinity"/> or <see cref="Double.PositiveInfinity"/>.
        /// If <paramref name="deviationPercent"/> is below zero</exception>
        public static Interval Create(double mean, int deviationPercent, bool isMinimumOpen = false, bool isMaximumOpen = false)
        {
            ValidateMean(mean);
            ValidateDeviationPercent(deviationPercent);

            double min = double.NaN;
            double max = double.NaN;
            double deviationValue = deviationPercent / 100.0;

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

            return new Interval(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationValue"/> but never exceed
        /// the restrictions
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationValue">Desired <see cref="Interval.Length"/> / 2</param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Interval.Minimum"/>
        /// of the resulting <see cref="Interval"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Interval.Maximum"/>
        /// of the resulting <see cref="Interval"/> instance will not be greater than this value</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not. Default is False</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not. Default is False</param>
        /// <returns>New instance of <see cref="Invariant"/>. Its minimum is
        /// MAX(<paramref name="mean"/> - <paramref name="deviationValue"/>; <paramref name="minRestriction"/>)
        /// and its maximum is MIN(<paramref name="mean"/> + <paramref name="deviationValue"/>;
        /// <paramref name="maxRestriction"/>)</returns>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> or <paramref name="deviationValue"/>
        /// or <paramref name="minRestriction"/> or <paramref name="maxRestriction"/> is
        /// <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> or
        /// <paramref name="deviationValue"/> is <see cref="Double.NegativeInfinity"/> or
        /// <see cref="Double.PositiveInfinity"/>. If <paramref name="deviationValue"/> is
        /// below zero. If <paramref name="minRestriction"/> is greater than
        /// <paramref name="maxRestriction"/></exception>
        public static Interval CreateWithRestrictions(double mean, double deviationValue, double minRestriction, double maxRestriction, bool isMinimumOpen = false, bool isMaximumOpen = false)
        {
            ValidateMean(mean);
            ValidateDeviationValue(deviationValue);
            ValidateBoundaries(minRestriction, maxRestriction);

            double min = mean - deviationValue;
            if (min < minRestriction)
            {
                min = minRestriction;
            }

            double max = mean + deviationValue;
            if (max > maxRestriction)
            {
                max = maxRestriction;
            }

            return new Interval(min, isMinimumOpen, max, isMaximumOpen);
        }

        /// <summary>
        /// Creates new instance of <see cref="Invariant"/>. Boundaries are calculated from
        /// <paramref name="mean"/> and <paramref name="deviationPercent"/> but never exceed
        /// the restrictions
        /// </summary>
        /// <param name="mean">Mean (middle) of the interval</param>
        /// <param name="deviationPercent">Desired distance between <paramref name="mean"/>
        /// and resulting <see cref="Interval.Minimum"/> (or <see cref="Interval.Minimum"/>)
        /// expressed in percents of <paramref name="mean"/></param>
        /// <param name="minRestriction">Lower boundary restriction. <see cref="Interval.Minimum"/>
        /// of the resulting <see cref="Interval"/> instance will not be less than this value</param>
        /// <param name="maxRestriction">Upper boundary restriction. <see cref="Interval.Maximum"/>
        /// of the resulting <see cref="Interval"/> instance will not be greater than this value</param>
        /// <param name="isMinimumOpen">Whether lower boundary is open or not. Default is False</param>
        /// <param name="isMaximumOpen">Whether upper boundary is open or not. Default is False</param>
        /// <returns>New instance of <see cref="Invariant"/> which is <paramref name="mean"/>
        /// +- <paramref name="deviationPercent"/> * <paramref name="mean"/>. Restrictions
        /// are applied and can replace <see cref="Interval.Minimum"/> and <see cref="Interval.Maximum"/>
        /// in the result</returns>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> or <paramref name="minRestriction"/>
        /// or <paramref name="maxRestriction"/> is <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/> is
        /// <see cref="Double.NegativeInfinity"/> or <see cref="Double.PositiveInfinity"/>.
        /// If <paramref name="deviationPercent"/> is below zero. If <paramref name="minRestriction"/>
        /// is greater than <paramref name="maxRestriction"/></exception>
        public static Interval CreateWithRestrictions(double mean, int deviationPercent, double minRestriction, double maxRestriction, bool isMinimumOpen = false, bool isMaximumOpen = false)
        {
            ValidateMean(mean);
            ValidateDeviationPercent(deviationPercent);
            ValidateBoundaries(minRestriction, maxRestriction);

            double min = double.NaN;
            double max = double.NaN;
            double deviationValue = deviationPercent / 100.0;

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

            return new Interval(min, isMinimumOpen, max, isMaximumOpen);
        }

        #endregion

        #region Validation

        /// <summary>
        /// Validates mean (middle) value of the <see cref="Interval"/>
        /// </summary>
        /// <param name="mean">Mean (middle) value of the <see cref="Interval"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentException">If <paramref name="mean"/> is
        /// <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="mean"/>
        /// is <see cref="Double.NegativeInfinity"/> or <see cref="Double.PositiveInfinity"/></exception>
        private static void ValidateMean(double mean)
        {
            if (double.IsNaN(mean))
            {
                throw new ArgumentException("Mean cannot be NaN", "mean");
            }

            if (double.IsInfinity(mean))
            {
                throw new ArgumentOutOfRangeException("mean", "Mean cannot be infinity");
            }
        }

        /// <summary>
        /// Validates deviation value of the <see cref="Interval"/>
        /// </summary>
        /// <param name="deviationValue">Deviation value of the <see cref="Interval"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentException">If <paramref name="deviationValue"/> is
        /// <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="deviationValue"/>
        /// is <see cref="Double.NegativeInfinity"/> or <see cref="Double.PositiveInfinity"/>
        /// or is below zero</exception>
        private static void ValidateDeviationValue(double deviationValue)
        {
            if (double.IsNaN(deviationValue))
            {
                throw new ArgumentException("Deviation value cannot be NaN", "deviationValue");
            }

            if (double.IsInfinity(deviationValue))
            {
                throw new ArgumentOutOfRangeException("deviationValue", "Deviation value cannot be infinity");
            }

            if (deviationValue < 0)
            {
                throw new ArgumentOutOfRangeException("deviationValue", "Deviation value cannot be negative");
            }
        }

        /// <summary>
        /// Validates deviation percent of the <see cref="Interval"/>
        /// </summary>
        /// <param name="deviationPercent">Deviation percent of the <see cref="Interval"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="deviationPercent"/>
        /// is below zero</exception>
        private static void ValidateDeviationPercent(int deviationPercent)
        {
            if (deviationPercent < 0)
            {
                throw new ArgumentOutOfRangeException("deviationPercent", "Deviation percent cannot be negative");
            }
        }

        /// <summary>
        /// Validates lower and upper boundaries of the <see cref="Interval"/>
        /// </summary>
        /// <param name="minimum">Lower boundary of the <see cref="Interval"/>
        /// that needs to be validated</param>
        /// <param name="maximum">Upper boundary of the <see cref="Interval"/>
        /// that needs to be validated</param>
        /// <exception cref="ArgumentException">If <paramref name="minimum"/>
        /// or <paramref name="maximum"/> is <see cref="Double.NaN"/></exception>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="minimum"/>
        /// is greater than <paramref name="maximum"/></exception>
        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Fixed in opt.DataModel.New.Range class")]
        private static void ValidateBoundaries(double minimum, double maximum)
        {
            if (double.IsNaN(minimum))
            {
                throw new ArgumentException("Minimum cannot be NaN", "minimum");
            }

            if (double.IsNaN(maximum))
            {
                throw new ArgumentException("Maximum cannot be NaN", "maximum");
            }

            if (minimum > maximum)
            {
                throw new ArgumentOutOfRangeException("Minimum cannot be greater than maximum");
            }
        }

        #endregion

        #region Object overrides

        /// <summary>
        /// Determines whether the specified <see cref="Interval"/> is equal to the current one
        /// </summary>
        /// <param name="other">The <see cref="Interval"/> object to compare with the current one</param>
        /// <returns>True if the specified <see cref="Interval"/> is equal to the current one;
        /// otherwise, False</returns>
        [SuppressMessage("Microsoft.Naming", "CA1725:ParameterNamesShouldMatchBaseDeclaration",
            Justification = "Fixed in opt.DataModel.New.Range class")]
        [SuppressMessage("Microsoft.Usage", "CA2231:OverloadOperatorEqualsOnOverridingValueTypeEquals",
            Justification = "Fixed in opt.DataModel.New.Range class")]
        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (!(other is Interval))
            {
                return false;
            }

            return Minimum.Equals(((Interval)other).Minimum) && Maximum.Equals(((Interval)other).Maximum);
        }

        /// <summary>
        /// Serves as a hash function for a particular type
        /// </summary>
        /// <returns>A hash code for the current <see cref="Interval"/></returns>
        public override int GetHashCode()
        {
            return (33 + Minimum.GetHashCode()) * 33 + Maximum.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current <see cref="Interval"/> instance
        /// </summary>
        /// <returns>A string that represents the current <see cref="Interval"/> instance</returns>
        public override string ToString()
        {
            return cachedString;
        }

        #endregion

    }
}