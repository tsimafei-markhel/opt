using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.DataModel.New;

namespace opt.Core.Tests
{
    [TestClass]
    public class SortableRealTests
    {
        [TestMethod]
        public void Sort_PositiveNumbers()
        {
            SortableReal sr0 = new SortableReal(0, 10.8);
            SortableReal sr1 = new SortableReal(1, 2.66);
            SortableReal sr2 = new SortableReal(2, 6.09);

            List<SortableReal> list = new List<SortableReal>(3);
            list.Add(sr0);
            list.Add(sr1);
            list.Add(sr2);

            list.Sort();

            Assert.AreEqual(list[0].Id, sr1.Id);
            Assert.AreEqual(list[1].Id, sr2.Id);
            Assert.AreEqual(list[2].Id, sr0.Id);
        }

        [TestMethod]
        public void Sort_NegativeNumbers()
        {
            SortableReal sr0 = new SortableReal(0, -10.8);
            SortableReal sr1 = new SortableReal(1, -2.66);
            SortableReal sr2 = new SortableReal(2, -6.09);

            List<SortableReal> list = new List<SortableReal>(3);
            list.Add(sr0);
            list.Add(sr1);
            list.Add(sr2);

            list.Sort();

            Assert.AreEqual(list[0].Id, sr0.Id);
            Assert.AreEqual(list[1].Id, sr2.Id);
            Assert.AreEqual(list[2].Id, sr1.Id);
        }

        [TestMethod]
        public void Sort_MixedNumbers()
        {
            SortableReal sr0 = new SortableReal(0, -10.8);
            SortableReal sr1 = new SortableReal(1, 2.66);
            SortableReal sr2 = new SortableReal(2, -6.09);
            SortableReal sr3 = new SortableReal(3, 5.78);

            List<SortableReal> list = new List<SortableReal>(4);
            list.Add(sr0);
            list.Add(sr1);
            list.Add(sr2);
            list.Add(sr3);

            list.Sort();

            Assert.AreEqual(list[0].Id, sr0.Id);
            Assert.AreEqual(list[1].Id, sr2.Id);
            Assert.AreEqual(list[2].Id, sr1.Id);
            Assert.AreEqual(list[3].Id, sr3.Id);
        }

        [TestMethod]
        public void Sort_MixedNumbersAndZero()
        {
            SortableReal sr0 = new SortableReal(0, -10.8);
            SortableReal sr1 = new SortableReal(1, 2.66);
            SortableReal sr2 = new SortableReal(2, -6.09);
            SortableReal sr3 = new SortableReal(3, 0.0);
            SortableReal sr4 = new SortableReal(4, 5.78);

            List<SortableReal> list = new List<SortableReal>(5);
            list.Add(sr0);
            list.Add(sr1);
            list.Add(sr2);
            list.Add(sr3);
            list.Add(sr4);

            list.Sort();

            Assert.AreEqual(list[0].Id, sr0.Id);
            Assert.AreEqual(list[1].Id, sr2.Id);
            Assert.AreEqual(list[2].Id, sr3.Id);
            Assert.AreEqual(list[3].Id, sr1.Id);
            Assert.AreEqual(list[4].Id, sr4.Id);
        }

        [TestMethod]
        public void Sort_MixedNumbersAndNan()
        {
            SortableReal sr0 = new SortableReal(0, -10.8);
            SortableReal sr1 = new SortableReal(1, 2.66);
            SortableReal sr2 = new SortableReal(2, 0.0);
            SortableReal sr3 = new SortableReal(3, Real.NaN);
            SortableReal sr4 = new SortableReal(4, 5.78);

            List<SortableReal> list = new List<SortableReal>(5);
            list.Add(sr0);
            list.Add(sr1);
            list.Add(sr2);
            list.Add(sr3);
            list.Add(sr4);

            list.Sort();

            Assert.AreEqual(list[0].Id, sr3.Id);
            Assert.AreEqual(list[1].Id, sr0.Id);
            Assert.AreEqual(list[2].Id, sr2.Id);
            Assert.AreEqual(list[3].Id, sr1.Id);
            Assert.AreEqual(list[4].Id, sr4.Id);
        }
    }
}