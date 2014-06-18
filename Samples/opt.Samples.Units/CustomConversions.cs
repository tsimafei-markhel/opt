using opt.Units;

namespace opt.Samples.Units
{
    // Unit conversion rules can be defined in code
    // Conversion method signature has to correspond opt.Units.UnitConversion<T> delegate

    public static class CustomConversions
    {
        public static double ParrotToBoa(IUnit fromUnit, IUnit toUnit, double value)
        {
            return value / 38.0;
        }

        public static double BoaToParrot(IUnit fromUnit, IUnit toUnit, double value)
        {
            return value * 38.0;
        }

        public static double CelsiusToKelvin(IUnit fromUnit, IUnit toUnit, double value)
        {
            return value + 273.15;
        }

        public static double KelvinToCelsius(IUnit fromUnit, IUnit toUnit, double value)
        {
            return value - 273.15;
        }
    }
}