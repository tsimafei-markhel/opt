using System;

namespace opt.Units
{
    public interface IUnit
    {
        String Name { get; }
        String Symbol { get; }
        String Description { get; }
    }
}