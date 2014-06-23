using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class MeasurableUnitConversionProviderBaseTests
    {
        class FakeMeasurableUnitConversionProvider : MeasurableUnitConversionProviderBase<double>
        {
            public FakeMeasurableUnitConversionProvider(IUnitConverter<double> valueConverter) :
                base(valueConverter)
            {
            }

            public override IMeasurable<double> Convert(IUnit fromUnit, IUnit toUnit, IMeasurable<double> value)
            {
                double conversionResult = ValueConverter.Convert(value.Unit, toUnit, value.Value);
                return new DoubleMeasurable(toUnit, conversionResult);
            }
        }

        class FakeUnitConverter : IUnitConverter<double>
        {
            // Metre to Kilometre
            public double Convert(IUnit fromUnit, IUnit toUnit, double value)
            {
                return value / 1000.0;
            }
        }

        private IUnit metre;
        private IUnit kilometre;

        [TestInitialize]
        public void Initialize()
        {
            metre = new Unit("metre", "m");
            kilometre = new Unit("kilometre", "km");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullConverter()
        {
            FakeMeasurableUnitConversionProvider prov = new FakeMeasurableUnitConversionProvider(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNullFrom()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            FakeMeasurableUnitConversionProvider prov = new FakeMeasurableUnitConversionProvider(conv);

            prov.GetConversion(null, kilometre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNullTo()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            FakeMeasurableUnitConversionProvider prov = new FakeMeasurableUnitConversionProvider(conv);

            prov.GetConversion(metre, null);
        }

        [TestMethod]
        public void GetConversion()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            FakeMeasurableUnitConversionProvider prov = new FakeMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);
            Assert.AreEqual<UnitConversion<IMeasurable<double>>>(prov.Convert, conversion);
        }
    }
}