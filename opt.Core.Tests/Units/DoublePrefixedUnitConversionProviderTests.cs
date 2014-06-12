using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class DoublePrefixedUnitConversionProviderTests
    {
        private IUnit metre;
        private IPrefixedUnit centimetre;
        private IPrefixedUnit kilometre;
        private IUnit kilogram;

        [TestInitialize]
        public void Initialize()
        {
            metre = new Unit("metre", "m");
            centimetre = new PrefixedUnit("centimetre", "cm", metre, 0.01);
            kilometre = new PrefixedUnit("kilometer", "km", metre, 1000.0);
            kilogram = new Unit("kilogram", "kg");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoNullFrom()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            prov.GetConversion(null, metre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoNullTo()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            prov.GetConversion(centimetre, null);
        }

        [TestMethod]
        public void UnrelatedUnits()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(metre, kilogram);

            Assert.IsNull(conv);
        }

        [TestMethod]
        public void ConvertLesserToBase()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(centimetre, metre);

            Assert.IsNotNull(conv);

            double result = conv(centimetre, metre, 10);
            Assert.IsTrue(Math.Abs(result - 0.1) < double.Epsilon);
        }

        [TestMethod]
        public void ConvertGreaterToBase()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(kilometre, metre);

            Assert.IsNotNull(conv);

            double result = conv(kilometre, metre, 10);
            Assert.IsTrue(Math.Abs(result - 10000.0) < double.Epsilon);
        }

        [TestMethod]
        public void ConvertFromBaseToLesser()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(metre, centimetre);

            Assert.IsNotNull(conv);

            double result = conv(metre, centimetre, 1.0);
            Assert.IsTrue(Math.Abs(result - 100.0) < double.Epsilon);
        }

        [TestMethod]
        public void ConvertFromBaseToGreater()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(metre, kilometre);

            Assert.IsNotNull(conv);

            double result = conv(metre, kilometre, 100);
            Assert.IsTrue(Math.Abs(result - 0.1) < double.Epsilon);
        }

        [TestMethod]
        public void ConvertFromLesserPrefixedToGreaterPrefixed()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(centimetre, kilometre);

            Assert.IsNotNull(conv);

            double result = conv(centimetre, kilometre, 100);
            Assert.IsTrue(Math.Abs(result - 0.001) < double.Epsilon);
        }

        [TestMethod]
        public void ConvertFromGreaterPrefixedToLesserPrefixed()
        {
            DoublePrefixedUnitConversionProvider prov = new DoublePrefixedUnitConversionProvider();
            UnitConversion<double> conv = prov.GetConversion(kilometre, centimetre);

            Assert.IsNotNull(conv);

            double result = conv(kilometre, centimetre, 1);
            Assert.IsTrue(Math.Abs(result - 100000.0) < double.Epsilon);
        }
    }
}
