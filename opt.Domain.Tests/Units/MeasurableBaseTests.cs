using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Domain.Tests.Units
{
    // Not testing operators and object overrides as long as they use
    // tested IComparable<T> and IEquatable<T> implementations

    [TestClass]
    public class MeasurableBaseTests
    {
        class FakeMeasurable : MeasurableBase<double>
        {
            public FakeMeasurable(IUnit unit, double value) :
                base(unit, value)
            {
            }

            public FakeMeasurable(double value) :
                base(value)
            {
            }
        }

        class FakeUnit : UnitBase
        {
            public FakeUnit(string name, string symbol) :
                base(name, symbol)
            {
            }
        }

        private FakeUnit meter = new FakeUnit("meter", "m");
        private FakeUnit kilogram = new FakeUnit("kilogram", "kg");

        [TestMethod]
        public void ConstructorUnitValue()
        {
            FakeMeasurable m = new FakeMeasurable(meter, 1.0);

            Assert.AreEqual<IUnit>(meter, m.Unit);
            Assert.IsTrue(Math.Abs(m.Value - 1.0) < double.Epsilon);
        }

        [TestMethod]
        public void ConstructorOnlyValue()
        {
            FakeMeasurable m = new FakeMeasurable(1.0);

            Assert.AreEqual<IUnit>(ArbitraryUnit.Instance, m.Unit);
            Assert.IsTrue(Math.Abs(m.Value - 1.0) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullUnit()
        {
            FakeMeasurable m = new FakeMeasurable(null, 1.0);
        }

        [TestMethod]
        public void CompareToSameUnits()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(meter, 2.0);

            int compResult = m1.CompareTo(m2);
            Assert.IsTrue(compResult < 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CompareToDifferentUnits()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(kilogram, 2.0);

            int compResult = m1.CompareTo(m2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToNull()
        {
            FakeMeasurable m = new FakeMeasurable(meter, 1.0);
            int compResult = m.CompareTo(null);
        }

        [TestMethod]
        public void CompareToSameObjects()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = m1;

            int compResult = m1.CompareTo(m2);
            Assert.IsTrue(compResult == 0);
        }

        [TestMethod]
        public void EqualsTypedNull()
        {
            FakeMeasurable m = new FakeMeasurable(meter, 1.0);

            bool compResult = m.Equals(null);
            Assert.IsFalse(compResult);
        }

        [TestMethod]
        public void EqualsTypedSameObjects()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = m1;

            bool compResult = m1.Equals(m2);
            Assert.IsTrue(compResult);
        }

        [TestMethod]
        public void EqualsTypedSameUnitsSameValues()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(meter, 1.0);

            bool compResult = m1.Equals(m2);
            Assert.IsTrue(compResult);
        }

        [TestMethod]
        public void EqualsTypedSameUnitsDifferentValues()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(meter, 2.0);

            bool compResult = m1.Equals(m2);
            Assert.IsFalse(compResult);
        }

        [TestMethod]
        public void EqualsTypedDifferentUnitsSameValues()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(kilogram, 1.0);

            bool compResult = m1.Equals(m2);
            Assert.IsFalse(compResult);
        }

        [TestMethod]
        public void EqualsTypedDifferentUnitsDifferentValues()
        {
            FakeMeasurable m1 = new FakeMeasurable(meter, 1.0);
            FakeMeasurable m2 = new FakeMeasurable(kilogram, 2.0);

            bool compResult = m1.Equals(m2);
            Assert.IsFalse(compResult);
        }

        [TestMethod]
        public void ExplicitCastValid()
        {
            FakeMeasurable m = new FakeMeasurable(meter, 1.0);
            double mValue = (double)m;

            Assert.IsTrue(Math.Abs(m.Value - mValue) < double.Epsilon);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExplicitCastNull()
        {
            FakeMeasurable m = null;
            double mValue = (double)m;
        }
    }
}