using System;
using System.Collections;
using System.Collections.Generic;
using opt.DataModel;
using Comparer = opt.Helpers.Comparer;

namespace opt.Solvers.MainCriterion
{
    public class CriterialConstraints : IEnumerable
    {
        // Словарь для хранения критериальных ограничений
        private Dictionary<TId, CriterialConstraint> _constraints;

        public CriterialConstraints()
        {
            _constraints = new Dictionary<TId, CriterialConstraint>();
        }

        public CriterialConstraint this[TId index]
        {
            get 
            {
                if (_constraints.ContainsKey(index))
                {
                    return _constraints[index];
                }
                else
                {
                    throw new ArgumentException("There is no constraint with such ID in the collection");
                }
            }
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _constraints.Values.GetEnumerator();
        }

        #endregion

        public void Add(CriterialConstraint newConstraint)
        {
            if (newConstraint != null)
            {
                TId newId = GetFreeConstraintId();
                _constraints.Add(newId, (CriterialConstraint)newConstraint.Clone());
                _constraints[newId].Id = newId;
            }
            else
            {
                throw new ArgumentNullException("Constraint to add must not be null");
            }
        }

        public void Remove(TId constraintId)
        {
            if (_constraints.ContainsKey(constraintId))
            {
                _constraints.Remove(constraintId);
            }
            else
            {
                throw new ArgumentException("There is no constraint with such ID in the collection");
            }
        }

        public bool ContainsConstraint(TId constraintId)
        {
            return _constraints.ContainsKey(constraintId);
        }

        /// <summary>
        /// Метод для применения критериальных ограничений к 
        /// набору экспериментов в оптимизационной модели
        /// </summary>
        /// <param name="model">Модель, к которой они должны быть 
        /// применены</param>
        public void ApplyCriterialConstraints(ref Model model)
        {
            // Сделаем все эксперименты активными
            foreach (Experiment exp in model.Experiments.Values)
            {
                exp.IsActive = true;
            }

            // Проверим по очереди все ограничения
            foreach (CriterialConstraint constr in this)
            {
                TId critId = constr.CriterionId;
                // Проверим все эксперименты на соответствие
                // данному ограничению
                foreach (Experiment exp in model.Experiments.Values)
                {
                    // Проверять есть смысл, только если эксперимент
                    // активен, потому что если он неактивен, то
                    // значит не прошел по другому ограничению и нечего 
                    // тратить на него время
                    if (exp.IsActive)
                    {
                        double expCriterionValue = exp.CriterionValues[critId];
                        if (!Comparer.CompareValuesWithSign(
                                expCriterionValue,
                                constr.Value,
                                constr.Relation))
                        {
                            exp.IsActive = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для получения свободного идентификатора, 
        /// используется при создании нового критериального 
        /// ограничения
        /// </summary>
        /// <returns>Свободный (еще не занятый) идентификатор</returns>
        private TId GetFreeConstraintId()
        {
            int retval = -1;

            foreach (KeyValuePair<TId, CriterialConstraint> kvp in _constraints)
            {
                if (kvp.Key > retval)
                {
                    retval = kvp.Key;
                }
            }

            return ++retval;
        }
    }
}
