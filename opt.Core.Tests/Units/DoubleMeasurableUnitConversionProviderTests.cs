using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class DoubleMeasurableUnitConversionProviderTests
    {
        class FakeUnitConverter : IUnitConverter<double>
        {
            // Metre to Kilometre
            public double Convert(IUnit fromUnit, IUnit toUnit, double value)
            {
                return value / 1000.0;
            }
        }

        class FakeMeasurable : IMeasurable<double>
        {
            public IUnit Unit { get; private set; }
            public double Value { get; set; }

            public FakeMeasurable(IUnit unit, double value)
            {
                Unit = unit;
                Value = value;
            }

            public int CompareTo(IMeasurable<double> other)
            {
                throw new NotImplementedException();
            }

            public bool Equals(IMeasurable<double> other)
            {
                throw new NotImplementedException();
            }
        }

        private IUnit metre;
        private IUnit kilometre;
        private IMeasurable<double> measurableToConvert;

        [TestInitialize]
        public void Initialize()
        {
            metre = new Unit("metre", "m");
            kilometre = new Unit("kilometre", "km");
            measurableToConvert = new FakeMeasurable(metre, 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullConverter()
        {
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNullFrom()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            prov.GetConversion(null, kilometre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNullTo()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            prov.GetConversion(metre, null);
        }

        [TestMethod]
        public void GetConversion()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);
            Assert.AreEqual<UnitConversion<IMeasurable<double>>>(prov.Convert, conversion);
        }

        [TestMethod]
        public void ConvertNullFrom()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);

            // Null fromUnit is fine, real 'from unit' is taken from the argument
            IMeasurable<double> result = conversion(null, kilometre, measurableToConvert);
            Assert.IsNotNull(result);
            Assert.AreEqual<IUnit>(kilometre, result.Unit);
            Assert.IsTrue(Math.Abs(result.Value - 0.001) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullTo()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);
            conversion(metre, null, measurableToConvert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullValue()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);
            conversion(metre, kilometre, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullMeasurableUnit()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);
            conversion(metre, kilometre, null);
        }

        [TestMethod]
        public void Convert()
        {
            FakeUnitConverter conv = new FakeUnitConverter();
            DoubleMeasurableUnitConversionProvider prov = new DoubleMeasurableUnitConversionProvider(conv);

            UnitConversion<IMeasurable<double>> conversion = prov.GetConversion(metre, kilometre);

            IMeasurable<double> result = conversion(metre, kilometre, measurableToConvert);
            Assert.IsNotNull(result);
            Assert.AreEqual<IUnit>(kilometre, result.Unit);
            Assert.IsTrue(Math.Abs(result.Value - 0.001) < double.Epsilon);
        }
    }
}