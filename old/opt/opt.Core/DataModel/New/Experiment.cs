using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace opt.DataModel.New
{
    /// <summary>
    /// Represents one project solution (point, experiment)
    /// </summary>
    [Serializable]
    public class Experiment : ModelEntity
    {
        /// <summary>
        /// Gets experiment number
        /// </summary>
        public Int32 Number { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="Parameter"/> values for this experiment
        /// </summary>
        public RealValueDictionary ParameterValues { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="Objective"/> values for this experiment
        /// </summary>
        public RealValueDictionary ObjectiveValues { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="Constraint"/> values for this experiment
        /// </summary>
        public RealValueDictionary FunctionalConstraintValues { get; private set; }

        /// <summary>
        /// Gets a collection of <see cref="ObjectiveConstraint"/> values for this experiment
        /// </summary>
        public RealValueDictionary ObjectiveConstraintValues { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Experiment"/>
        /// </summary>
        /// <param name="id">Experiment identifier</param>
        /// <param name="properties">A collection of entity properties</param>
        /// <param name="number">Experiment number</param>
        /// <param name="parameterValues">A collection of parameter values</param>
        /// <param name="objectiveValues">A collection of objective values</param>
        /// <param name="functionalConstraintValues">A collection of functional constraint values</param>
        /// <param name="objectiveConstraintValues">A collection of objective constraint values</param>
        protected Experiment(
            TId id,
            PropertyDictionary properties,
            Int32 number,
            RealValueDictionary parameterValues,
            RealValueDictionary objectiveValues,
            RealValueDictionary functionalConstraintValues,
            RealValueDictionary objectiveConstraintValues)
            : base(id, properties)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException("number", "Only positive numbers are allowed.");
            }

            if (parameterValues == null)
            {
                throw new ArgumentNullException("parameterValues");
            }

            if (objectiveValues == null)
            {
                throw new ArgumentNullException("objectiveValues");
            }

            if (functionalConstraintValues == null)
            {
                throw new ArgumentNullException("functionalConstraintValues");
            }

            if (objectiveConstraintValues == null)
            {
                throw new ArgumentNullException("objectiveConstraintValues");
            }

            Number = number;
            ParameterValues = parameterValues;
            ObjectiveValues = objectiveValues;
            FunctionalConstraintValues = functionalConstraintValues;
            ObjectiveConstraintValues = objectiveConstraintValues;
        }

        /// <summary>
        /// Initializes new instance of <see cref="Experiment"/>
        /// </summary>
        /// <param name="id">Experiment identifier</param>
        /// <param name="number">Experiment number</param>
        public Experiment(
            TId id,
            Int32 number)
            : this(id, new PropertyDictionary(), number, new RealValueDictionary(), new RealValueDictionary(), new RealValueDictionary(), new RealValueDictionary())
        {
        }

        /// <summary>
        /// Creates a deep copy of <see cref="Experiment"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public override Object Clone()
        {
            return new Experiment(Id, (PropertyDictionary)Properties.Clone(), Number,
                (RealValueDictionary)ParameterValues.Clone(), (RealValueDictionary)ObjectiveValues.Clone(),
                (RealValueDictionary)FunctionalConstraintValues.Clone(), (RealValueDictionary)ObjectiveConstraintValues.Clone());
        }
    }
}