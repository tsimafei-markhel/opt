using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.Core.Tests
{
    [TestClass]
    public class AggregateComparerTests
    {
        [TestMethod]
        public void Adding_Positive_OneComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();

            comparer.AddComparer(realComparer);
        }

        [TestMethod]
        public void Adding_Positive_TwoComparers()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(realComparer);
            comparer.AddComparer(setComparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Adding_Negative_NullComparer()
        {
            AggregateComparer comparer = new AggregateComparer();

            comparer.AddComparer<Relation, Real, Real>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Adding_Negative_ExistingComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();

            comparer.AddComparer(realComparer);
            comparer.AddComparer(realComparer);
        }

        [TestMethod]
        public void Removing_Positive_OneComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();

            comparer.AddComparer(realComparer);

            comparer.RemoveComparer(typeof(Relation));
        }

        [TestMethod]
        public void Removing_Positive_TwoComparers()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(realComparer);
            comparer.AddComparer(setComparer);

            comparer.RemoveComparer(typeof(Relation));
            comparer.RemoveComparer(typeof(SetRelation));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Removing_Negative_NonExistingComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();

            comparer.AddComparer(realComparer);

            comparer.RemoveComparer(typeof(SetRelation));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Removing_Negative_Null()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();

            comparer.AddComparer(realComparer);

            comparer.RemoveComparer(null);
        }

        [TestMethod]
        public void Contains_Positive_Existing()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(realComparer);
            comparer.AddComparer(setComparer);

            Assert.IsTrue(comparer.ContainsComparer(typeof(Relation)));
        }

        [TestMethod]
        public void Contains_Positive_NonExisting()
        {
            AggregateComparer comparer = new AggregateComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(setComparer);

            Assert.IsFalse(comparer.ContainsComparer(typeof(Relation)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Contains_Negative_Null()
        {
            AggregateComparer comparer = new AggregateComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(setComparer);

            Assert.IsFalse(comparer.ContainsComparer(null));
        }

        [TestMethod]
        public void Comparison_Positive_1()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(realComparer);
            comparer.AddComparer(setComparer);

            Assert.IsTrue(comparer.Compare(Relation.Equal, (Real)10.0, (Real)10.0));
        }

        [TestMethod]
        public void Comparison_Positive_2()
        {
            AggregateComparer comparer = new AggregateComparer();
            RealRelationComparer realComparer = new RealRelationComparer();
            SetRelationComparer setComparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 10.0, 0.0, -7.8 };

            comparer.AddComparer(realComparer);
            comparer.AddComparer(setComparer);

            Assert.IsTrue(comparer.Compare(SetRelation.Contained, (Real)0.0, (ISet<Real>)set));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Comparison_Negative_NonExistingComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            SetRelationComparer setComparer = new SetRelationComparer();

            comparer.AddComparer(setComparer);

            comparer.Compare(Relation.Equal, 10.0, 10.0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void Comparison_Negative_InvalidComparer()
        {
            AggregateComparer comparer = new AggregateComparer();
            SetRelationComparer setComparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 10.0, 0.0, -7.8 };

            comparer.AddComparer(setComparer);

            comparer.Compare(SetRelation.Contained, "invalid_type_variable", set);
        }
    }
}