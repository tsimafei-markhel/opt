using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class UnitConverterTests
    {
        private UnitConversionDictionary<double> userProvider;
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
            UnitConverter<double> conv = new UnitConverter<double>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNulls()
        {
            UnitConverter<double> conv = new UnitConverter<double>(null);
        }

        [TestMethod]
        public void PrefixedOnlyValidConversion()
        {
            UnitConverter<double> conv = new UnitConverter<double>(prefixedProvider);
            double result = conv.Convert(centimetre, metre, 10.0);

            Assert.IsTrue(Math.Abs(result - 0.1) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PrefixedOnlyInvalidConversion()
        {
            UnitConverter<double> conv = new UnitConverter<double>(prefixedProvider);
            double result = conv.Convert(kilogram, pound, 10.0);
        }

        [TestMethod]
        public void UserOnlyValidConversion()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider);
            double result = conv.Convert(pound, kilogram, 1.0);

            Assert.IsTrue(Math.Abs(Math.Round(result, 5) - 0.45359) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UserOnlyInvalidConversion()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider);
            double result = conv.Convert(centimetre, metre, 10);
        }

        [TestMethod]
        public void BothValidConversions()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);

            double result1 = conv.Convert(pound, kilogram, 1.0);
            Assert.IsTrue(Math.Abs(Math.Round(result1, 5) - 0.45359) < double.Epsilon);

            double result2 = conv.Convert(centimetre, metre, 10.0);
            Assert.IsTrue(Math.Abs(result2 - 0.1) < double.Epsilon);
        }

        [TestMethod]
        public void ValidConversionTwoTimes()
        {
            // Once resolved, conversion is added to internal cache
            // Need to check that calling same conversion twice does not cause two adding to the cache,
            // which may lead to exception
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);

            double result1 = conv.Convert(pound, kilogram, 1.0);
            Assert.IsTrue(Math.Abs(Math.Round(result1, 5) - 0.45359) < double.Epsilon);

            double result2 = conv.Convert(pound, kilogram, 2.0);
            Assert.IsTrue(Math.Abs(result2 / result1 - 2.0) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BothInvalidConversion()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);
            double result = conv.Convert(kilogram, metre, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoFrom()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = conv.GetConversion(null, kilogram);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoTo()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = conv.GetConversion(kilogram, null);
        }

        [TestMethod]
        public void GetConversionContained()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = conv.GetConversion(pound, kilogram);

            Assert.IsNotNull(conversion);
            Assert.AreEqual<UnitConversion<double>>(lbToKg, conversion);
        }

        [TestMethod]
        public void GetConversioNotContained()
        {
            UnitConverter<double> conv = new UnitConverter<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = conv.GetConversion(centimetre, kilogram);

            Assert.IsNull(conversion);
        }
    }
}