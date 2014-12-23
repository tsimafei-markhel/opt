using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.IntegralCriterion
{
    public class UtilityFunction
    {
        private TId _criterionId;

        /// <summary>
        /// Тип критерия оптимальности, нужен для поиска 
        /// значений функции полезности
        /// </summary>
        private CriterionType _criterionType;

        private Dictionary<double, double> _fixedPoints;

        // Количество фиксированных точек. Пока что 10, 
        // а потом может надо будет больше
        private int _fixedPointsNumber = 10;

        public UtilityFunction(
            TId criterionId,
            double criterionMinValue,
            double criterionMaxValue,
            CriterionType criterionType)
        {
            _criterionId = criterionId;
            _criterionType = criterionType;
            InitFixedPoints(criterionMinValue, criterionMaxValue);
        }

        /// <summary>
        /// Идентификатор критерия, для которого определена данная 
        /// функция полезности
        /// </summary>
        public TId CriterionId
        {
            get
            { 
                return _criterionId;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Criterion ID must be greater or equal to 0");
                }

                _criterionId = value; 
            }
        }

        /// <summary>
        /// Набор из точек, для которых точно известны значения 
        /// функции полезности (их задает пользователь на особой 
        /// форме). Ключ - значение критерия, Значение - значение 
        /// функции полезности
        /// </summary>
        public Dictionary<double, double> FixedPoints
        {
            get { return _fixedPoints; }
        }

        /// <summary>
        /// Метод для получения значения функции ползености в точке
        /// </summary>
        /// <param name="criterionValue">Значение критерия - координата точки, 
        /// аргумент функции полезности</param>
        /// <returns>Значение функции полезности в заданной точке</returns>
        public double GetUtilityFunctionValue(double criterionValue)
        {
            double lesserFixedPointKey = double.NaN;
            double greaterFixedPointKey = double.NaN;

            // Будем проверять все фиксированные точки до тех 
            // пор, пока не обнаружим те две, между которыми 
            // заключена искомая
            var keysFound = false;
            foreach (double fixedPointKey in _fixedPoints.Keys)
            {
                if (lesserFixedPointKey == double.NaN)
                {
                    lesserFixedPointKey = fixedPointKey;
                }

                greaterFixedPointKey = fixedPointKey;

                // Проверим, попала ли искомая точка в 
                // интервал
                switch (_criterionType)
                {
                    case CriterionType.Minimizing:
                        if (criterionValue >= lesserFixedPointKey &&
                            criterionValue <= greaterFixedPointKey)
                        {
                            keysFound = true;
                        }
                        break;
                    case CriterionType.Maximizing:
                        if (criterionValue <= lesserFixedPointKey &&
                            criterionValue >= greaterFixedPointKey)
                        {
                            keysFound = true;
                        }
                        break;
                }

                if (keysFound)
                {
                    break;
                }
                else
                {
                    lesserFixedPointKey = fixedPointKey;
                }
            }

            // Из-за проблем с точностью типа double может быть 
            // такая ситуация, когда точка не попала ни в один из
            // интервалов между фиксированными точками
            if (!keysFound)
            {
                switch (_criterionType)
                {
                    case CriterionType.Minimizing:
                        criterionValue = lesserFixedPointKey;
                        break;
                    case CriterionType.Maximizing:
                        criterionValue = greaterFixedPointKey;
                        break;
                }
            }

            return Interpolate(lesserFixedPointKey, greaterFixedPointKey, criterionValue);
        }

        /// <summary>
        /// Метод линейной интерполяции, вычисляет значение функции полезности 
        /// в точке, находящейся между двумя фиксированными (сиречь известными) 
        /// точками
        /// </summary>
        private double Interpolate(
            double lesserFixedPointKey,
            double greaterFixedPointKey,
            double criterionValue)
        {
            double xL = lesserFixedPointKey;
            double xM = greaterFixedPointKey;
            double x = criterionValue;
            double yL = _fixedPoints[lesserFixedPointKey];
            double yM = _fixedPoints[greaterFixedPointKey];

            return ((xM - x) * (yL - yM) / (xM - xL) + yM);
        }

        /// <summary>
        /// Метод для инициализации набора фиксированных точек. 
        /// Находит только значения критерия, значения функции 
        /// устанавливает равномерно от 1 (лучшее значение критерия) 
        /// до 0 (худшее значение критерия)
        /// </summary>
        private void InitFixedPoints(
            double critMinValue, 
            double critMaxValue)
        {
            _fixedPoints = new Dictionary<double, double>();

            double critInterval = critMaxValue - critMinValue;
            double critDelta = critInterval / Convert.ToDouble(_fixedPointsNumber - 1);

            double funcInterval = 1.0;
            double funcDelta = funcInterval / Convert.ToDouble(_fixedPointsNumber - 1);

            switch (_criterionType)
            {
                case CriterionType.Minimizing:
                    for (int pt = 0; pt < _fixedPointsNumber; pt++)
                    {
                        double critValue = critMinValue + critDelta * pt;
                        double funcValue = 1.0 - funcDelta * pt;
                        _fixedPoints.Add(critValue, funcValue);
                    }
                    break;
                case CriterionType.Maximizing:
                    for (int pt = 0; pt < _fixedPointsNumber; pt++)
                    {
                        double critValue = critMaxValue - critDelta * pt;
                        double funcValue = 1.0 - funcDelta * pt;
                        _fixedPoints.Add(critValue, funcValue);
                    }
                    break;
            }
        }
    }
}