using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace opt.Core.Tests
{
    [TestClass]
    public class RealTests
    {
        [TestMethod]
        public void Creation_NotNull()
        {
            Real r = new Real();
            Assert.IsNotNull(r);
        }

        [TestMethod]
        public void Arithmetics_Addition_BinaryOperator()
        {
            Real r1 = 5.0;
            Real r2 = 6.0;

            Real r3 = r1 + r2;

            Assert.AreEqual<Real>(11.0, r3);
        }

        [TestMethod]
        public void Arithmetics_Addition_UnaryOperator()
        {
            Real r1 = 5.0;
            r1 += 6.0;

            Assert.AreEqual<Real>(11.0, r1);
        }

        [TestMethod]
        public void Arithmetics_Substraction_BinaryOperator()
        {
            Real r1 = 5.0;
            Real r2 = 6.0;

            Real r3 = r1 - r2;

            Assert.AreEqual<Real>(-1.0, r3);
        }

        [TestMethod]
        public void Arithmetics_Substraction_UnaryOperator()
        {
            Real r1 = 5.0;
            r1 -= 6.0;

            Assert.AreEqual<Real>(-1.0, r1);
        }

        [TestMethod]
        public void Arithmetics_Multiplication_BinaryOperator()
        {
            Real r1 = 5.0;
            Real r2 = 6.0;

            Real r3 = r1 * r2;

            Assert.AreEqual<Real>(30.0, r3);
        }

        [TestMethod]
        public void Arithmetics_Multiplication_UnaryOperator()
        {
            Real r1 = 5.0;
            r1 *= 6.0;

            Assert.AreEqual<Real>(30.0, r1);
        }

        [TestMethod]
        public void Arithmetics_Division_BinaryOperator()
        {
            Real r1 = 10.0;
            Real r2 = 2.0;

            Real r3 = r1 / r2;

            Assert.AreEqual<Real>(5.0, r3);
        }

        [TestMethod]
        public void Arithmetics_Division_UnaryOperator()
        {
            Real r1 = 10.0;
            r1 /= 2.0;

            Assert.AreEqual<Real>(5.0, r1);
        }

        [TestMethod]
        public void Comparison_Equals_LessThanEpsilon()
        {
            Real r1 = 10.0;
            Real r2 = r1 + Real.Epsilon / 2.0;

            Assert.AreEqual(true, r1 == r2);
        }

        [TestMethod]
        public void Comparison_Equals_OneMillionth()
        {
            Real r1 = 10.0;
            Real r2 = r1 + 0.000001;

            Assert.AreNotEqual(true, r1 == r2);
        }

        [TestMethod]
        public void Comparison_Equals_Equal()
        {
            Real r1 = 10.0;
            Real r2 = 10.0;

            Assert.AreEqual(true, r1 == r2);
        }

        [TestMethod]
        public void Comparison_Less_Negative_EqualPositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 10.0;

            Assert.AreNotEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_Less_Negative_EqualNegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -10.0;

            Assert.AreNotEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_Less_Positive_PositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 11.0;

            Assert.AreEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_Less_Negative_PositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 9.0;

            Assert.AreNotEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_Less_Positive_NegativeValues()
        {
            Real r1 = -11.0;
            Real r2 = -10.0;

            Assert.AreEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_Less_Negative_NegativeValues()
        {
            Real r1 = -9.0;
            Real r2 = -10.0;

            Assert.AreNotEqual(true, r1 < r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Positive_EqualPositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 10.0;

            Assert.AreEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Positive_EqualNegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -10.0;

            Assert.AreEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Positive_PositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 11.0;

            Assert.AreEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Negative_PositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 9.0;

            Assert.AreNotEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Positive_NegativeValues()
        {
            Real r1 = -11.0;
            Real r2 = -10.0;

            Assert.AreEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_LessOrEqual_Negative_NegativeValues()
        {
            Real r1 = -9.0;
            Real r2 = -10.0;

            Assert.AreNotEqual(true, r1 <= r2);
        }

        [TestMethod]
        public void Comparison_Greater_Negative_EqualPositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 10.0;

            Assert.AreNotEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_Greater_Negative_EqualNegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -10.0;

            Assert.AreNotEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_Greater_Positive_PositiveValues()
        {
            Real r1 = 11.0;
            Real r2 = 10.0;

            Assert.AreEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_Greater_Positive_NegativeValues()
        {
            Real r1 = -9.0;
            Real r2 = -10.0;

            Assert.AreEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_Greater_Negative_PositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 11.0;

            Assert.AreNotEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_Greater_Negative_NegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -9.0;

            Assert.AreNotEqual(true, r1 > r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Positive_EqualPositiveValues()
        {
            Real r1 = 10.0;
            Real r2 = 10.0;

            Assert.AreEqual(true, r1 >= r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Positive_EqualNegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -10.0;

            Assert.AreEqual(true, r1 >= r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Positive_PositiveValues()
        {
            Real r1 = 11.0;
            Real r2 = 10.0;

            Assert.AreEqual(true, r1 >= r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Negative_PositiveValues()
        {
            Real r1 = 9.0;
            Real r2 = 10.0;

            Assert.AreNotEqual(true, r1 >= r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Positive_NegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -11.0;

            Assert.AreEqual(true, r1 >= r2);
        }

        [TestMethod]
        public void Comparison_GreaterOrEqual_Negative_NegativeValues()
        {
            Real r1 = -10.0;
            Real r2 = -9.0;

            Assert.AreNotEqual(true, r1 >= r2);
        }

    }
}