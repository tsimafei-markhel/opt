using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using opt.Units;

namespace Units
{
    public static class XmlUnitLoader
    {
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
            XElement unitsEl = documentRoot.Elements(XName.Get("units", string.Empty)).FirstOrDefault();
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
            string unitName = (string)unitEl.Attribute(XName.Get("name", string.Empty));
            string unitSymbol = (string)unitEl.Attribute(XName.Get("symbol", string.Empty));
            bool addStandardPrefixes = (bool)unitEl.Attribute(XName.Get("addStandardPrefixes", string.Empty));

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
            IEnumerable<XElement> customPrefixEls = unitEl.Elements(XName.Get("prefixed", string.Empty));
            foreach (XElement customPrefixEl in customPrefixEls)
            {
                double multiplier = (double)customPrefixEl.Attribute(XName.Get("multiplier", string.Empty));
                string name = (string)customPrefixEl.Attribute(XName.Get("name", string.Empty));
                string symbol = (string)customPrefixEl.Attribute(XName.Get("symbol", string.Empty));

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
            XElement standardPrefixesEl = documentRoot.Elements(XName.Get("standardPrefixes", string.Empty)).FirstOrDefault();
            if (standardPrefixesEl == null)
            {
                throw new InvalidOperationException("No <standardPrefixes> element.");
            }

            List<StandardPrefix> result = new List<StandardPrefix>(standardPrefixesEl.Elements().Count());
            foreach (XElement prefixEl in standardPrefixesEl.Elements())
            {
                StandardPrefix prefix = new StandardPrefix()
                {
                    Multiplier = (double)prefixEl.Attribute(XName.Get("multiplier", string.Empty)),
                    NamePrefix = (string)prefixEl.Attribute(XName.Get("namePrefix", string.Empty)),
                    SymbolPrefix = (string)prefixEl.Attribute(XName.Get("symbolPrefix", string.Empty))
                };

                result.Add(prefix);
            }

            return result;
        }
    }
}