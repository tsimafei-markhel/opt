using System;
using System.Collections.Generic;

namespace opt.Units
{
    public class AggregateUnitConverter<TValue> : IUnitConverter<TValue>
    {
        private readonly UnitConversionDictionary<TValue> cachedConvertions = new UnitConversionDictionary<TValue>();
        private readonly List<IUnitConversionProvider<TValue>> userProviders = new List<IUnitConversionProvider<TValue>>();

        public AggregateUnitConverter(params IUnitConversionProvider<TValue>[] providers)
        {
            if (providers == null || providers.GetLength(0) == 0)
            {
                throw new ArgumentNullException("providers");
            }

            foreach (IUnitConversionProvider<TValue> provider in providers)
            {
                if (provider != null && 
                    !userProviders.Contains(provider))
                {
                    userProviders.Add(provider);
                }
            }
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

            UnitConversion<TValue> conversion = GetCachedConversion(fromUnit, toUnit);
            if (conversion == null)
            {
                conversion = GetUserConversion(fromUnit, toUnit);
            }

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

        private UnitConversion<TValue> GetUserConversion(IUnit fromUnit, IUnit toUnit)
        {
            UnitConversion<TValue> conversion = null;

            foreach (IUnitConversionProvider<TValue> userProvider in userProviders)
            {
                conversion = userProvider.GetConversion(fromUnit, toUnit);
                if (conversion != null)
                {
                    CacheConversion(fromUnit, toUnit, conversion);
                    break;
                }
            }

            return conversion;
        }
    }
}