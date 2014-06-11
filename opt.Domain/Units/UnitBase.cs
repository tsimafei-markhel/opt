using System;

namespace opt.Units
{
    public abstract class UnitBase : IUnit
    {
        public String Name { get; private set; }

        public String Symbol { get; private set; }

        protected UnitBase(String name, String symbol)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol");
            }

            Name = name;
            Symbol = symbol;
        }
    }
}