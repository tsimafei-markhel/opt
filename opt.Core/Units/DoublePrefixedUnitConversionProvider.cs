using System;

namespace opt.Units
{
    public class DoublePrefixedUnitConversionProvider : PrefixedUnitConversionProviderBase<Double>
    {
        public override Double ConvertToBase(IUnit fromUnit, IUnit toUnit, Double value)
        {
            // Assume that 'fromUnit' is prefixed unit of 'toUnit'
            return value * ((IPrefixedUnit)fromUnit).Multiplier;
        }

        public override Double ConvertFromBase(IUnit fromUnit, IUnit toUnit, Double value)
        {
            // Assume that 'fromUnit' is base unit of prefixed unit 'toUnit'
            return value / ((IPrefixedUnit)toUnit).Multiplier;
        }

        public override Double ConvertFromPrefixedToPrefixed(IUnit fromUnit, IUnit toUnit, Double value)
        {
            // Assume that 'fromUnit' and 'toUnit' share same base unit
            double valueInBaseUnits = value * ((IPrefixedUnit)fromUnit).Multiplier;
            return valueInBaseUnits / ((IPrefixedUnit)toUnit).Multiplier;
        }
    }
}