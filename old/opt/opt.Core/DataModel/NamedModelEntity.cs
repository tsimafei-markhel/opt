using System;
using System.Collections.Generic;

// TODO: Add validation

namespace opt.DataModel
{
    /// <summary>
    /// Entity with name that can be added to the <see cref="Model"/>
    /// </summary>
    [Serializable]
    public class NamedModelEntity : ModelEntity, ICloneable
    {
        /// <summary>
        /// Gets or sets entity name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets entity variable identifier
        /// </summary>
        public string VariableIdentifier { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="NamedModelEntity"/> with specified name and variable identifier
        /// </summary>
        /// <param name="id">ID of a new entity</param>
        /// <param name="name">Name of a new entity</param>
        /// <param name="variableIdentifier">Variable identifier of a new entity</param>
        protected NamedModelEntity(TId id, string name, string variableIdentifier)
            : base(id)
        {
            Name = name;
            VariableIdentifier = variableIdentifier;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="NamedModelEntity"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public virtual object Clone()
        {
            NamedModelEntity copy = new NamedModelEntity(Id, Name, VariableIdentifier)
                {
                    Properties = (PropertyCollection)Properties.Clone()
                };

            return copy;
        }
    }
}