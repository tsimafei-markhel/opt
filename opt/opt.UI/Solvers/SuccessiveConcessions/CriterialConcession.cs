using System;
using opt.DataModel;

namespace opt.Solvers.SuccessiveConcessions
{
    public class CriterialConcession : ICloneable
    {
        private double _bestValue;
        private double _concession;
        private TId _criterionId;

        private CriterionType _criterionType;
        private bool _isUsable;
        private double _worstValue;

        public CriterialConcession(
            Criterion criterion)
        {
            _criterionId = criterion.Id;
            _criterionType = criterion.Type;
            
            _bestValue = double.NaN;
            _worstValue = double.NaN;
            _concession = double.NaN;
            _isUsable = false;
        }

        private CriterialConcession(
            TId criterionId,
            CriterionType criterionType,
            double bestValue,
            double worstValue,
            double concession,
            bool isUsable)
        {
            _criterionId = criterionId;
            _criterionType = criterionType;
            _bestValue = bestValue;
            _worstValue = worstValue;
            _concession = concession;
            _isUsable = isUsable;
        }

        /// <summary>
        /// Id критерия оптимальности, для которого задается данная уступка
        /// </summary>
        public TId CriterionId { get { return _criterionId; } }

        /// <summary>
        /// Тип критерия оптимальности, для которого задается данная уступка
        /// </summary>
        public CriterionType CriterionType { get { return _criterionType; } }

        /// <summary>
        /// Лучшее по данному критерию оптимальности значение среди всех экспериментов
        /// </summary>
        public double BestValue { get { return _bestValue; } set { _bestValue = value; } }

        /// <summary>
        /// Худшее допустимое по данному критерию оптимальности значение. 
        /// Вычисляется на основании лучшего значения и уступки
        /// </summary>
        public double WorstValue { get { return _worstValue; } }

        /// <summary>
        /// Величина уступки по данному критерию
        /// </summary>
        public double Concession { get { return _concession; } set { _concession = value; } }

        /// <summary>
        /// Флаг, показывающий, применять ли данную уступку для фильтрации экспериментов
        /// </summary>
        public bool IsUsable { get { return _isUsable; } set { _isUsable = value; } }

        #region ICloneable Members

        public object Clone()
        {
            return new CriterialConcession(CriterionId, CriterionType, BestValue, WorstValue, Concession, IsUsable);
        }

        #endregion

        /// <summary>
        /// Метод для сборса уступки: очищает значение уступки, худшее значение и флаг фильтрации
        /// </summary>
        public void Clear()
        {
            _worstValue = double.NaN;
            _concession = double.NaN;
            _isUsable = false;
        }

        /// <summary>
        /// Метод для вычисления худшего допусимого значения критерия. 
        /// Вычисляется по лучшему имеющемуся значению и по значению уступки. 
        /// Если критерий минимизируется, то уступка прибавляется к лучшему значению, 
        /// а если максимизируется, то отнимается от лучшего значения
        /// </summary>
        public void CalcWorstValue()
        {
            if (_bestValue == double.NaN || _concession == double.NaN)
            {
                throw new Exception("Лучшее значение и уступка должны быть действительными числами");
            }
            if (_concession < 0)
            {
                throw new Exception("Уступка должна быть неотрицательной");
            }

            switch (_criterionType)
            {
                case CriterionType.Minimizing:
                    _worstValue = _bestValue + _concession;
                    break;
                case CriterionType.Maximizing:
                    _worstValue = _bestValue - _concession;
                    break;
            }
        }

        public bool IsValueFittingInterval(double value)
        {
            switch (_criterionType)
            {
                case CriterionType.Minimizing:
                    if (value >= _bestValue && value <= _worstValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case CriterionType.Maximizing:
                    if (value <= _bestValue && value >= _worstValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;
            }
        }
    }
}