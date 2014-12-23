using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.Core.Tests
{
    [TestClass]
    public class SetRelationComparerTests
    {
        [TestMethod]
        public void Comparison_Positive_Contained()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            Assert.IsTrue(comparer.Compare(SetRelation.Contained, 10.0, set));
        }

        [TestMethod]
        public void Comparison_Negative_Contained()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            Assert.IsFalse(comparer.Compare(SetRelation.Contained, 6.879, set));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Comparison_Negative_ContainedInNull()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            comparer.Compare(SetRelation.Contained, 5.4, null);
        }

        [TestMethod]
        public void Comparison_Positive_NotContained()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            Assert.IsTrue(comparer.Compare(SetRelation.NotContained, 10.706, set));
        }

        [TestMethod]
        public void Comparison_Negative_NotContained()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            Assert.IsFalse(comparer.Compare(SetRelation.NotContained, 0.0, set));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Comparison_Negative_NotContainedInNull()
        {
            SetRelationComparer comparer = new SetRelationComparer();
            HashSet<Real> set = new HashSet<Real>() { 5.4, 10.0, 0.0, -7.4, -10.0 };

            comparer.Compare(SetRelation.NotContained, 5.48, null);
        }
    }
}