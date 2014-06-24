using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace opt.Relations
{
    public sealed class InequalityRelation : RelationBase
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation Equal = new InequalityRelation("Equal", "=");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation NotEqual = new InequalityRelation("NotEqual", "≠");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation Less = new InequalityRelation("Less", "<");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "LessOr",
            Justification = "Intended naming")]
        public static readonly IRelation LessOrEqual = new InequalityRelation("LessOrEqual", "≤");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation Greater = new InequalityRelation("Greater", ">");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation GreaterOrEqual = new InequalityRelation("GreaterOrEqual", "≥");

        private static readonly IEnumerable<IRelation> allRelations = new List<IRelation>()
        {
            Equal,
            NotEqual,
            Less,
            LessOrEqual,
            Greater,
            GreaterOrEqual
        };

        private InequalityRelation(string name, string symbol) :
            base(name, symbol)
        {
        }

        public static IEnumerable<IRelation> AllRelations()
        {
            return allRelations;
        }
    }
}