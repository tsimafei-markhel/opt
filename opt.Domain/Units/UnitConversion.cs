
namespace opt.Units
{
    public delegate TValue UnitConversion<TValue>(IUnit fromUnit, IUnit toUnit, TValue value);
}