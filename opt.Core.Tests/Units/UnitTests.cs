using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class UnitTests
    {
        class FakePrefixedUnit : IPrefixedUnit
        {
            public IUnit BaseUnit { get; private set; }
            public double Multiplier { get; private set; }
            public string Name { get; private set; }
            public string Symbol { get; private set; }

            public FakePrefixedUnit(string name, string symbol, IUnit baseUnit, double multiplier)
            {
                Name = name;
                Symbol = symbol;
                BaseUnit = baseUnit;
                Multiplier = multiplier;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptyNameAllowed()
        {
            Unit unit = new Unit(string.Empty, "some symbol");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptySymbolAllowed()
        {
            Unit unit = new Unit("some name", string.Empty);
        }

        [TestMethod]
        public void PrefixedUnitsListInitialized()
        {
            Unit unit = new Unit("some name", "some symbol");

            Assert.IsNotNull(unit.PrefixedUnits);
        }

        [TestMethod]
        public void PrefixedUnitsListEmpty()
        {
            Unit unit = new Unit("some name", "some symbol");

            Assert.AreEqual<int>(0, unit.PrefixedUnits.Count);
        }

        [TestMethod]
        public void PrefixedUnitAdded()
        {
            Unit unit = new Unit("some name", "some symbol");
            FakePrefixedUnit prefixedUnit = new FakePrefixedUnit("some prefixed unit name", "some prefixed unit symbol", unit, 1.0);
            unit.PrefixedUnits.Add(prefixedUnit);

            Assert.IsTrue(unit.PrefixedUnits.Contains(prefixedUnit));
        }
    }
}
