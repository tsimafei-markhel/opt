using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.IntegralCriterion
{
    [Serializable]
    public sealed class IntegralCriterionMethodResult : OptimizationMethodResult
    {
        private Dictionary<TId, Dictionary<TId, double>> _normalizedCriteria;
        private Dictionary<TId, Dictionary<TId, double>> _utilityFunctionValues;

        private IntegralCriterionMethodResult() : this(string.Empty, string.Empty) { }

        public IntegralCriterionMethodResult(string methodName) : this(methodName, string.Empty) { }

        public IntegralCriterionMethodResult(string methodName, string additionalDataDescription) : base (methodName, additionalDataDescription)
        {
            _normalizedCriteria = new Dictionary<TId, Dictionary<TId, double>>();
            _utilityFunctionValues = new Dictionary<TId, Dictionary<TId, double>>();
        }

        /// <summary>
        /// Метод для получения значений нормализованного критерия по его ID
        /// </summary>
        /// <param name="criterionId">ID критерия, нормализованные значения 
        /// которого нужно получить</param>
        /// <returns>Словарь со значениями нормализованного критерия для каждого 
        /// из экспериментов</returns>
        public Dictionary<TId, double> GetNormalizedCriterion(TId criterionId)
        {
            if (_normalizedCriteria.ContainsKey(criterionId))
            {
                return _normalizedCriteria[criterionId];
            }
            else
            {
                throw new ArgumentException("Criterion with such ID does not exist or was not normalized");
            }
        }

        /// <summary>
        /// Метод добавляет в коллекцию нормализованных критериев
        /// новый нормализованный критерий С КОПИРОВАНИЕМ
        /// </summary>
        /// <param name="criterionValues">Словарь со значениями нормализованного критерия</param>
        /// <param name="criterionId">ID критерия оптимальности, для которого была 
        /// проведена нормализация</param>
        public void AddNormalizedCriterion(Dictionary<TId, double> criterionValues, TId criterionId)
        {
            _normalizedCriteria.Add(criterionId, new Dictionary<TId, double>(criterionValues));
        }

        /// <summary>
        /// Метод для получения значений функции полезности для критерия по его ID
        /// </summary>
        /// <param name="criterionId">ID критерия, значения функции полезности для 
        /// которого нужно получить</param>
        /// <returns>Словарь со значениями функции полезности для каждого 
        /// из экспериментов</returns>
        public Dictionary<TId, double> GetUtilityFunction(TId criterionId)
        {
            if (_utilityFunctionValues.ContainsKey(criterionId))
            {
                return _utilityFunctionValues[criterionId];
            }
            else
            {
                throw new ArgumentException("Criterion with such ID does not exist or utility function values for it was not calculated");
            }
        }

        /// <summary>
        /// Метод добавляет в коллекцию функций полезности
        /// новую функцию полезности С КОПИРОВАНИЕМ
        /// </summary>
        /// <param name="utilityFunctionValues">Словарь со значениями функции полезности</param>
        /// <param name="criterionId">ID критерия оптимальности, для которого были 
        /// найдены значения функции полезности</param>
        public void AddUtilityFunction(
            Dictionary<TId, double> utilityFunctionValues,
            TId criterionId)
        {
            _utilityFunctionValues.Add(
                criterionId,
                new Dictionary<TId, double>(utilityFunctionValues));
        }

        public override CustomProperty Clone()
        {
            IntegralCriterionMethodResult copy = new IntegralCriterionMethodResult()
            {
                AdditionalData = new Dictionary<TId, double>(this.AdditionalData),
                AdditionalDataDescription = this.AdditionalDataDescription,
                MethodName = this.MethodName,
                SortedPoints = new List<TId>(this.SortedPoints)
            };

            foreach (KeyValuePair<TId, Dictionary<TId, double>> normalizedCriterion in _normalizedCriteria)
            {
                copy._normalizedCriteria.Add(normalizedCriterion.Key, new Dictionary<TId, double>(normalizedCriterion.Value));
            }

            foreach (KeyValuePair<TId, Dictionary<TId, double>> utilityFunctionValue in _utilityFunctionValues)
            {
                copy._utilityFunctionValues.Add(utilityFunctionValue.Key, new Dictionary<TId, double>(utilityFunctionValue.Value));
            }

            return copy;
        }
    }
}