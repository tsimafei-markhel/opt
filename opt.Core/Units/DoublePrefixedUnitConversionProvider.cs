using System;

namespace opt.Units
{
    public class DoublePrefixedUnitConversionProvider : PrefixedUnitConversionProviderBase<Double>
    {
        public override Double ConvertToBase(IUnit fromUnit, IUnit toUnit, Double value)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            IPrefixedUnit prefixedFromUnit = fromUnit as IPrefixedUnit;
            if (prefixedFromUnit == null)
            {
                throw new InvalidOperationException();
            }

            // Assume that 'fromUnit' is prefixed unit of 'toUnit'
            return value * prefixedFromUnit.Multiplier;
        }

        public override Double ConvertFromBase(IUnit fromUnit, IUnit toUnit, Double value)
        {
            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            IPrefixedUnit prefixedToUnit = toUnit as IPrefixedUnit;
            if (prefixedToUnit == null)
            {
                throw new InvalidOperationException();
            }

            // Assume that 'fromUnit' is base unit of prefixed unit 'toUnit'
            return value / prefixedToUnit.Multiplier;
        }

        public override Double ConvertFromPrefixedToPrefixed(IUnit fromUnit, IUnit toUnit, Double value)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            IPrefixedUnit prefixedFromUnit = fromUnit as IPrefixedUnit;
            if (prefixedFromUnit == null)
            {
                throw new InvalidOperationException();
            }

            IPrefixedUnit prefixedToUnit = toUnit as IPrefixedUnit;
            if (prefixedToUnit == null)
            {
                throw new InvalidOperationException();
            }

            // Assume that 'fromUnit' and 'toUnit' share same base unit
            double valueInBaseUnits = value * prefixedFromUnit.Multiplier;
            return valueInBaseUnits / prefixedToUnit.Multiplier;
        }
    }
}