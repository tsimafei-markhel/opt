
namespace opt.Units
{
    /// <summary>
    /// Unit conversion function
    /// </summary>
    /// <typeparam name="TValue">Type of measurable value (e.g. <see cref="Double"/>)</typeparam>
    /// <param name="fromUnit">Unit of measurement to convert <paramref name="value"/> from</param>
    /// <param name="toUnit">Unit of measurement to convert <paramref name="value"/> to</param>
    /// <param name="value">Value to convert from <paramref name="fromUnit"/> to <paramref name="toUnit"/></param>
    /// <returns>Value acquired by converting <paramref name="value"/> from <paramref name="fromUnit"/> to
    /// <paramref name="toUnit"/></returns>
    public delegate TValue UnitConversion<TValue>(IUnit fromUnit, IUnit toUnit, TValue value);
}