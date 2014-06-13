using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Domain.Tests.Units
{
    [TestClass]
    public class UnitCollectionTests
    {
        class FakeUnit : IUnit
        {
            public string Name { get; private set; }
            public string Symbol { get; private set; }

            public FakeUnit(string name, string symbol)
            {
                Name = name;
                Symbol = symbol;
            }
        }

        private FakeUnit unit1 = new FakeUnit("unit1", "u");
        private FakeUnit unit2 = new FakeUnit("unit2", "u_");

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void IndexerGetNonContained()
        {
            UnitCollection uc = new UnitCollection();
            IUnit u = uc["key"];
        }

        [TestMethod]
        public void IndexerGetContained()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);

            IUnit u = uc[unit1.Name];
            Assert.AreEqual<IUnit>(unit1, u);
        }

        [TestMethod]
        public void Count()
        {
            UnitCollection uc = new UnitCollection();
            Assert.AreEqual<int>(0, uc.Count);

            uc.Add(unit1);
            Assert.AreEqual<int>(1, uc.Count);
        }

        [TestMethod]
        public void IsReadOnly()
        {
            UnitCollection uc = new UnitCollection();
            Assert.IsFalse(uc.IsReadOnly);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNull()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddContained()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);
            uc.Add(unit1);
        }

        [TestMethod]
        public void Add()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);

            Assert.AreEqual<int>(1, uc.Count);
            Assert.IsTrue(uc.Contains(unit1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNull()
        {
            UnitCollection uc = new UnitCollection();
            uc.Remove(null);
        }

        [TestMethod]
        public void RemoveNotContained()
        {
            UnitCollection uc = new UnitCollection();
            bool result = uc.Remove(unit1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Remove()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);
            uc.Add(unit2);

            Assert.AreEqual<int>(2, uc.Count);
            Assert.IsTrue(uc.Contains(unit1));
            Assert.IsTrue(uc.Contains(unit2));

            bool result = uc.Remove(unit1);

            Assert.IsTrue(result);
            Assert.AreEqual<int>(1, uc.Count);
            Assert.IsTrue(uc.Contains(unit2));
            Assert.IsFalse(uc.Contains(unit1));
        }

        [TestMethod]
        public void Iterate()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);
            uc.Add(unit2);

            Assert.AreEqual<int>(2, uc.Count);
            Assert.IsTrue(uc.Contains(unit1));
            Assert.IsTrue(uc.Contains(unit2));

            int count = 0;
            foreach (IUnit unit in uc)
            {
                Assert.IsTrue(uc.Contains(unit));
                count++;
            }

            Assert.AreEqual<int>(2, count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsByNameNull()
        {
            UnitCollection uc = new UnitCollection();
            uc.Contains((string)null);
        }

        [TestMethod]
        public void ContainsByNameEmptyString()
        {
            UnitCollection uc = new UnitCollection();

            Assert.IsFalse(uc.Contains(string.Empty));
        }

        [TestMethod]
        public void ContainsByNameContained()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);

            Assert.IsTrue(uc.Contains(unit1.Name));
        }

        [TestMethod]
        public void ContainsByNameNotContained()
        {
            UnitCollection uc = new UnitCollection();
            uc.Add(unit1);

            Assert.IsFalse(uc.Contains(unit2.Name));
        }
    }
}