using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Domain.Tests.Units
{
    [TestClass]
    public class ArbitraryUnitTests
    {
        [TestMethod]
        public void OnlyPrivateConstructors()
        {
            Type arbitraryUnitType = typeof(ArbitraryUnit);
            foreach (ConstructorInfo ctor in arbitraryUnitType.GetConstructors())
            {
                Assert.IsTrue(ctor.IsPrivate);
            }
        }

        [TestMethod]
        public void EmptyName()
        {
            IUnit arbitraryUnit = ArbitraryUnit.Instance;
            Assert.IsTrue(string.IsNullOrEmpty(arbitraryUnit.Name));
        }

        [TestMethod]
        public void EmptySymbol()
        {
            IUnit arbitraryUnit = ArbitraryUnit.Instance;
            Assert.IsTrue(string.IsNullOrEmpty(arbitraryUnit.Symbol));
        }
    }
}