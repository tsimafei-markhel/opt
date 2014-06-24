using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Relations;

namespace opt.Core.Tests.Relations
{
    [TestClass]
    public class SetRelationTests
    {
        [TestMethod]
        public void Iterate()
        {
            int counter = 0;
            foreach (IRelation rel in SetRelation.AllRelations())
            {
                Assert.IsNotNull(rel);
                Assert.AreEqual(typeof(SetRelation), rel.GetType());
                counter++;
            }

            Assert.AreEqual<int>(2, counter);
        }
    }
}