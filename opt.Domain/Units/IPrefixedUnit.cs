using System;

namespace opt.Units
{
    public interface IPrefixedUnit : IUnit
    {
        IUnit BaseUnit { get; }
        Double Multiplier { get; }
    }
}