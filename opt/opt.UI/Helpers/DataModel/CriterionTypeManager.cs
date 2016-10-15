using System;
using System.Collections.Generic;
using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class CriterionTypeManager
    {
        public static string GetCriterionTypeName(CriterionType type)
        {
            switch (type)
            {
                case CriterionType.Maximizing:
                    return "Максимизируемый критерий";

                case CriterionType.Minimizing:
                    return "Минимизируемый критерий";

                default:
                    throw new ArgumentException("Criterion type " + type + " is not supported", "type");
            }
        }

        public static List<string> GetCriterionTypeNames()
        {
            var result = new List<string>();
            foreach (CriterionType type in Enum.GetValues(typeof(CriterionType)))
            {
                result.Add(GetCriterionTypeName(type));
            }

            return result;
        }

        public static CriterionType ParseName(string typeName)
        {
            switch (typeName)
            {
                case "Максимизируемый критерий":
                    return CriterionType.Maximizing;

                case "Минимизируемый критерий":
                    return CriterionType.Minimizing;

                default:
                    throw new ArgumentException("Criterion type " + typeName + " is not supported", "typeName");
            }
        }
    }
}