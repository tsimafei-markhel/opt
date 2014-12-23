using System;

// TODO: Move variable identifier checks to the validation layer

namespace opt.DataModel
{
    using ConstraintCollection = NamedModelEntityCollection<Constraint>;
    using CriterionCollection = NamedModelEntityCollection<AdequacyCriterion>;
    using ParameterCollection = NamedModelEntityCollection<Parameter>;

    /// <summary>
    /// Identification model
    /// </summary>
    [Serializable]
    public sealed class IdentificationModel : ICloneable
    {
        /// <summary>
        /// Gets a collection of identification experiments
        /// </summary>
        public IdentificationExperimentCollection IdentificationExperiments { get; private set; }

        /// <summary>
        /// Gets a collection of real experiments
        /// </summary>
        public ExperimentCollection RealExperiments { get; private set; }

        /// <summary>
        /// Gets a collection of parameters (α)
        /// </summary>
        public ParameterCollection IdentificationParameters { get; private set; }

        /// <summary>
        /// Gets a collection of parameters (X)
        /// </summary>
        public ParameterCollection OptimizationParameters { get; private set; }

        /// <summary>
        /// Gets a collection of criteria (objectives)
        /// </summary>
        public CriterionCollection Criteria { get; private set; }

        /// <summary>
        /// Gets a collection of constraints (e.g. functional)
        /// </summary>
        public ConstraintCollection FunctionalConstraints { get; private set; }

        /// <summary>
        /// Gets a collection of custom model properties
        /// </summary>
        public PropertyCollection Properties { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="IdentificationModel"/>
        /// </summary>
        public IdentificationModel()
        {
            IdentificationExperiments = new IdentificationExperimentCollection();
            RealExperiments = new ExperimentCollection();
            IdentificationParameters = new ParameterCollection();
            OptimizationParameters = new ParameterCollection();
            Criteria = new CriterionCollection();
            FunctionalConstraints = new ConstraintCollection();

            Properties = new PropertyCollection();
        }

        /// <summary>
        /// Creates a deep copy of <see cref="IdentificationModel"/> instance
        /// </summary>
        /// <returns>Deep copy of self</returns>
        public object Clone()
        {
            return new IdentificationModel()
            {
                IdentificationExperiments = (IdentificationExperimentCollection)IdentificationExperiments.Clone(),
                RealExperiments = (ExperimentCollection)RealExperiments.Clone(),
                IdentificationParameters = (ParameterCollection)IdentificationParameters.Clone(),
                OptimizationParameters = (ParameterCollection)OptimizationParameters.Clone(),
                Criteria = (CriterionCollection)Criteria.Clone(),
                FunctionalConstraints = (ConstraintCollection)FunctionalConstraints.Clone(),
                Properties = (PropertyCollection)Properties.Clone()
            };
        }

        /// <summary>
        /// Checks if there already is an identification parameter with such <paramref name="variableIdentifier"/>
        /// </summary>
        /// <param name="variableIdentifier">Parameter variable identifier</param>
        /// <returns>True if a match is found</returns>
        public bool CheckIdentificationParameterVariableIdentifier(string variableIdentifier)
        {
            return CheckVariableIdentifier(IdentificationParameters, variableIdentifier);
        }

        /// <summary>
        /// Checks if there already is an optimization parameter with such <paramref name="variableIdentifier"/>
        /// </summary>
        /// <param name="variableIdentifier">Parameter variable identifier</param>
        /// <returns>True if a match is found</returns>
        public bool CheckOptimizationParameterVariableIdentifier(string variableIdentifier)
        {
            return CheckVariableIdentifier(OptimizationParameters, variableIdentifier);
        }

        /// <summary>
        /// Checks if there already is a criterion with such <paramref name="variableIdentifier"/>
        /// </summary>
        /// <param name="variableIdentifier">Criterion variable identifier</param>
        /// <returns>True if a match is found</returns>
        public bool CheckCriterionVariableIdentifier(string variableIdentifier)
        {
            return CheckVariableIdentifier(Criteria, variableIdentifier);
        }

        /// <summary>
        /// Checks if there already is a constraint with such <paramref name="variableIdentifier"/>
        /// </summary>
        /// <param name="variableIdentifier">Constraint variable identifier</param>
        /// <returns>True if a match is found</returns>
        public bool CheckConstraintVariableIdentifier(string variableIdentifier)
        {
            return CheckVariableIdentifier(FunctionalConstraints, variableIdentifier);
        }

        /// <summary>
        /// Checks if there already is an element with such <paramref name="variableIdentifier"/> in
        /// <paramref name="collection"/>
        /// </summary>
        /// <param name="collection">A collection to look for variable identifier in</param>
        /// <param name="variableIdentifier">Constraint variable identifier</param>
        /// <returns>True if a match is found</returns>
        private bool CheckVariableIdentifier<T>(NamedModelEntityCollection<T> collection, string variableIdentifier) 
            where T : NamedModelEntity
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (string.IsNullOrEmpty(variableIdentifier))
            {
                throw new ArgumentNullException("variableIdentifier");
            }

            return (collection.FindByVariableIdentifier(variableIdentifier) == null) ? false : true;
        }
    }
}