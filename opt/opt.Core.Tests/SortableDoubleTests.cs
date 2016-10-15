using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.DataModel;
using opt.Helpers;

// TODO: Remove these tests once opt.DataModel.New.SortableReal is reused across the solution

namespace opt.Core.Tests
{
    [TestClass]
    public class SortableDoubleTests
    {
        [TestMethod]
        public void SortPositiveNumbersAsc()
        {
            List<SortableDouble> list = new List<SortableDouble>(3);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Ascending, Value = 10.0 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Ascending, Value = 4.72 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Ascending, Value = 7.66 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 1);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 0);
        }

        [TestMethod]
        public void SortPositiveNumbersDesc()
        {
            List<SortableDouble> list = new List<SortableDouble>(3);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Descending, Value = 10.0 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Descending, Value = 4.72 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Descending, Value = 7.66 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 0);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 1);
        }

        [TestMethod]
        public void SortNegativeNumbersAsc()
        {
            List<SortableDouble> list = new List<SortableDouble>(3);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Ascending, Value = -11.0 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Ascending, Value = -5.88 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Ascending, Value = -6.77 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 0);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 1);
        }

        [TestMethod]
        public void SortNegativeNumbersDesc()
        {
            List<SortableDouble> list = new List<SortableDouble>(3);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Descending, Value = -11.0 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Descending, Value = -5.88 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Descending, Value = -6.77 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 1);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 0);
        }

        [TestMethod]
        public void SortMixedNumbersAsc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Ascending, Value = -11.0 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Ascending, Value = 4.18 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Ascending, Value = -7.19 });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Ascending, Value = 2.04 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 0);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 3);
            Assert.AreEqual(((int)list[3].Id), 1);
        }

        [TestMethod]
        public void SortMixedNumbersDesc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Descending, Value = -13.76 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Descending, Value = 5.19 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Descending, Value = -8.49 });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Descending, Value = 1.75 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 1);
            Assert.AreEqual(((int)list[1].Id), 3);
            Assert.AreEqual(((int)list[2].Id), 2);
            Assert.AreEqual(((int)list[3].Id), 0);
        }

        [TestMethod]
        public void SortMixedNumbersAndZeroAsc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Ascending, Value = -13.76 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Ascending, Value = 5.19 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Ascending, Value = 0.0 });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Ascending, Value = 1.75 });
            list.Add(new SortableDouble() { Id = 4, Direction = SortDirection.Ascending, Value = -7.16 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 0);
            Assert.AreEqual(((int)list[1].Id), 4);
            Assert.AreEqual(((int)list[2].Id), 2);
            Assert.AreEqual(((int)list[3].Id), 3);
            Assert.AreEqual(((int)list[4].Id), 1);
        }

        [TestMethod]
        public void SortMixedNumbersAndZeroDesc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Descending, Value = -18.05 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Descending, Value = -7.16 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Descending, Value = 5.99 });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Descending, Value = 0.0 });
            list.Add(new SortableDouble() { Id = 4, Direction = SortDirection.Descending, Value = 8.86 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 4);
            Assert.AreEqual(((int)list[1].Id), 2);
            Assert.AreEqual(((int)list[2].Id), 3);
            Assert.AreEqual(((int)list[3].Id), 1);
            Assert.AreEqual(((int)list[4].Id), 0);
        }

        [TestMethod]
        public void SortMixedNumbersAndNanAsc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Ascending, Value = 18.05 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Ascending, Value = -6.42 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Ascending, Value = Double.NaN });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Ascending, Value = 5.0 });
            list.Add(new SortableDouble() { Id = 4, Direction = SortDirection.Ascending, Value = -7.75 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 2);
            Assert.AreEqual(((int)list[1].Id), 4);
            Assert.AreEqual(((int)list[2].Id), 1);
            Assert.AreEqual(((int)list[3].Id), 3);
            Assert.AreEqual(((int)list[4].Id), 0);
        }

        [TestMethod]
        public void SortMixedNumbersAndNanDesc()
        {
            List<SortableDouble> list = new List<SortableDouble>(4);
            list.Add(new SortableDouble() { Id = 0, Direction = SortDirection.Descending, Value = 28.75 });
            list.Add(new SortableDouble() { Id = 1, Direction = SortDirection.Descending, Value = -5.42 });
            list.Add(new SortableDouble() { Id = 2, Direction = SortDirection.Descending, Value = Double.NaN });
            list.Add(new SortableDouble() { Id = 3, Direction = SortDirection.Descending, Value = 5.01 });
            list.Add(new SortableDouble() { Id = 4, Direction = SortDirection.Descending, Value = -3.45 });

            list.Sort();

            Assert.AreEqual(((int)list[0].Id), 0);
            Assert.AreEqual(((int)list[1].Id), 3);
            Assert.AreEqual(((int)list[2].Id), 4);
            Assert.AreEqual(((int)list[3].Id), 1);
            Assert.AreEqual(((int)list[4].Id), 2);
        }
    }
}