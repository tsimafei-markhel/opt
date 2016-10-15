using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics.Nsga
{
    public class NsgaIndividual : Individual
    {
        private int _rank;
        public int Rank { get { return _rank; } set { _rank = value; } }

        private bool _isRanked;
        public bool IsRanked { get { return _isRanked; } set { _isRanked = value; } }

        private double _sparsity;
        public double Sparsity { get { return _sparsity; } set { _sparsity = value; } }

        private Dictionary<TId, double> _criteria;
        public Dictionary<TId, double> Criteria { get { return _criteria; } /*set { _criteria = value; }*/ }

        /// <summary>
        /// Создает новую особь
        /// </summary>
        /// <param name="number">Номер особи в популяции (уникальный)</param>
        /// <param name="generation">Номер поколения, к которому принадлежит особь</param>
        /// <param name="attributes">Словарь признаков особи (КОПИРУЕТСЯ)</param>
        public NsgaIndividual(
            int number,
            int generation,
            Dictionary<TId, IndividualAttribute> attributes)
            : base(number, generation, attributes)
        {
            _rank = -1;
            _isRanked = false;
            _sparsity = 0.0;
            _criteria = new Dictionary<TId, double>();
        }

        private NsgaIndividual(
            int number,
            int generation,
            Dictionary<TId, IndividualAttribute> attributes,
            int rank,
            bool isRanked,
            double sparsity,
            Dictionary<TId, double> criteria) : this(number, generation, attributes)
        {
            _rank = rank;
            _isRanked = isRanked;
            _sparsity = sparsity;

            // Скопируем словарь с признаками
            _criteria = new Dictionary<TId, double>();
            foreach (KeyValuePair<TId, double> crit in criteria)
            {
                _criteria.Add(crit.Key, crit.Value);
            }
        }

        public NsgaIndividual()
        {
            
        }

        public override object Clone()
        {
            return new NsgaIndividual(_number, _generation, _attributes, _rank, _isRanked, _sparsity, _criteria);
        }

    }
}