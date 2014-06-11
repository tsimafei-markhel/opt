
namespace opt.Units
{
    public delegate TValue UnitConverter<TValue>(IUnit from, IUnit to, TValue value);
}