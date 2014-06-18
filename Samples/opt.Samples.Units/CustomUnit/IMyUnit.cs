using opt.Units;

namespace opt.Samples.Units.CustomUnit
{
    // It is possible to define custom interfaces for user-typed units

    public interface IMyUnit : IUnit
    {
        string Description { get; }
    }
}