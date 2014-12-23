using System;
using System.Globalization;

namespace opt.Extensions
{
    /// <summary>
    /// Helper class with some Invariant culture methods
    /// </summary>
    public static class ConvertExtensions
    {
        /// <summary>
        /// Converts string <paramref name="value"/> to <see cref="Double"/> with Invariant culture info
        /// </summary>
        /// <param name="value">String value to be converted</param>
        /// <returns>String <paramref name="value"/> converted to <see cref="Double"/> with Invariant culture info</returns>
        public static double ToDoubleInvariant(string value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to <see cref="Double"/> with Invariant culture info
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <returns><paramref name="value"/> converted to <see cref="Double"/> with Invariant culture info</returns>
        public static double ToDoubleInvariant(object value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }
    }
}