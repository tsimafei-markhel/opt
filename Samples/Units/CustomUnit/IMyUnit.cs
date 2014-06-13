using opt.Units;

namespace Units.CustomUnit
{
    // It is possible to define custom interfaces for user-typed units

    public interface IMyUnit : IUnit
    {
        string Description { get; }
    }
}