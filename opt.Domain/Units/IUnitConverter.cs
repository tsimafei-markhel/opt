
namespace opt.Units
{
    public interface IUnitConverter<TValue>
    {
        TValue Convert(IUnit fromUnit, IUnit toUnit, TValue value);
    }
}