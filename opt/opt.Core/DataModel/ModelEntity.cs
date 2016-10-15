using System;
using System.Diagnostics.CodeAnalysis;

// TODO: Add validation

namespace opt.DataModel
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
        /// Gets <see cref="PropertyCollection"/> of an entity
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly",
            Justification = "Fixed in opt.DataModel.New.ModelEntity")]
        public PropertyCollection Properties { get; protected set; }

        /// <summary>
        /// Initializes new instance of <see cref="ModelEntity"/> with specified ID
        /// </summary>
        /// <param name="id">ID of a new entity</param>
        protected ModelEntity(TId id)
        {
            Id = id;
            Properties = new PropertyCollection();
        }
    }
}