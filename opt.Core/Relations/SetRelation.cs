using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace opt.Relations
{
    public sealed class SetRelation : RelationBase
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation Member = new SetRelation("Member", "∈");

        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Type is immutable")]
        public static readonly IRelation NotMember = new SetRelation("NotMember", "∉");

        private static readonly IEnumerable<IRelation> allRelations = new List<IRelation>()
        {
            Member,
            NotMember
        };

        private SetRelation(string name, string symbol) :
            base(name, symbol)
        {
        }

        public static IEnumerable<IRelation> AllRelations()
        {
            return allRelations;
        }
    }
}