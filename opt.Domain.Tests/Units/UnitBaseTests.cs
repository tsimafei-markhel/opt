using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Domain.Tests.Units
{
    [TestClass]
    public class UnitBaseTests
    {
        class FakeUnit : UnitBase
        {
            public FakeUnit(string name, string symbol) :
                base(name, symbol)
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptyNameAllowed()
        {
            FakeUnit fakeUnit = new FakeUnit(string.Empty, "some symbol");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoEmptySymbolAllowed()
        {
            FakeUnit fakeUnit = new FakeUnit("some name", string.Empty);
        }

        [TestMethod]
        public void NameIsSet()
        {
            FakeUnit fakeUnit = new FakeUnit("some name", "some symbol");

            Assert.AreEqual<string>("some name", fakeUnit.Name);
        }

        [TestMethod]
        public void SymbolIsSet()
        {
            FakeUnit fakeUnit = new FakeUnit("some name", "some symbol");

            Assert.AreEqual<string>("some symbol", fakeUnit.Symbol);
        }
    }
}