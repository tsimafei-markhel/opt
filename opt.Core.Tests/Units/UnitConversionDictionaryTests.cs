using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opt.Units;

namespace opt.Core.Tests.Units
{
    [TestClass]
    public class UnitConversionDictionaryTests
    {
        private readonly IUnit from = new Unit("from", "f");
        private readonly IUnit to = new Unit("to", "t");
        private readonly UnitConversion<int> fromToConversion = (f, t, v) =>
            {
                return v * 10;
            };
        private readonly UnitConversion<int> toFromConversion = (f, t, v) =>
            {
                return v / 10;
            };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNoNullFrom()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(null, to, fromToConversion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNoNullTo()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, null, fromToConversion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNoNullConversion()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNoDuplicateConversion()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);
            dict.Add(from, to, fromToConversion);
        }

        [TestMethod]
        public void Add()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.AreEqual<UnitConversion<int>>(fromToConversion, dict[from.Name + to.Name]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNoNullFrom()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            dict.Contains(null, to);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNoNullTo()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            dict.Contains(from, null);
        }

        [TestMethod]
        public void Contains()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.IsTrue(dict.Contains(from, to));
        }

        [TestMethod]
        public void NotContains()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.IsFalse(dict.Contains(to, from));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNoNullFrom()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Remove(null, to);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNoNullTo()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Remove(to, null);
        }

        [TestMethod]
        public void RemoveContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);
            dict.Add(to, from, toFromConversion);

            Assert.AreEqual<int>(2, dict.Count);
            Assert.AreEqual<UnitConversion<int>>(fromToConversion, dict[from.Name + to.Name]);
            Assert.AreEqual<UnitConversion<int>>(toFromConversion, dict[to.Name + from.Name]);

            bool result = dict.Remove(from, to);

            Assert.IsTrue(result);
            Assert.IsFalse(dict.Contains(from, to));
            Assert.AreEqual<int>(1, dict.Count);
            Assert.AreEqual<UnitConversion<int>>(toFromConversion, dict[to.Name + from.Name]);
        }

        [TestMethod]
        public void RemoveNotContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(to, from, toFromConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.AreEqual<UnitConversion<int>>(toFromConversion, dict[to.Name + from.Name]);
            Assert.IsFalse(dict.Contains(from, to));
            Assert.IsTrue(dict.Contains(to, from));

            bool result = dict.Remove(from, to);

            Assert.IsFalse(result);
            Assert.AreEqual<int>(1, dict.Count);
            Assert.AreEqual<UnitConversion<int>>(toFromConversion, dict[to.Name + from.Name]);
            Assert.IsTrue(dict.Contains(to, from));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryGetValueNoNullFrom()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            UnitConversion<int> conversion;

            dict.TryGetValue(null, to, out conversion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryGetValueNoNullTo()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            UnitConversion<int> conversion;

            dict.TryGetValue(from, null, out conversion);
        }

        [TestMethod]
        public void TryGetValueContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.IsTrue(dict.Contains(from, to));

            UnitConversion<int> conversion;
            bool result = dict.TryGetValue(from, to, out conversion);

            Assert.IsTrue(result);
            Assert.AreEqual<UnitConversion<int>>(fromToConversion, conversion);
        }

        [TestMethod]
        public void TryGetValueNotContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.IsTrue(dict.Contains(from, to));

            UnitConversion<int> conversion;
            bool result = dict.TryGetValue(to, from, out conversion);

            Assert.IsFalse(result);
            Assert.IsNull(conversion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoNullFrom()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.GetConversion(null, to);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetConversionNoNullTo()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.GetConversion(from, null);
        }

        [TestMethod]
        public void GetConversionContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.IsTrue(dict.Contains(from, to));

            UnitConversion<int> conversion = dict.GetConversion(from, to);

            Assert.IsNotNull(conversion);
            Assert.AreEqual<UnitConversion<int>>(fromToConversion, conversion);
        }

        [TestMethod]
        public void GetConversionNotContained()
        {
            UnitConversionDictionary<int> dict = new UnitConversionDictionary<int>();
            dict.Add(from, to, fromToConversion);

            Assert.AreEqual<int>(1, dict.Count);
            Assert.IsTrue(dict.Contains(from, to));

            UnitConversion<int> conversion = dict.GetConversion(to, from);

            Assert.IsNull(conversion);
        }
    }
}