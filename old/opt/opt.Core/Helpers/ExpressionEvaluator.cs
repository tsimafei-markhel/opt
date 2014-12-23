using System;
using System.Collections.Generic;
using System.Linq;
using NCalc;
using opt.DataModel;

// TODO: Further refactoring - after data model update I should be able to switch to generics

namespace opt.Helpers
{
    /// <summary>
    /// Helper class, contains methods for symbolic expressions evaluation using NCalc
    /// </summary>
    public static class ExpressionEvaluator
    {
        /// <summary>
        /// Evaluates criteria values
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to take expressions and numeric values from</param>
        public static void CalculateCriteriaValues(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.Criteria == null ||
                model.Parameters == null ||
                model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            // Prepare calculation objects. NCalc supports caching so this preparation
            // should save us some time
            Dictionary<string, object> expressionParameters = PrepareExpressionParametersCollection(model.Parameters);
            IEnumerable<KeyValuePair<TId, string>> criterionExpressions =
                model.Criteria.Values.Select<Criterion, KeyValuePair<TId, string>>(c => new KeyValuePair<TId, string>(c.Id, c.Expression));
            Dictionary<TId, Expression> expressions = PrepareExpressionCollection(criterionExpressions, expressionParameters);

            // At that point we don't have any active/inactive state so let's calc for each and every experiment
            foreach (Experiment experiment in model.Experiments.Values)
            {
                // Set parameter values for current experiment
                foreach (Parameter parameter in model.Parameters.Values)
                {
                    expressionParameters[parameter.VariableIdentifier] = experiment.ParameterValues[parameter.Id];
                }

                // Calc each criterion for this experiment
                foreach (Criterion criterion in model.Criteria.Values)
                {
                    experiment.CriterionValues.Add(criterion.Id, Convert.ToDouble(expressions[criterion.Id].Evaluate()));
                }
            }
        }

        /// <summary>
        /// Evaluates constraint values
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to take expressions and numeric values from</param>
        public static void CalculateConstraintsValues(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (model.FunctionalConstraints == null ||
                model.Parameters == null ||
                model.Experiments == null)
            {
                throw new InvalidOperationException();
            }

            // Prepare calculation objects. NCalc supports caching so this preparation
            // should save us some time
            Dictionary<string, object> expressionParameters = PrepareExpressionParametersCollection(model.Parameters);
            IEnumerable<KeyValuePair<TId, string>> constraintExpressions =
                model.FunctionalConstraints.Values.Select<Constraint, KeyValuePair<TId, string>>(c => new KeyValuePair<TId, string>(c.Id, c.Expression));
            Dictionary<TId, Expression> expressions = PrepareExpressionCollection(constraintExpressions, expressionParameters);

            // At that point we don't have any active/inactive state so let's calc for each and every experiment
            foreach (Experiment experiment in model.Experiments.Values)
            {
                // Set parameter values for current experiment
                foreach (Parameter parameter in model.Parameters.Values)
                {
                    expressionParameters[parameter.VariableIdentifier] = experiment.ParameterValues[parameter.Id];
                }

                // Calc each constraint for this experiment
                foreach (Constraint constraint in model.FunctionalConstraints.Values)
                {
                    experiment.ConstraintValues.Add(constraint.Id, Convert.ToDouble(expressions[constraint.Id].Evaluate()));
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{T, T}"/> with all model parameters. Keys are variable identifiers, values are null
        /// </summary>
        /// <param name="parameters">Collection of <see cref="Parameter"/></param>
        /// <returns><see cref="Dictionary{T, T}"/> with all model parameters</returns>
        private static Dictionary<string, object> PrepareExpressionParametersCollection(Dictionary<TId, Parameter> parameters)
        {
            Dictionary<string, object> expressionParameters = new Dictionary<string, object>(parameters.Count);
            foreach (Parameter parameter in parameters.Values)
            {
                expressionParameters.Add(parameter.VariableIdentifier, null);
            }

            return expressionParameters;
        }

        /// <summary>
        /// Creates a <see cref="Dictionary{T, T}"/> with <see cref="Expression"/> instances for each item from <paramref name="expressionSource"/>
        /// </summary>
        /// <param name="expressionSource">Collection of string expressions to be used to build <see cref="Expression"/> instances</param>
        /// <param name="expressionParameters">Parameters of the <see cref="Expression"/> to be included in the collection</param>
        /// <returns><see cref="Dictionary{T, T}"/> with <see cref="Expression"/> instances for each item from <paramref name="expressionSource"/></returns>
        private static Dictionary<TId, Expression> PrepareExpressionCollection(
            IEnumerable<KeyValuePair<TId, string>> expressionSource,
            Dictionary<string, object> expressionParameters)
        {
            Dictionary<TId, Expression> expressions = new Dictionary<TId, Expression>(expressionSource.Count());
            foreach (KeyValuePair<TId, string> expressionItem in expressionSource)
            {
                Expression expression = new Expression(expressionItem.Value);
                if (expression.HasErrors())
                {
                    throw new FormatException(expression.Error);
                }

                expression.Parameters = expressionParameters;
                expressions.Add(expressionItem.Key, expression);
            }

            return expressions;
        }
    }
}