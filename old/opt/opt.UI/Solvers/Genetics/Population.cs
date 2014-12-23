using System;
using System.Collections;
using System.Collections.Generic;

namespace opt.Solvers.Genetics
{
    public class Population<T> : IEnumerable, IEnumerable<T>, ICloneable where T : Individual
    {
        // Словарь для хранения особей популяции
        protected Dictionary<int, T> _units;

        // Список для хранения номеров помеченных особей
        private List<int> _markedUnitNumbers;

        // Счетчик особей, используется для получения новых номеров
        private int _unitsCounter;

        /// <summary>
        /// Текущее количество особей в популяции
        /// </summary>
        public int Count 
        { 
            get 
            {
                if (_units != null)
                {
                    return _units.Count;
                }
                throw new NullReferenceException("Population was not properly initialized, units dictionary is null");
            }
        }

        public T this[int index]
        {
            get
            {
                if (_units.ContainsKey(index))
                {
                    return _units[index];
                }
                throw new ArgumentException("There is no unit with such number in the population");
            }
        }

        public Population()
        {
            _units = new Dictionary<int, T>();
        }

        public Population(int unitsCounter)
        {
            _unitsCounter = unitsCounter;
            _units = new Dictionary<int, T>();
        }

        public void Add(int newUnitNumber, T newUnit)
        {
            if (newUnit != null)
            {
                if (!_units.ContainsKey(newUnitNumber))
                {
                    _units.Add(newUnitNumber, newUnit);
                    if (newUnitNumber > _unitsCounter)
                    {
                        _unitsCounter = newUnitNumber;
                    }
                }
                else
                {
                    throw new ArgumentException("Unit with such number already exists in the population");
                }
            }
            else
            {
                throw new ArgumentNullException("Unit to add must not be null");
            }
        }

        public void Remove(int unitNumber)
        {
            if (_units.ContainsKey(unitNumber))
            {
                _units.Remove(unitNumber);
            }
            else
            {
                throw new ArgumentException("There is no unit with such number in the population");
            }
        }

        /// <summary>
        /// Метод для пометки особи на удаление
        /// </summary>
        /// <param name="unitNumber">Номер особи, которую надо пометить на удаление</param>
        public void MarkForRemoval(int unitNumber)
        {
            if (_markedUnitNumbers == null)
            {
                _markedUnitNumbers = new List<int>();
            }

            if (_units.ContainsKey(unitNumber))
            {
                _markedUnitNumbers.Add(unitNumber);
            }
            else
            {
                throw new ArgumentException("There is no unit with such number in the population");
            }
        }

        /// <summary>
        /// Метод для удаления всех помеченных на удаление особей
        /// </summary>
        public void RemoveMarked()
        {
            if (_markedUnitNumbers != null)
            {
                foreach (int markedUnitNumber in _markedUnitNumbers)
                {
                    _units.Remove(markedUnitNumber);
                }
                _markedUnitNumbers = null;
            }
        }

        public bool ContainsUnit(int unitNumber)
        {
            return _units.ContainsKey(unitNumber);
        }

        public int GetMaxGenerationNumber()
        {
            int result = -1;
            foreach (T unit in _units.Values)
            {
                if (unit.Generation > result)
                {
                    result = unit.Generation;
                }
            }
            if (result == -1)
            {
                throw new Exception("Can not find current generation number of the population");
            }
            return result;
        }

        public int GetMaxUnitNumber()
        {
            int result = -1;
            foreach (T unit in _units.Values)
            {
                if (unit.Number > result)
                {
                    result = unit.Number;
                }
            }
            if (result == -1)
            {
                throw new Exception("Can not find maximal unit number in the population");
            }
            return result;
        }

        public int GetFreeUnitNumber()
        {
            _unitsCounter++;

            return _unitsCounter;
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return _units.Values.GetEnumerator();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            var newPop = new Population<T>(_unitsCounter);
            foreach (T unit in _units.Values)
            {
                newPop.Add(unit.Number, (T)unit.Clone());
            }
            return newPop;
        }

        #endregion

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _units.Values.GetEnumerator();
        }
    }
}