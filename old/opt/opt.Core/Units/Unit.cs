using System;

namespace opt.Units
{
    public class Unit : UnitBase
    {
        public static readonly IUnit Unitless = new Unitless();

        public Unit(String name, String symbol, String description) :
            base(name, symbol, description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol");
            }
        }

        public Unit(String name, String symbol) :
            this(name, symbol, string.Empty)
        {
        }
    }
}