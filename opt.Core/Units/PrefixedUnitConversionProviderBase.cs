using System;

namespace opt.Units
{
    public abstract class PrefixedUnitConversionProviderBase<TValue> : IUnitConversionProvider<TValue>
    {
        public abstract TValue ConvertToBase(IUnit fromUnit, IUnit toUnit, TValue value);
        public abstract TValue ConvertFromBase(IUnit fromUnit, IUnit toUnit, TValue value);
        public abstract TValue ConvertFromPrefixedToPrefixed(IUnit fromUnit, IUnit toUnit, TValue value);

        public virtual UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            IPrefixedUnit prefixedFrom = fromUnit as IPrefixedUnit;
            IPrefixedUnit prefixedTo = toUnit as IPrefixedUnit;

            // 1. 'fromUnit' is prefixed unit of 'toUnit'
            if (prefixedFrom != null &&
                prefixedFrom.BaseUnit.Equals(toUnit))
            {
                return ConvertToBase;
            }

            // 2. 'fromUnit' is base unit of prefixed unit 'toUnit'
            if (prefixedTo != null &&
                prefixedTo.BaseUnit.Equals(fromUnit))
            {
                return ConvertFromBase;
            }

            // 3. 'fromUnit' and 'toUnit' share same base unit
            if (prefixedFrom != null &&
                prefixedTo != null &&
                prefixedFrom.BaseUnit.Equals(prefixedTo.BaseUnit))
            {
                return ConvertFromPrefixedToPrefixed;
            }

            // 4. 'fromUnit' and 'toUnit' are in not supported relation to each other
            return null;
        }
    }
}