using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Helpers
{
    /// <summary>
    /// Contains helper routines for transforming enum values to human-friendly strings and vice versa
    /// </summary>
    public static class RelationManager
    {
        /// <summary>
        /// Gets human-friendly string from <see cref="Relation"/> value
        /// </summary>
        /// <param name="relation"><see cref="Relation"/> value to be transformed to human-friendly string</param>
        /// <returns>Human-friendly string that corresponds to <paramref name="relation"/></returns>
        /// <exception cref="ArgumentException">If passed <paramref name="relation"/> is not supported by this method</exception>
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
                    throw new ArgumentException("Relation '" + relation + "' is not supported", "relation");
            }
        }

        /// <summary>
        /// Enlists all human-friendly names of the <see cref="Relation"/> members
        /// </summary>
        /// <returns>List of all human-friendly names of the <see cref="Relation"/> members</returns>
        public static List<string> GetRelationNames()
        {
            List<string> result = new List<string>();
            foreach (Relation sign in Enum.GetValues(typeof(Relation)))
            {
                result.Add(GetRelationName(sign));
            }

            return result;
        }

        /// <summary>
        /// Converts human-friendly name of the <see cref="Relation"/> member to <see cref="Relation"/> member
        /// </summary>
        /// <param name="relationName">Human-friendly name of the <see cref="Relation"/> member</param>
        /// <returns><see cref="Relation"/> member that corresponds to <paramref name="relationName"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="relationName"/> is unknown (i.e. does not
        /// belong to any member of <see cref="Relation"/> supported by this method)</exception>
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
                    throw new ArgumentException("Relation '" + relationName + "' is not supported", "relationName");
            }
        }
    }
}