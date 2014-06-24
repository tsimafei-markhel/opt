using System;

namespace opt.Relations
{
    /// <summary>
    /// Base class for the relations
    /// </summary>
    public abstract class RelationBase : IRelation
    {
        /// <summary>
        /// Gets informative relation name
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Gets relation symbol
        /// </summary>
        public String Symbol { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="RelationBase"/>
        /// </summary>
        /// <param name="name">Informative relation name</param>
        /// <param name="symbol">Relation symbol</param>
        /// <exception cref="ArgumentNullException">If <paramref name="name"/> or
        /// <paramref name="symbol"/> is null or empty string</exception>
        protected RelationBase(String name, String symbol)
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