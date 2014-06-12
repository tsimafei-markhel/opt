using System;

namespace opt.Units
{
    public class PrefixedUnit : UnitBase, IPrefixedUnit
    {
        public IUnit BaseUnit { get; private set; }
        public double Multiplier { get; private set; }

        public PrefixedUnit(string name, string symbol, IUnit baseUnit, double multiplier) :
            base(name, symbol)
        {
            if (baseUnit == null)
            {
                throw new ArgumentNullException("baseUnit");
            }

            if (baseUnit is ArbitraryUnit)
            {
                throw new ArgumentException(string.Empty, "baseUnit");
            }

            if (double.IsNaN(multiplier) || double.IsInfinity(multiplier) || Math.Abs(0.0 - multiplier) < double.Epsilon)
            {
                throw new ArgumentOutOfRangeException("multiplier");
            }

            BaseUnit = baseUnit;
            Multiplier = multiplier;
        }
    }
}