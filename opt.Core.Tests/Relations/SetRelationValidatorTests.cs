using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Relations;

namespace opt.Core.Tests.Relations
{
    [TestClass]
    public class SetRelationValidatorTests
    {
        class FakeBinaryRelation : IRelation
        {
            public string Name { get { return "fake"; } }
            public string Symbol { get { return "><"; } }
        }

        private HashSet<double> testSet = new HashSet<double>() { -10.0, 0.0, 1.0, 5.38 };

        private bool[] TestRelations(double left, ISet<double> right)
        {
            bool[] results = new bool[2];
            IBinaryRelationValidator<double, ISet<double>> validator = new SetRelationValidator<double, ISet<double>>();

            results[0] = validator.Validate(SetRelation.Member, left, right);
            results[1] = validator.Validate(SetRelation.NotMember, left, right);

            return results;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullRelation()
        {
            IBinaryRelationValidator<double, ISet<double>> validator = new SetRelationValidator<double, ISet<double>>();
            validator.Validate(null, 1.0, testSet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullSet()
        {
            IBinaryRelationValidator<double, ISet<double>> validator = new SetRelationValidator<double, ISet<double>>();
            validator.Validate(SetRelation.Member, 1.0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ValidateWrongRelationType()
        {
            IBinaryRelationValidator<double, ISet<double>> validator = new SetRelationValidator<double, ISet<double>>();
            validator.Validate(new FakeBinaryRelation(), 1.0, testSet);
        }

        [TestMethod]
        public void ValidateEmptySet()
        {
            bool[] validationResults = TestRelations(1.0, new HashSet<double>());

            Assert.IsFalse(validationResults[0]);
            Assert.IsTrue(validationResults[1]);
        }

        [TestMethod]
        public void ValidateMember()
        {
            bool[] validationResults = TestRelations(1.0, testSet);

            Assert.IsTrue(validationResults[0]);
            Assert.IsFalse(validationResults[1]);
        }

        [TestMethod]
        public void ValidateNotMember()
        {
            bool[] validationResults = TestRelations(2.0, testSet);

            Assert.IsFalse(validationResults[0]);
            Assert.IsTrue(validationResults[1]);
        }
    }
}