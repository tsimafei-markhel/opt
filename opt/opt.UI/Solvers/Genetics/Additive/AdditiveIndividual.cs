using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics.Additive
{
    public class AdditiveIndividual : Individual
    {
        private double _fitnessValue;
        /// <summary>
        /// Значение функции приспособленности для этой особи
        /// </summary>
        public double FitnessValue { get { return _fitnessValue; } set { _fitnessValue = value; } }

        public AdditiveIndividual()
        {
            
        }

        /// <summary>
        /// Создает новую особь
        /// </summary>
        /// <param name="number">Номер особи в популяции (уникальный)</param>
        /// <param name="generation">Номер поколения, к которому принадлежит особь</param>
        /// <param name="attributes">Словарь признаков особи (КОПИРУЕТСЯ)</param>
        public AdditiveIndividual(
            int number,
            int generation,
            Dictionary<TId, IndividualAttribute> attributes)
            : base(number, generation, attributes)
        {
            _fitnessValue = double.NaN;
        }

        public override object Clone()
        {
            return new AdditiveIndividual(_number, _generation, _attributes);
        }
    }
}
