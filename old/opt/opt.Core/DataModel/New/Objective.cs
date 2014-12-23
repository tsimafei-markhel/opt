using System;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents an objective
    /// </summary>
    [Serializable]
    public class Objective : ModelEntity
    {
        /// <summary>
        /// Gets or sets objective type
        /// </summary>
        public ObjectiveType ObjectiveType { get; private set; }

        /// <summary>
        /// Gets sort direction for the values of this criterion
        /// </summary>
        public SortDirection SortDirection
        {
            get
            {
                switch (ObjectiveType)
                {
                    case ObjectiveType.Minimizing:
                        return SortDirection.Ascending;

                    case ObjectiveType.Maximizing:
                        return SortDirection.Descending;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="Objective"/>
        /// </summary>
        /// <param name="id">Objective identifier</param>
        /// <param name="properties">Objective properties collection</param>
        /// <param name="objectiveType">Objective type</param>
        protected Objective(
            TId id,
            PropertyDictionary properties,
            ObjectiveType objectiveType)
            : base(id, properties)
        {
            ObjectiveType = objectiveType;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Objective"/>
        /// </summary>
        /// <param name="id">Objective identifier</param>
        /// <param name="objectiveType">Objective type</param>
        public Objective(
            TId id,
            ObjectiveType objectiveType)
            : this(id, new PropertyDictionary(), objectiveType)
        {
            ObjectiveType = objectiveType;
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Objective"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            return new Objective(Id, (PropertyDictionary)Properties.Clone(), ObjectiveType);
        }
    }
}