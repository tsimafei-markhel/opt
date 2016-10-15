using System;
using opt.DataModel;

namespace opt.Solvers.MainCriterion
{
    /// <summary>
    /// Класс, представляющий критериальное ограничение
    /// </summary>
    public class CriterialConstraint : ICloneable
    {
        private TId _criterionId;
        private TId _id;
        private Relation _relation;
        private double _value;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="criterionId">Идентификатор критерия, к 
        /// которому относится данное ограничение</param>
        /// <param name="relation">Знак ограничения</param>
        /// <param name="value">Значение ограничения</param>
        public CriterialConstraint(
            TId criterionId,
            Relation relation,
            double value)
        {
            _id = -1;
            _criterionId = criterionId;
            _relation = relation;
            _value = value;
        }

        /// <summary>
        /// Идентификатор ограничения
        /// </summary>
        public TId Id { get { return _id; } set { _id = value; } }

        /// <summary>
        /// Идентификатор критерия, к которому относится данное ограничение
        /// </summary>
        public TId CriterionId 
        { 
            get { return _criterionId; } 
            set { _criterionId = value; }
        }

        /// <summary>
        /// Знак ограничения
        /// </summary>
        public Relation Relation { get { return _relation; } set { _relation = value; } }

        /// <summary>
        /// Значение ограничения (напр. та величина, которую не должна привысить функция, 
        /// если знак установлен 'меньше либо равно')
        /// </summary>
        public double Value { get { return _value; } set { _value = value; } }

        #region ICloneable Members

        public object Clone()
        {
            return new CriterialConstraint(_criterionId, _relation, _value);
        }

        #endregion
    }
}