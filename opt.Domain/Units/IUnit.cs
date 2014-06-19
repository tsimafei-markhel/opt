using System;

namespace opt.Units
{
    /// <summary>
    /// Represents unit of measurement
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Gets the name of unit of measurement
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets the symbol of unit of measurement
        /// </summary>
        String Symbol { get; }
    }
}