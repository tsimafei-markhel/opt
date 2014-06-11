using System;
using System.Diagnostics.CodeAnalysis;

namespace opt.Units
{
    public sealed class ArbitraryUnit : IUnit
    {
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Instance is immutable.")]
        public static readonly IUnit Instance = new ArbitraryUnit();

        public String Name
        {
            get
            {
                return string.Empty;
            }
        }

        public String Symbol
        {
            get
            {
                return string.Empty;
            }
        }

        private ArbitraryUnit()
        {
        }
    }
}