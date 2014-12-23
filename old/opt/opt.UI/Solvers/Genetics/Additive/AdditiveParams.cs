using System;

namespace opt.Solvers.Genetics.Additive
{
    public class AdditiveParams
    {
        private int _initialGenerationCount;
        /// <summary>
        /// Количество особей в начальной популяции
        /// </summary>
        public int InitialGenerationCount
        {
            get { return this._initialGenerationCount; }
            //set { this._initialGenerationCount = value; }
        }

        private int _selectionLimit;
        /// <summary>
        /// Количество отбираемых при селекции особей
        /// </summary>
        public int SelectionLimit
        {
            get { return this._selectionLimit; }
            //set { this._selectionLimit = value; }
        }

        private double _mutationProbability;
        /// <summary>
        /// Вероятность мутации
        /// </summary>
        public double MutationProbability
        {
            get { return this._mutationProbability; }
            //set { this._mutationProbability = value; }
        }

        private int _maxGenerationsNumber;
        /// <summary>
        /// Максимальное количество поколений (Условие Окончания Счета)
        /// </summary>
        public int MaxGenerationsNumber
        {
            get { return this._maxGenerationsNumber; }
            //set { this._maxGenerationsNumber = value; }
        }

        private string _externalAppPath;
        /// <summary>
        /// Путь к внешней (расчетной) программе
        /// </summary>
        public string ExternalAppPath
        {
            get { return this._externalAppPath; }
            //set { this._externalAppPath = value; }
        }

        public AdditiveParams(
            int initialGenerationCount,
            int selectionLimit,
            double mutationProbability,
            int maxGenerationsNumber,
            string externalAppPath)
        {
            // Проверим значения
            if (initialGenerationCount < 2)
            {
                throw new ArgumentException("Initial generation count must be 2 or greater");
            }
            if (selectionLimit < 2 ||
                selectionLimit > initialGenerationCount)
            {
                throw new ArgumentException("Selection limit must be between 2 and Initial generation count");
            }
            if (mutationProbability < 0.0F ||
                mutationProbability > 1.0F)
            {
                throw new ArgumentException("Mutation probability must be between 0.0 and 1.0");
            }
            if (maxGenerationsNumber < 1)
            {
                throw new ArgumentException("Maximal generations number must be 1 or greater");
            }
            if (string.IsNullOrEmpty(externalAppPath) ||
                !System.IO.File.Exists(externalAppPath))
            {
                throw new ArgumentException("Invalid external application path");
            }

            // Если добрались сюда, значит все ОК
            this._initialGenerationCount = initialGenerationCount;
            this._selectionLimit = selectionLimit;
            this._mutationProbability = mutationProbability;
            this._maxGenerationsNumber = maxGenerationsNumber;
            this._externalAppPath = externalAppPath;
        }
    }
}
