using System;

namespace opt.Units
{
    public abstract class MeasurableUnitConversionProviderBase<TValue> : IUnitConversionProvider<IMeasurable<TValue>>
    {
        protected IUnitConverter<TValue> ValueConverter { get; private set; }

        protected MeasurableUnitConversionProviderBase(IUnitConverter<TValue> valueConverter)
        {
            if (valueConverter == null)
            {
                throw new ArgumentNullException("valueConverter");
            }

            ValueConverter = valueConverter;
        }

        public abstract IMeasurable<TValue> Convert(IUnit fromUnit, IUnit toUnit, IMeasurable<TValue> value);

        public virtual UnitConversion<IMeasurable<TValue>> GetConversion(IUnit fromUnit, IUnit toUnit)
        {
            if (fromUnit == null)
            {
                throw new ArgumentNullException("fromUnit");
            }

            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            return Convert;
        }
    }
}