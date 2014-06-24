using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Relations;

namespace opt.Core.Tests.Relations
{
    [TestClass]
    public class InequalityRelationTests
    {
        [TestMethod]
        public void Iterate()
        {
            int counter = 0;
            foreach (IRelation rel in InequalityRelation.AllRelations())
            {
                Assert.IsNotNull(rel);
                Assert.AreEqual(typeof(InequalityRelation), rel.GetType());
                counter++;
            }

            Assert.AreEqual<int>(6, counter);
        }
    }
}