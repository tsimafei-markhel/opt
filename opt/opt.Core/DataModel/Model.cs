using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using opt.Helpers;

// TODO: Review & rewrite XML comments
// TODO: Move helper methods to separate classes
// TODO: Implement ICloneable?
// TODO: Remove binary serialization from Model and other classes, replace with cloning

namespace opt.DataModel
{
    /// <summary>
    /// Optimization model
    /// </summary>
    [Serializable]
    public sealed class Model
    {
        /// <summary>
        /// Gets a collection of experiments
        /// </summary>
        public ExperimentCollection Experiments { get; private set; }

        /// <summary>
        /// Gets a collection of parameters
        /// </summary>
        public NamedModelEntityCollection<Parameter> Parameters { get; private set; }

        /// <summary>
        /// Gets a collection of criteria (objectives)
        /// </summary>
        public NamedModelEntityCollection<Criterion> Criteria { get; private set; }

        /// <summary>
        /// Gets a collection of constraints (e.g. functional)
        /// </summary>
        public NamedModelEntityCollection<Constraint> FunctionalConstraints { get; private set; }

        /// <summary>
        /// Gets a collection of custom model properties
        /// </summary>
        public PropertyCollection Properties { get; private set; }

        /// <summary>
        /// Initializes new instance of <see cref="Model"/>
        /// </summary>
        public Model()
        {
            Experiments = new ExperimentCollection();
            Parameters = new NamedModelEntityCollection<Parameter>();
            Criteria = new NamedModelEntityCollection<Criterion>();
            FunctionalConstraints = new NamedModelEntityCollection<Constraint>();

            Properties = new PropertyCollection();
        }

        /// <summary>
        /// Marks experiments that do not match functional constraints as inactive;
        /// marks all matching experiments as active
        /// </summary>
        public void ApplyFunctionalConstraints()
        {
            Parallel.ForEach<Experiment>(Experiments.Values, experiment => ApplyFunctionalConstraints(experiment));
        }

        private void ApplyFunctionalConstraints(Experiment experiment)
        {
            experiment.IsActive = true;
            foreach (KeyValuePair<TId, double> constraint in experiment.ConstraintValues)
            {
                if (FunctionalConstraints.ContainsKey(constraint.Key))
                {
                    if (!Comparer.CompareValuesWithSign(
                            constraint.Value,
                            FunctionalConstraints[constraint.Key].Value,
                            FunctionalConstraints[constraint.Key].ConstraintRelation)
                        )
                    {
                        // Не вписывается в ограничение, сбрасываем
                        experiment.IsActive = false;
                        // Условие И на ограничения, поэтому если хоть
                        // по одному не проходит - дальше не проверяем
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether each and every criterion and constraint in the model has expression specified</summary>
        /// <returns>True if each and every criterion and constraint in the model has expression specified</returns>
        public bool CheckExpressionsExistence()
        {
            foreach (Criterion criterion in Criteria.Values)
            {
                if (string.IsNullOrEmpty(criterion.Expression))
                {
                    return false;
                }
            }

            foreach (Constraint constraint in FunctionalConstraints.Values)
            {
                if (string.IsNullOrEmpty(constraint.Expression))
                {
                    return false;
                }
            }

            return true;
        }

        #region Variable Identifier Uniqueness Check

        /// <summary>
        /// Checks whether a parameter with <paramref name="varIdentifier"/> already exists in the model
        /// </summary>
        /// <param name="varIdentifier">Parameter variable identifier to be checked for uniqueness</param>
        /// <returns>True if a parameter with <paramref name="varIdentifier"/> already exists in the model</returns>
        public bool CheckParameterVariableIdentifier(string varIdentifier)
        {
            foreach (Parameter parameter in Parameters.Values)
            {
                if (parameter.VariableIdentifier == varIdentifier &&
                    !string.IsNullOrEmpty(parameter.VariableIdentifier))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a criterion with <paramref name="varIdentifier"/> already exists in the model
        /// </summary>
        /// <param name="varIdentifier">Criterion variable identifier to be checked for uniqueness</param>
        /// <returns>True if a criterion with <paramref name="varIdentifier"/> already exists in the model</returns>
        public bool CheckCriterionVariableIdentifier(string varIdentifier)
        {
            foreach (Criterion criterion in Criteria.Values)
            {
                if (criterion.VariableIdentifier == varIdentifier &&
                    !string.IsNullOrEmpty(criterion.VariableIdentifier))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks whether a constraint with <paramref name="varIdentifier"/> already exists in the model
        /// </summary>
        /// <param name="varIdentifier">Constraint variable identifier to be checked for uniqueness</param>
        /// <returns>True if a constraint with <paramref name="varIdentifier"/> already exists in the model</returns>
        public bool CheckConstraintVariableIdentifier(string varIdentifier)
        {
            foreach (Constraint constraint in FunctionalConstraints.Values)
            {
                if (constraint.VariableIdentifier == varIdentifier &&
                    !string.IsNullOrEmpty(constraint.VariableIdentifier))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Binary Serialization

        /// <summary>
        /// Serializes <see cref="Model"/> to byte array
        /// </summary>
        /// <param name="obj"><see cref="Model"/> instance to serialize</param>
        /// <returns>Byte array representing <paramref name="obj"/></returns>
        public static byte[] Serialize(Model obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] resultBytes;
            using (MemoryStream result = new MemoryStream())
            {
                formatter.Serialize(result, obj);
                result.Flush();

                resultBytes = result.ToArray();
            }

            return resultBytes;
        }

        /// <summary>
        /// Deserializes <see cref="Model"/> from byte array
        /// </summary>
        /// <param name="data">Byte array representing <see cref="Model"/></param>
        /// <returns><see cref="Model"/> instance deserialized from <paramref name="data"/></returns>
        public static Model Deserialize(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Model result = null;
            using (MemoryStream stream = new MemoryStream(data))
            {
                result = (Model)formatter.Deserialize(stream);
            }

            return result;
        }

        #endregion
    }
}