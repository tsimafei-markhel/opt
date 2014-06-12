using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class PrefixedUnitTests
    {
        private Unit baseUnit = new Unit("base unit name", "base unit symbol");

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptyNameAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit(string.Empty, "some symbol", baseUnit, 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptySymbolAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", string.Empty, baseUnit, 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptyBaseUnitAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", null, 1.0);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoArbitraryBaseUnitAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", ArbitraryUnit.Instance, 1.0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoNanMultiplierAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, double.NaN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoNegativeInfinityMultiplierAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, double.NegativeInfinity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoPositiveInfinityMultiplierAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, double.PositiveInfinity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NoZeroMultiplierAllowed()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, 0.0);
        }

        [TestMethod]
        public void NameIsSet()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, 1.0);

            Assert.AreEqual<string>("some name", prefixedUnit.Name);
        }

        [TestMethod]
        public void SymbolIsSet()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, 1.0);

            Assert.AreEqual<string>("some symbol", prefixedUnit.Symbol);
        }

        [TestMethod]
        public void BaseUnitIsSet()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, 1.0);

            Assert.AreEqual<IUnit>(baseUnit, prefixedUnit.BaseUnit);
        }

        [TestMethod]
        public void MultiplierIsSet()
        {
            PrefixedUnit prefixedUnit = new PrefixedUnit("some name", "some symbol", baseUnit, 1.0);

            Assert.IsTrue(Math.Abs(prefixedUnit.Multiplier - 1.0) < double.Epsilon);
        }
    }
}