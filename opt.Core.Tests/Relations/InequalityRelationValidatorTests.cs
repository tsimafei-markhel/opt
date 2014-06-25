using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Relations;

namespace opt.Core.Tests.Relations
{
    [TestClass]
    public class InequalityRelationValidatorTests
    {
        class FakeBinaryRelation : IRelation
        {
            public string Name { get { return "fake"; } }
            public string Symbol { get { return "><"; } }
        }

        private bool[] TestRelations(double left, double right)
        {
            bool[] results = new bool[6];
            IBinaryRelationValidator<double, double> validator = new InequalityRelationValidator<double>();

            results[0] = validator.Validate(InequalityRelation.Equal, left, right);
            results[1] = validator.Validate(InequalityRelation.NotEqual, left, right);
            results[2] = validator.Validate(InequalityRelation.Less, left, right);
            results[3] = validator.Validate(InequalityRelation.LessOrEqual, left, right);
            results[4] = validator.Validate(InequalityRelation.Greater, left, right);
            results[5] = validator.Validate(InequalityRelation.GreaterOrEqual, left, right);

            return results;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullRelation()
        {
            IBinaryRelationValidator<double, double> validator = new InequalityRelationValidator<double>();
            validator.Validate(null, 1.0, 2.0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValidateWrongRelationType()
        {
            IBinaryRelationValidator<double, double> validator = new InequalityRelationValidator<double>();
            validator.Validate(new FakeBinaryRelation(), 1.0, 2.0);
        }

        [TestMethod]
        public void ValidateEqual()
        {
            bool[] validationResults = TestRelations(1.0, 1.0);

            Assert.IsTrue(validationResults[0]);
            Assert.IsFalse(validationResults[1]);
            Assert.IsFalse(validationResults[2]);
            Assert.IsTrue(validationResults[3]);
            Assert.IsFalse(validationResults[4]);
            Assert.IsTrue(validationResults[5]);
        }

        [TestMethod]
        public void ValidateNotEqual()
        {
            bool[] validationResults = TestRelations(1.0, 2.0);

            Assert.IsFalse(validationResults[0]);
            Assert.IsTrue(validationResults[1]);
            Assert.IsTrue(validationResults[2]);
            Assert.IsTrue(validationResults[3]);
            Assert.IsFalse(validationResults[4]);
            Assert.IsFalse(validationResults[5]);
        }

        [TestMethod]
        public void ValidateLess()
        {
            bool[] validationResults = TestRelations(1.0, 2.0);

            Assert.IsFalse(validationResults[0]);
            Assert.IsTrue(validationResults[1]);
            Assert.IsTrue(validationResults[2]);
            Assert.IsTrue(validationResults[3]);
            Assert.IsFalse(validationResults[4]);
            Assert.IsFalse(validationResults[5]);
        }

        [TestMethod]
        public void ValidateLessOrEqual()
        {
            bool[] validationResults1 = TestRelations(1.0, 2.0);

            Assert.IsFalse(validationResults1[0]);
            Assert.IsTrue(validationResults1[1]);
            Assert.IsTrue(validationResults1[2]);
            Assert.IsTrue(validationResults1[3]);
            Assert.IsFalse(validationResults1[4]);
            Assert.IsFalse(validationResults1[5]);

            bool[] validationResults2 = TestRelations(1.0, 1.0);

            Assert.IsTrue(validationResults2[0]);
            Assert.IsFalse(validationResults2[1]);
            Assert.IsFalse(validationResults2[2]);
            Assert.IsTrue(validationResults2[3]);
            Assert.IsFalse(validationResults2[4]);
            Assert.IsTrue(validationResults2[5]);
        }

        [TestMethod]
        public void ValidateGreater()
        {
            bool[] validationResults = TestRelations(3.0, 2.0);

            Assert.IsFalse(validationResults[0]);
            Assert.IsTrue(validationResults[1]);
            Assert.IsFalse(validationResults[2]);
            Assert.IsFalse(validationResults[3]);
            Assert.IsTrue(validationResults[4]);
            Assert.IsTrue(validationResults[5]);
        }

        [TestMethod]
        public void ValidateGreaterOrEqual()
        {
            bool[] validationResults1 = TestRelations(3.0, 2.0);

            Assert.IsFalse(validationResults1[0]);
            Assert.IsTrue(validationResults1[1]);
            Assert.IsFalse(validationResults1[2]);
            Assert.IsFalse(validationResults1[3]);
            Assert.IsTrue(validationResults1[4]);
            Assert.IsTrue(validationResults1[5]);

            bool[] validationResults2 = TestRelations(1.0, 1.0);

            Assert.IsTrue(validationResults2[0]);
            Assert.IsFalse(validationResults2[1]);
            Assert.IsFalse(validationResults2[2]);
            Assert.IsTrue(validationResults2[3]);
            Assert.IsFalse(validationResults2[4]);
            Assert.IsTrue(validationResults2[5]);
        }
    }
}