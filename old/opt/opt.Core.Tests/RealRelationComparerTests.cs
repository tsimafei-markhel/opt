using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Comparers;
using opt.DataModel.New;

namespace opt.Core.Tests
{
    [TestClass]
    public class RealRelationComparerTests
    {
        [TestMethod]
        public void Comparison_Positive_Equal()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.Equal, 10.0, 10.0));
        }

        [TestMethod]
        public void Comparison_Negative_Equal()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.Equal, 10.0, 11.0));
        }

        [TestMethod]
        public void Comparison_Positive_NotEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.NotEqual, 10.0, 10.5));
        }

        [TestMethod]
        public void Comparison_Negative_NotEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.NotEqual, 10.0, 10.0));
        }

        [TestMethod]
        public void Comparison_Positive_Less()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.Less, -10.0, 0.5));
        }

        [TestMethod]
        public void Comparison_Negative_Less()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.Less, 10.0, 5.0));
        }

        [TestMethod]
        public void Comparison_Positive_LessOrEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.LessOrEqual, -10.0, -10.0));
        }

        [TestMethod]
        public void Comparison_Negative_LessOrEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.LessOrEqual, 10.0, 5.0));
        }

        [TestMethod]
        public void Comparison_Positive_Greater()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.Greater, 15.0, 14.7));
        }

        [TestMethod]
        public void Comparison_Negative_Greater()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.Greater, 4.0, 5.0));
        }

        [TestMethod]
        public void Comparison_Positive_GreaterOrEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsTrue(comparer.Compare(Relation.GreaterOrEqual, -10.0, -10.0));
        }

        [TestMethod]
        public void Comparison_Negative_GreaterOrEqual()
        {
            RealRelationComparer comparer = new RealRelationComparer();
            Assert.IsFalse(comparer.Compare(Relation.GreaterOrEqual, 5.0, 7.0));
        }
    }
}