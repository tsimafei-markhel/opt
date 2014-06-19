using System;

namespace opt.Units
{
    /// <summary>
    /// Represents derived unit of measurement built by adding some prefix to
    /// base unit (e.g. kilometre will be prefixed unit for metre)
    /// </summary>
    public interface IPrefixedUnit : IUnit
    {
        /// <summary>
        /// Gets base unit of measurement
        /// </summary>
        IUnit BaseUnit { get; }

        /// <summary>
        /// Gets a multiplier used to convert value in base unit to value
        /// in prefixed unit (e.g. 1000.0 for kilometre if base unit is metre)
        /// </summary>
        Double Multiplier { get; }
    }
}