using System;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using opt.Units;

namespace Units
{
    // Very basic class for parsing Conversions.xml
    public class XmlConversionLoader
    {
        private static class XNames
        {
            public static readonly XName AttFrom = XName.Get("from", string.Empty);
            public static readonly XName AttMultiplier = XName.Get("multiplier", string.Empty);
            public static readonly XName AttTo = XName.Get("to", string.Empty);
        }

        public static UnitConversionDictionary<double> Load(string conversionFile, UnitCollection unitProvider)
        {
            UnitConversionDictionary<double> result = null;

            using (XmlReader reader = XmlReader.Create(conversionFile))
            {
                XDocument doc = XDocument.Load(reader);
                result = LoadConversions(doc.Root, unitProvider);
            }

            return result;
        }

        private static UnitConversionDictionary<double> LoadConversions(XElement documentRoot, UnitCollection unitProvider)
        {
            UnitConversionDictionary<double> result = new UnitConversionDictionary<double>();
            foreach (XElement conversionEl in documentRoot.Elements())
            {
                string fromUnitName = (string)conversionEl.Attribute(XNames.AttFrom);
                string toUnitName = (string)conversionEl.Attribute(XNames.AttTo);
                double multiplier = Convert.ToDouble((string)conversionEl.Attribute(XNames.AttMultiplier), CultureInfo.InvariantCulture);

                IUnit fromUnit = unitProvider.Contains(fromUnitName) ? unitProvider[fromUnitName] : null;
                IUnit toUnit = unitProvider.Contains(toUnitName) ? unitProvider[toUnitName] : null;
                if (fromUnit != null && toUnit != null)
                {
                    UnitConversion<double> conversion = (f, t, v) =>
                    {
                        return v * multiplier;
                    };

                    result.Add(fromUnit, toUnit, conversion);
                }
            }

            return result;
        }

    }
}