
namespace opt
{
    public interface IValue<TValue, TUnit>
    {
        TValue Value { get; }
        TUnit Unit { get; }
    }
}