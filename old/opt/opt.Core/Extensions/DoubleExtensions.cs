using System.Globalization;

namespace opt.Extensions
{
    /// <summary>
    /// Various <see cref="Double"/> extensions
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Converts <see cref="Double"/> value to string with Invariant culture info
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <returns><see cref="Double"/> value converted to string with Invariant culture info</returns>
        public static string ToStringInvariant(this double value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts <see cref="Double"/> value to string with desired <paramref name="format"/> and Invariant culture info
        /// </summary>
        /// <param name="value">Value to be converted</param>
        /// <param name="format">Desired format</param>
        /// <returns><see cref="Double"/> value converted to string with desired <paramref name="format"/> and Invariant culture info</returns>
        public static string ToStringInvariant(this double value, string format)
        {
            return value.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}