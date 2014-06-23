using System;

namespace opt.Units
{
    public class DoubleMeasurableUnitConversionProvider : MeasurableUnitConversionProviderBase<Double>
    {
        public DoubleMeasurableUnitConversionProvider(IUnitConverter<Double> valueConverter) :
            base(valueConverter)
        {
        }

        public override IMeasurable<Double> Convert(IUnit fromUnit, IUnit toUnit, IMeasurable<Double> value)
        {
            if (toUnit == null)
            {
                throw new ArgumentNullException("toUnit");
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (value.Unit == null)
            {
                throw new InvalidOperationException();
            }

            if (value.Unit.Equals(toUnit))
            {
                return value;
            }

            double conversionResult = ValueConverter.Convert(value.Unit, toUnit, value.Value);
            return new DoubleMeasurable(toUnit, conversionResult);
        }
    }
}