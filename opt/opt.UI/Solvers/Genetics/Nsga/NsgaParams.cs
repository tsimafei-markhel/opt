using System;
using System.IO;

namespace opt.Solvers.Genetics.Nsga
{
    public class NsgaParams
    {
        private int _initialGenerationCount;
        /// <summary>
        /// Количество особей в начальной популяции
        /// </summary>
        public int InitialGenerationCount
        {
            get { return _initialGenerationCount; }
        }

        private int _selectionLimit;
        /// <summary>
        /// Количество отбираемых при селекции особей
        /// </summary>
        public int SelectionLimit
        {
            get { return _selectionLimit; }
        }

        private int _maxGenerationsNumber;
        /// <summary>
        /// Максимальное количество поколений (Условие Окончания Счета)
        /// </summary>
        public int MaxGenerationsNumber
        {
            get { return _maxGenerationsNumber; }
        }

        private string _externalAppPath;
        /// <summary>
        /// Путь к внешней (расчетной) программе
        /// </summary>
        public string ExternalAppPath
        {
            get { return _externalAppPath; }
        }

        public NsgaParams(
            int initialGenerationCount,
            int selectionLimit,
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
            if (maxGenerationsNumber < 1)
            {
                throw new ArgumentException("Maximal generations number must be 1 or greater");
            }
            if (string.IsNullOrEmpty(externalAppPath) ||
                !File.Exists(externalAppPath))
            {
                throw new ArgumentException("Invalid external application path");
            }

            // Если добрались сюда, значит все ОК
            _initialGenerationCount = initialGenerationCount;
            _selectionLimit = selectionLimit;
            _maxGenerationsNumber = maxGenerationsNumber;
            _externalAppPath = externalAppPath;
        }
    }
}
