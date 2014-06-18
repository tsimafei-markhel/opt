using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class AggregateUnitConversionProviderTests
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

            UnitConversion<double> conversion = agg.GetConversion(centimetre, metre);
            Assert.IsNotNull(conversion);

            double result = conversion(centimetre, metre, 10.0);
            Assert.IsTrue(Math.Abs(result - 0.1) < double.Epsilon);
        }

        [TestMethod]
        public void PrefixedOnlyInvalidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(prefixedProvider);

            UnitConversion<double> conversion = agg.GetConversion(kilogram, pound);
            Assert.IsNull(conversion);
        }

        [TestMethod]
        public void UserOnlyValidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider);

            UnitConversion<double> conversion = agg.GetConversion(pound, kilogram);
            Assert.IsNotNull(conversion);

            double result = conversion(pound, kilogram, 1.0);
            Assert.IsTrue(Math.Abs(Math.Round(result, 5) - 0.45359) < double.Epsilon);
        }

        [TestMethod]
        public void UserOnlyInvalidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider);

            UnitConversion<double> conversion = agg.GetConversion(centimetre, metre);
            Assert.IsNull(conversion);
        }

        [TestMethod]
        public void BothValidConversions()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider, prefixedProvider);

            UnitConversion<double> conversion1 = agg.GetConversion(pound, kilogram);
            Assert.IsNotNull(conversion1);
            Assert.AreEqual<UnitConversion<double>>(lbToKg, conversion1);

            double result = conversion1(pound, kilogram, 1.0);
            Assert.IsTrue(Math.Abs(Math.Round(result, 5) - 0.45359) < double.Epsilon);

            UnitConversion<double> conversion2 = agg.GetConversion(centimetre, metre);
            Assert.IsNotNull(conversion2);

            double result2 = conversion2(centimetre, metre, 10.0);
            Assert.IsTrue(Math.Abs(result2 - 0.1) < double.Epsilon);
        }

        [TestMethod]
        public void BothInvalidConversion()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider, prefixedProvider);

            UnitConversion<double> conversion = agg.GetConversion(kilogram, metre);
            Assert.IsNull(conversion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoFrom()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(null, kilogram);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoTo()
        {
            AggregateUnitConversionProvider<double> agg = new AggregateUnitConversionProvider<double>(userProvider, prefixedProvider);
            UnitConversion<double> conversion = agg.GetConversion(kilogram, null);
        }
    }
}