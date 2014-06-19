using System;
using System.Diagnostics.CodeAnalysis;

namespace opt.Units
{
    /// <summary>
    /// Represents unit for unitless and dimensionless measurable values
    /// </summary>
    public sealed class ArbitraryUnit : IUnit
    {
        /// <summary>
        /// Arbitrary unit instance. Use this field instead of constructing
        /// new instances of <see cref="ArbitraryUnit"/>
        /// </summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes",
            Justification = "Instance is immutable.")]
        public static readonly IUnit Instance = new ArbitraryUnit();

        /// <summary>
        /// Gets the name of unit of measurement. Returns empty string
        /// </summary>
        public String Name
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the symbol of unit of measurement. Returns empty string
        /// </summary>
        public String Symbol
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="ArbitraryUnit"/>
        /// </summary>
        /// <remarks>Use <see cref="ArbitraryUnit.Instance"/> to get the instance of
        /// <see cref="ArbitraryUnit"/></remarks>
        private ArbitraryUnit()
        {
        }
    }
}