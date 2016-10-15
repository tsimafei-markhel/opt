using System;
using System.Collections.Generic;

// TODO: Move activeness to custom properties
// TODO: Move Pareto optimality to custom properties
// TODO: Replace Dictionary<TId, double> with some wrapper-class (like PropertyCollection)

namespace opt.DataModel
{
    /// <summary>
    /// Represents experiment (point)
    /// </summary>
    [Serializable]
    public class Experiment : ModelEntity, ICloneable
    {
        /// <summary>
        /// Gets experiment number
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets or sets whether the experiment fits all constraints (incl. criterial)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets whether the experiment belongs to Pareto front
        /// </summary>
        public bool IsParetoOptimal { get; set; }

        /// <summary>
        /// Gets criterion values for this experiment
        /// </summary>
        public Dictionary<TId, double> CriterionValues { get; private set; }

        /// <summary>
        /// Gets parameter values for this experiment
        /// </summary>
        public Dictionary<TId, double> ParameterValues { get; private set; }

        /// <summary>
        /// Gets constraint values for this experiment
        /// </summary>
        public Dictionary<TId, double> ConstraintValues { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Experiment"/>
        /// </summary>
        /// <param name="id">Experiment identifier</param>
        /// <param name="number">Experiment number</param>
        public Experiment(
            TId id,
            int number) : base(id)
        {
            Number = number;
            IsActive = true;
            IsParetoOptimal = false;
            ParameterValues = new Dictionary<TId, double>();
            CriterionValues = new Dictionary<TId, double>();
            ConstraintValues = new Dictionary<TId, double>();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Experiment"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public virtual object Clone()
        {
            return new Experiment(Id, Number)
                {
                    ParameterValues = new Dictionary<TId, double>(ParameterValues),
                    CriterionValues = new Dictionary<TId, double>(CriterionValues),
                    ConstraintValues = new Dictionary<TId, double>(ConstraintValues),
                    IsActive = IsActive,
                    IsParetoOptimal = IsParetoOptimal,
                    Properties = (PropertyCollection)Properties.Clone()
                };
        }
    }
}