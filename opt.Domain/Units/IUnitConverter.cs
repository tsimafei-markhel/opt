
namespace opt.Units
{
    /// <summary>
    /// Interface for unit of measurement converter,
    /// an entity capable of converting value from one unit to another
    /// </summary>
    /// <typeparam name="TValue">Type of measurable value to be converted (e.g. <see cref="Double"/>)</typeparam>
    public interface IUnitConverter<TValue>
    {
        /// <summary>
        /// Converts <paramref name="value"/> from <paramref name="fromUnit"/> unit
        /// to <paramref name="toUnit"/> unit
        /// </summary>
        /// <param name="fromUnit">Unit of measurement to convert <paramref name="value"/> from</param>
        /// <param name="toUnit">Unit of measurement to convert <paramref name="value"/> to</param>
        /// <param name="value">Value to convert from <paramref name="fromUnit"/> to <paramref name="toUnit"/></param>
        /// <returns>Value acquired by converting <paramref name="value"/> from <paramref name="fromUnit"/> to
        /// <paramref name="toUnit"/></returns>
        TValue Convert(IUnit fromUnit, IUnit toUnit, TValue value);
    }
}