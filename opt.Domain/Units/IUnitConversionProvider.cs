
namespace opt.Units
{
    /// <summary>
    /// Interface for unit of measurement conversion provider, an entity capable of providing
    /// <see cref="UnitConversion<TValue>"/> for specified units
    /// </summary>
    /// <typeparam name="TValue">Type of measurable value to be converted (e.g. <see cref="Double"/>)</typeparam>
    public interface IUnitConversionProvider<TValue>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromUnit">Unit of measurement to convert value from</param>
        /// <param name="toUnit">Unit of measurement to convert value to</param>
        /// <returns><see cref="UnitConversion<TValue>"/> for specified units conversion</returns>
        /// <remarks>This method is expected to return null if conversion cannot be returned by this provider,
        /// NOT throw KeyNotFound or other exception</remarks>
        UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit);
    }
}