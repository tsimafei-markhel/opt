using System;
using System.Collections.Generic;

namespace opt.DataModel
{
    /// <summary>
    /// Represents identification experiment (point)
    /// </summary>
    [Serializable]
    public class IdentificationExperiment : ModelEntity, ICloneable
    {
        /// <summary>
        /// Gets experiment number
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Gets identifier of the real experiment, where optimization parameter values (X)
        /// and real criterion values (Y) are stored
        /// </summary>
        public TId RealExperimentId { get; private set; }

        /// <summary>
        /// Gets or sets whether the experiment fits all constraints (incl. criterial)
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets identification parameter values (α)
        /// </summary>
        public Dictionary<TId, double> IdentificationParameterValues { get; private set; }

        /// <summary>
        /// Gets mathematical criterion values for this experiment (Φc)
        /// </summary>
        public Dictionary<TId, double> MathematicalCriterionValues { get; private set; }

        /// <summary>
        /// Gets adequacy criterion values for this experiment
        /// </summary>
        /// <remarks>Resulted by applying <see cref="ResidualCriterionsSolver"/> 
        /// to mathematical criterion values and real criterion values</remarks>
        public Dictionary<TId, double> AdequacyCriterionValues { get; private set; }

        /// <summary>
        /// Gets functional constraint values (f)
        /// </summary>
        public Dictionary<TId, double> ConstraintValues { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="IdentificationExperiment"/>
        /// </summary>
        /// <param name="id">Experiment identifier</param>
        /// <param name="number">Experiment number</param>
        /// <param name="realExperimentId">Real experiment identifier</param>
        public IdentificationExperiment(
            TId id,
            int number,
            TId realExperimentId) : base(id)
        {
            Number = number;
            RealExperimentId = realExperimentId;
            IsActive = true;
            IdentificationParameterValues = new Dictionary<TId, double>();
            MathematicalCriterionValues = new Dictionary<TId, double>();
            ConstraintValues = new Dictionary<TId, double>();
            AdequacyCriterionValues = new Dictionary<TId, double>();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="IdentificationExperiment"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public virtual object Clone()
        {
            return new IdentificationExperiment(Id, Number, RealExperimentId)
                {
                    AdequacyCriterionValues = new Dictionary<TId, double>(AdequacyCriterionValues),
                    IdentificationParameterValues = new Dictionary<TId, double>(IdentificationParameterValues),
                    MathematicalCriterionValues = new Dictionary<TId, double>(MathematicalCriterionValues),
                    ConstraintValues = new Dictionary<TId, double>(ConstraintValues),
                    IsActive = IsActive,
                };
        }
    }
}