using System;

namespace opt.Units
{
    /// <summary>
    /// Base class for units of measurement
    /// </summary>
    public abstract class UnitBase : IUnit
    {
        /// <summary>
        /// Gets the name of unit of measurement
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets the symbol of unit of measurement
        /// </summary>
        public String Symbol { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="UnitBase"/>
        /// </summary>
        /// <param name="name">Name of new unit of measurement</param>
        /// <param name="symbol">Symbol of new unit of measurement</param>
        /// <exception cref="ArgumentNullException">If <paramref name="name"/> or
        /// <paramref name="symbol"/> is null or empty</exception>
        protected UnitBase(String name, String symbol)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol");
            }

            Name = name;
            Symbol = symbol;
        }
    }
}