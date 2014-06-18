using System;
using System.Collections.Generic;

namespace opt.Units
{
    public class AggregateUnitConversionProvider<TValue> : IUnitConversionProvider<TValue>
    {
        private IEnumerable<IUnitConversionProvider<TValue>> providers = new List<IUnitConversionProvider<TValue>>();

        public AggregateUnitConversionProvider(params IUnitConversionProvider<TValue>[] userProviders)
        {
            if (userProviders == null || userProviders.GetLength(0) == 0)
            {
                throw new ArgumentNullException("userProviders");
            }

            List<IUnitConversionProvider<TValue>> registeredProviders = new List<IUnitConversionProvider<TValue>>();
            foreach (IUnitConversionProvider<TValue> userProvider in userProviders)
            {
                if (userProvider != null && !registeredProviders.Contains(userProvider))
                {
                    registeredProviders.Add(userProvider);
                }
            }

            providers = registeredProviders;
        }

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

            UnitConversion<TValue> conversion = null;
            foreach (IUnitConversionProvider<TValue> provider in providers)
            {
                conversion = provider.GetConversion(fromUnit, toUnit);
                if (conversion != null)
                {
                    break;
                }
            }

            return conversion;
        }
    }
}