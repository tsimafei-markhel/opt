using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics
{
    public abstract class Individual : ICloneable
    {
        protected int _number;
        /// <summary>
        /// Уникальный номер особи в популяции
        /// </summary>
        public int Number { get { return _number; } set { _number = value; } }

        protected int _generation;
        /// <summary>
        /// Номер поколения, в котором появилась эта особь
        /// </summary>
        public int Generation { get { return _generation; } set { _generation = value; } }

        protected Dictionary<TId, IndividualAttribute> _attributes;
        /// <summary>
        /// Значения признаков. Ключ - ID признака (параметра), 
        /// Значение - класс признака
        /// </summary>
        public Dictionary<TId, IndividualAttribute> Attributes
        {
            get { return _attributes; }
        }

        /// <summary>
        /// Создает новую особь
        /// </summary>
        /// <param name="number">Номер особи в популяции (уникальный)</param>
        /// <param name="generation">Номер поколения, к которому принадлежит особь</param>
        /// <param name="attributes">Словарь признаков особи (КОПИРУЕТСЯ)</param>
        public Individual(
            int number,
            int generation,
            Dictionary<TId, IndividualAttribute> attributes)
        {
            _number = number;
            _generation = generation;

            // Скопируем словарь с признаками
            _attributes = new Dictionary<TId, IndividualAttribute>();
            foreach (KeyValuePair<TId, IndividualAttribute> attr in attributes)
            {
                _attributes.Add(attr.Key, (IndividualAttribute)attr.Value.Clone());
            }
        }

        public Individual()
        {
        }

        /// <summary>
        /// Метод для получения полного генетического кода особи
        /// </summary>
        /// <returns>Строка, содержащую генетический код особи</returns>
        public string GetChromo()
        {
            string result = string.Empty;
            foreach (IndividualAttribute attr in this._attributes.Values)
            {
                result += attr.Code;
            }
            return result;
        }

        /// <summary>
        /// Метод для обновления значений признаков особи 
        /// по ее новой хромосоме (генетическому коду)
        /// </summary>
        /// <param name="chromo">Новая хромосома (генетический код)</param>
        public void UpdateAttributes(string chromo)
        {
            // Проверим пришедшую строку - в ней должно быть хоть что-то
            if (string.IsNullOrEmpty(chromo))
            {
                throw new Exception("Chromosome code cannot be empty");
            }
            // Обновим все признаки
            foreach (IndividualAttribute attr in _attributes.Values)
            {
                // Для данного признака получим из входной строки 
                // новое значение кода
                attr.Code = chromo.Substring(0, attr.CodeLength);
                // Удалим полученное из входной строки
                chromo = chromo.Remove(0, attr.CodeLength);
                // Обновим значение признака по вновь 
                // заданному выше коду
                attr.ResolveValueFromCode();
            }
        }

        #region ICloneable Members

        public abstract object Clone();
        //{
        //    return new Individual(_number, _generation, _attributes);
        //}

        #endregion
    }
}
