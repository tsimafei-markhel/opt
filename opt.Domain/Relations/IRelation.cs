using System;

namespace opt.Relations
{
    /// <summary>
    /// Marker interface, represents a relation between one or more entities
    /// </summary>
    public interface IRelation
    {
        /// <summary>
        /// Gets informative relation name
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Gets relation symbol
        /// </summary>
        String Symbol { get; }
    }
}