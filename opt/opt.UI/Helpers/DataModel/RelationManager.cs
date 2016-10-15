using System;
using System.Collections.Generic;
using opt.DataModel;

// TODO: Add XML comments

namespace opt.UI.Helpers.DataModel
{
    public static class RelationManager
    {
        public static string GetRelationName(Relation relation)
        {
            switch (relation)
            {
                case Relation.Equal:
                    return "=";

                case Relation.Less:
                    return "<";

                case Relation.LessOrEqual:
                    return "≤";

                case Relation.Greater:
                    return ">";

                case Relation.GreaterOrEqual:
                    return "≥";

                case Relation.NotEqual:
                    return "≠";

                default:
                    throw new ArgumentException("Relation " + relation + " is not supported", "relation");
            }
        }

        public static List<string> GetRelationNames()
        {
            List<string> result = new List<string>();
            foreach (Relation sign in Enum.GetValues(typeof(Relation)))
            {
                result.Add(GetRelationName(sign));
            }

            return result;
        }

        public static Relation ParseName(string relationName)
        {
            switch (relationName)
            {
                case "=":
                    return Relation.Equal;

                case "<":
                    return Relation.Less;

                case "≤":
                    return Relation.LessOrEqual;

                case ">":
                    return Relation.Greater;

                case "≥":
                    return Relation.GreaterOrEqual;

                case "≠":
                    return Relation.NotEqual;

                default:
                    throw new ArgumentException("Relation " + relationName + " is not supported", "relationName");
            }
        }
    }
}