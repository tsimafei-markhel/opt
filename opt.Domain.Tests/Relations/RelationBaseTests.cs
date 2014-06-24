using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Relations;

namespace opt.Domain.Tests.Relations
{
    [TestClass]
    public class RelationBaseTests
    {
        class FakeRelation : RelationBase
        {
            public FakeRelation(string name, string symbol) :
                base(name, symbol)
            {
            }
        }

        [TestMethod]
        public void Constructor()
        {
            FakeRelation rel = new FakeRelation("fake", "><");

            Assert.AreEqual<string>("fake", rel.Name);
            Assert.AreEqual<string>("><", rel.Symbol);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullName()
        {
            FakeRelation rel = new FakeRelation(null, "><");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorNullSymbol()
        {
            FakeRelation rel = new FakeRelation("fake", null);
        }
    }
}