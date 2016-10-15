using System;

namespace opt.Extensions
{
    /// <summary>
    /// Helper class with some methods for <see cref="Enum"/> handling
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the string representation of the name or numeric value of one or 
        /// more enumerated constants to an equivalent enumerated object
        /// </summary>
        /// <typeparam name="T">An enumeration type</typeparam>
        /// <param name="value">A string containing the name or value to convert</param>
        /// <returns>A typed object of type enumType whose value is represented by <paramref name="value"/></returns>
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}