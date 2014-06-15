
namespace opt.Units
{
    public interface IUnitConversionProvider<TValue>
    {
        // Is expected to return null if conversion is not found, NOT throw KeyNotFound or other exception.
        UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit);
    }
}