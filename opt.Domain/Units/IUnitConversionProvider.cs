
namespace opt.Units
{
    public interface IUnitConversionProvider<TValue>
    {
        UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit);
    }
}