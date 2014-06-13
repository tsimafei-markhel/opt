using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using opt.Units;

namespace Units
{
    // Very basic class for parsing SI-Units.xml
    public static class XmlUnitLoader
    {
        private static class XNames
        {
            public static readonly XName AttAddStandardPrefixes = XName.Get("addStandardPrefixes", string.Empty);
            public static readonly XName AttMultiplier = XName.Get("multiplier", string.Empty);
            public static readonly XName AttName = XName.Get("name", string.Empty);
            public static readonly XName AttNamePrefix = XName.Get("namePrefix", string.Empty);
            public static readonly XName AttSymbol = XName.Get("symbol", string.Empty);
            public static readonly XName AttSymbolPrefix = XName.Get("symbolPrefix", string.Empty);

            public static readonly XName ElPrefixed = XName.Get("prefixed", string.Empty);
            public static readonly XName ElStandardPrefixes = XName.Get("standardPrefixes", string.Empty);
            public static readonly XName ElUnits = XName.Get("units", string.Empty);
        }

        private sealed class StandardPrefix
        {
            public double Multiplier { get; set; }
            public string NamePrefix { get; set; }
            public string SymbolPrefix { get; set; }
        }

        public static UnitCollection Load(string unitFile)
        {
            UnitCollection result = null;

            using (XmlReader reader = XmlReader.Create(unitFile))
            {
                XDocument doc = XDocument.Load(reader);
                List<StandardPrefix> standardPrefixes = LoadStandardPrefixes(doc.Root);
                result = LoadUnits(doc.Root, standardPrefixes);
            }

            return result;
        }

        private static UnitCollection LoadUnits(XElement documentRoot, List<StandardPrefix> standardPrefixes)
        {
            XElement unitsEl = documentRoot.Elements(XNames.ElUnits).FirstOrDefault();
            if (unitsEl == null)
            {
                throw new InvalidOperationException("No <units> element.");
            }

            UnitCollection result = new UnitCollection();
            foreach (XElement unitEl in unitsEl.Elements())
            {
                Unit unit = LoadUnit(unitEl, standardPrefixes);
                result.Add(unit);
            }

            return result;
        }

        private static Unit LoadUnit(XElement unitEl, List<StandardPrefix> standardPrefixes)
        {
            string unitName = (string)unitEl.Attribute(XNames.AttName);
            string unitSymbol = (string)unitEl.Attribute(XNames.AttSymbol);
            bool addStandardPrefixes = (bool)unitEl.Attribute(XNames.AttAddStandardPrefixes);

            Unit result = new Unit(unitName, unitSymbol);
            if (addStandardPrefixes)
            {
                AddStandardPrefixes(result, standardPrefixes);
            }

            TryAddCustomPrefixedUnits(result, unitEl);

            return result;
        }

        private static void TryAddCustomPrefixedUnits(Unit baseUnit, XElement unitEl)
        {
            IEnumerable<XElement> customPrefixEls = unitEl.Elements(XNames.ElPrefixed);
            foreach (XElement customPrefixEl in customPrefixEls)
            {
                double multiplier = Convert.ToDouble((string)customPrefixEl.Attribute(XNames.AttMultiplier), CultureInfo.InvariantCulture);
                string name = (string)customPrefixEl.Attribute(XNames.AttName);
                string symbol = (string)customPrefixEl.Attribute(XNames.AttSymbol);

                PrefixedUnit prefixed = new PrefixedUnit(name, symbol, baseUnit, multiplier);
                baseUnit.PrefixedUnits.Add(prefixed);
            }
        }

        private static void AddStandardPrefixes(Unit baseUnit, List<StandardPrefix> standardPrefixes)
        {
            foreach (StandardPrefix prefix in standardPrefixes)
            {
                PrefixedUnit prefixed = new PrefixedUnit(
                    prefix.NamePrefix + baseUnit.Name, prefix.SymbolPrefix + baseUnit.Symbol, baseUnit, prefix.Multiplier);
                baseUnit.PrefixedUnits.Add(prefixed);
            }
        }

        private static List<StandardPrefix> LoadStandardPrefixes(XElement documentRoot)
        {
            XElement standardPrefixesEl = documentRoot.Elements(XNames.ElStandardPrefixes).FirstOrDefault();
            if (standardPrefixesEl == null)
            {
                throw new InvalidOperationException("No <standardPrefixes> element.");
            }

            List<StandardPrefix> result = new List<StandardPrefix>(standardPrefixesEl.Elements().Count());
            foreach (XElement prefixEl in standardPrefixesEl.Elements())
            {
                StandardPrefix prefix = new StandardPrefix()
                {
                    Multiplier = Convert.ToDouble((string)prefixEl.Attribute(XNames.AttMultiplier), CultureInfo.InvariantCulture),
                    NamePrefix = (string)prefixEl.Attribute(XNames.AttNamePrefix),
                    SymbolPrefix = (string)prefixEl.Attribute(XNames.AttSymbolPrefix)
                };

                result.Add(prefix);
            }

            return result;
        }
    }
}