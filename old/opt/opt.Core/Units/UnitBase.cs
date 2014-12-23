using System;

namespace opt.Units
{
    public abstract class UnitBase : IUnit
    {
        public String Name { get; private set; }
        public String Symbol { get; private set; }
        public String Description { get; private set; }

        protected UnitBase(String name, String symbol, String description)
        {
            Name = name;
            Symbol = symbol;
            Description = description;
        }

        protected UnitBase(String name, String symbol) :
            this(name, symbol, string.Empty)
        {
        }
    }
}