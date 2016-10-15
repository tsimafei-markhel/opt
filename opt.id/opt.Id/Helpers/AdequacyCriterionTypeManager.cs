using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using opt.DataModel;

namespace opt.Helpers
{
    public static class AdequacyCriterionTypeManager
    {
        // TODO: resources
        public static string GetFriendlyName(AdequacyCriterionType value)
        {
            // In case of localization replace literals with resources
            switch (value)
            {
                case AdequacyCriterionType.UserDefined:
                    return "";

                case AdequacyCriterionType.DifferenceInSquare:
                    return "Разница в квадрате";

                case AdequacyCriterionType.AbsoluteDifference:
                    return "Разница по модулю";

                case AdequacyCriterionType.AbsoluteDifferenceNormalized:
                    return "Нормализованная разница по модулю";

                default:
                    throw new ArgumentException("Unknown value: " + value.ToString());
            }
        }

        public static Bitmap GetImage(AdequacyCriterionType value)
        {
            switch (value)
            {
                case AdequacyCriterionType.UserDefined:
                    return new Bitmap(0, 0);

                case AdequacyCriterionType.DifferenceInSquare:
                    return new Bitmap(Properties.Resources.DifferenceInSquare);

                case AdequacyCriterionType.AbsoluteDifference:
                    return new Bitmap(Properties.Resources.AbsoluteDifference);

                case AdequacyCriterionType.AbsoluteDifferenceNormalized:
                    return new Bitmap(Properties.Resources.AbsoluteDifferenceNormalized);

                default:
                    throw new ArgumentException("Unknown value: " + value.ToString());
            }
        }

        public static List<string> GetCriterionTypeNames()
        {
            List<string> names = new List<string>();

            names.Add(GetFriendlyName(AdequacyCriterionType.DifferenceInSquare));
            names.Add(GetFriendlyName(AdequacyCriterionType.AbsoluteDifference));
            names.Add(GetFriendlyName(AdequacyCriterionType.AbsoluteDifferenceNormalized));

            return names;
        }

        public static AdequacyCriterionType ParseName(string typeName)
        {
            switch (typeName)
            {
                case "":
                    return AdequacyCriterionType.UserDefined;

                case "Разница в квадрате":
                    return AdequacyCriterionType.DifferenceInSquare;

                case "Разница по модулю":
                    return AdequacyCriterionType.AbsoluteDifference;

                case "Нормализованная разница по модулю":
                    return AdequacyCriterionType.AbsoluteDifferenceNormalized;

                default:
                    throw new ArgumentException("Unknown value: " + typeName.ToString());
            }
        }
    }
}