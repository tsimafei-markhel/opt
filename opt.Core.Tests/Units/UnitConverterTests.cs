using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class UnitConverterTests
    {
        /*private UnitConversionDictionary<double> userProvider;
        private DoublePrefixedUnitConversionProvider prefixedProvider;

        private IUnit metre;
        private IPrefixedUnit centimetre;
        private IPrefixedUnit kilometre;
        private IUnit kilogram;
        private IUnit pound;

        private readonly UnitConversion<double> kgToLb = (f, t, v) =>
        {
            return v * 2.20462;
        };

        private readonly UnitConversion<double> lbToKg = (f, t, v) =>
        {
            return v / 2.20462;
        };

        [TestInitialize]
        public void Initialize()
        {
            prefixedProvider = new DoublePrefixedUnitConversionProvider();
            userProvider = new UnitConversionDictionary<double>();

            metre = new Unit("metre", "m");
            centimetre = new PrefixedUnit("centimetre", "cm", metre, 0.01);
            kilometre = new PrefixedUnit("kilometer", "km", metre, 1000.0);
            kilogram = new Unit("kilogram", "kg");
            pound = new Unit("pound", "lb");

            userProvider.Add(kilogram, pound, kgToLb);
            userProvider.Add(pound, kilogram, lbToKg);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyConstructor()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNulls()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(null);
        }

        [TestMethod]
        public void PrefixedOnlyValidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(prefixedProvider);
            double result = agg.Convert(centimetre, metre, 10.0);

            Assert.IsTrue(Math.Abs(result - 0.1) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PrefixedOnlyInvalidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(prefixedProvider);
            double result = agg.Convert(kilogram, pound, 10.0);
        }

        [TestMethod]
        public void UserOnlyValidConversion()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider);
            double result = agg.Convert(pound, kilogram, 1.0);

            Assert.IsTrue(Math.Abs(Math.Round(result, 5) - 0.45359) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UserOnlyInvalidConversion()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider);
            double result = agg.Convert(centimetre, metre, 10);
        }

        [TestMethod]
        public void BothValidConversions()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);

            double result1 = agg.Convert(pound, kilogram, 1.0);
            Assert.IsTrue(Math.Abs(Math.Round(result1, 5) - 0.45359) < double.Epsilon);

            double result2 = agg.Convert(centimetre, metre, 10.0);
            Assert.IsTrue(Math.Abs(result2 - 0.1) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BothInvalidConversion()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);
            double result = agg.Convert(kilogram, metre, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoFrom()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(null, kilogram);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoTo()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(kilogram, null);
        }

        [TestMethod]
        public void GetConversionContained()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(pound, kilogram);

            Assert.IsNotNull(conversion);
            Assert.AreEqual<UnitConversion<double>>(lbToKg, conversion);
        }

        [TestMethod]
        public void GetConversioNotContained()
        {
            AggregateUnitConverter<double> agg = new AggregateUnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(centimetre, kilogram);

            Assert.IsNull(conversion);
        }*/
    }
}