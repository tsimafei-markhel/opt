using System;

namespace opt.Units
{
    public class UnitConverter<TValue> : AggregateUnitConversionProvider<TValue>, IUnitConverter<TValue>
    {
        private readonly UnitConversionDictionary<TValue> cachedConvertions = new UnitConversionDictionary<TValue>();

        public UnitConverter(params IUnitConversionProvider<TValue>[] providers) :
            base(providers)
        {
        }

        public override UnitConversion<TValue> GetConversion(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            UnitConversion<TValue> conversion = GetCachedConversion(fromUnit, toUnit);
            if (conversion == null)
            {
                conversion = base.GetConversion(fromUnit, toUnit);
                if (conversion != null)
                {
                    CacheConversion(fromUnit, toUnit, conversion);
                }
            }

            // TODO: Think over base-to-base conversion resolver

            return conversion;
        }

        public TValue Convert(IUnit fromUnit, IUnit toUnit, TValue value)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            if (fromUnit.Equals(toUnit))
            {
                // No conversion needed
                return value;
            }

            UnitConversion<TValue> conversion = GetConversion(fromUnit, toUnit);
            if (conversion == null)
            {
                throw new InvalidOperationException();
            }

            return conversion(fromUnit, toUnit, value);
        }

        private UnitConversion<TValue> GetCachedConversion(IUnit fromUnit, IUnit toUnit)
        {
            if (cachedConvertions.Contains(fromUnit, toUnit))
            {
                return cachedConvertions.GetConversion(fromUnit, toUnit);
            }

            return null;
        }

        private void CacheConversion(IUnit fromUnit, IUnit toUnit, UnitConversion<TValue> conversion)
        {
            cachedConvertions.Add(fromUnit, toUnit, conversion);
        }
    }
}