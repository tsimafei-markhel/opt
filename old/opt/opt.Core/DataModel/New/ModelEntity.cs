using System;

namespace opt.DataModel.New
{
    /// <summary>
    /// Entity that can be added to the <see cref="Model"/>
    /// </summary>
    [Serializable]
    public abstract class ModelEntity
    {
        /// <summary>
        /// Gets unique identifier of an entity
        /// </summary>
        public TId Id { get; private set; }

        /// <summary>
        /// Gets <see cref="PropertyDictionary"/> of an entity
        /// </summary>
        public PropertyDictionary Properties { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntity"/> with specified ID
        /// and properties collection
        /// </summary>
        /// <param name="id">Identifier of a new entity</param>
        /// <param name="properties">Property collection to be assigned to a new
        /// entity. Note: this is NOT being copied inside!</param>
        protected ModelEntity(TId id, PropertyDictionary properties)
        {
            Id = id;
            Properties = properties;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="ModelEntity"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public abstract Object Clone();
    }
}