using System;
using System.Collections.Generic;
using System.Linq;

namespace opt.Solvers.Genetics.Nsga
{
    public abstract class NsgaSelection
    {
        public static Population<NsgaIndividual> TournamentSelection(
            Population<NsgaIndividual> initPop,
            int selectionLimit)
        {
            // Сначала проверим: если надо отобрать больше, чем есть, 
            // то выбросим ошибку
            if (selectionLimit > initPop.Count)
            {
                throw new ArgumentException("Number of units to be selected is greater than number of units in population");
            }

            var selectedIndividuals = new Population<NsgaIndividual>(initPop.GetMaxUnitNumber());

            // Если надо отобрать столько же, сколько есть, просто 
            // вернем входную популяцию
            if (selectionLimit == initPop.Count)
            {
                foreach (NsgaIndividual individual in initPop)
                {
                    selectedIndividuals.Add(individual.Number, (NsgaIndividual)individual.Clone());
                }
                return selectedIndividuals;
            }

            // Рандомайзер для выбора случайных особей
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            // Флагом того, что пора прекртатить итерации отбора, 
            // будет служить совпадение количества отобранных 
            // особей (в списке, объявленном выше) и переданного 
            // в качестве аргумента требуемого количества
            int maxUnitNumber = initPop.GetMaxUnitNumber();
            while (selectedIndividuals.Count != selectionLimit)
            {
                // В этом цикле будет проходить разбиение на пары 
                // и выбор лучшей особи из пары

                // Список пары отобранных для турнира особей
                var selectedPair = new List<int>();

                // Проверим: если среди неотобранных особей осталось всего две,
                // то составим из них пару и не будем морочить себе голову 
                // случайностями
                if ((initPop.Count - selectedIndividuals.Count) == 2)
                {
                    foreach (NsgaIndividual individual in initPop)
                    {
                        if (IsValidPairUnit(individual.Number, selectedPair, selectedIndividuals, initPop))
                        {
                            selectedPair.Add(individual.Number);
                        }
                    }
                }
                
                // Флагом остановки выбора случайной особи в пару 
                // будет служить наличие двух отобранных особей
                while (selectedPair.Count != 2)
                {
                    // Будем выбирать случайное число в диапазоне 
                    // от 0 до значения счетчика особей в популяции 
                    // до тех пор, пока не наткнемся на особь, которую 
                    // можно отобрать в турнирную пару
                    int rndNumber = -1;
                    while (!IsValidPairUnit(rndNumber, selectedPair, selectedIndividuals, initPop))
                    {
                        // "+ 1" из-за особенностей реализации метода
                        // Random.Next(Int32, Int32). Если не будет "+ 1",
                        // то maxUnitNumber не выпадет никогда
                        rndNumber = rnd.Next(0, maxUnitNumber + 1);
                    }
                    // Когда найден подходящий номер, добавим его в пару
                    selectedPair.Add(rndNumber);
                }

                // Выберем из пары лучшую особь 
                // (согласно алгоритма NSGA-II)
                NsgaIndividual fittestIndividual = SelectFittestOfTwo(selectedPair, initPop);
                selectedIndividuals.Add(fittestIndividual.Number, (NsgaIndividual)fittestIndividual.Clone());
            }

            // Вернем результат
            return selectedIndividuals;
        }

        /// <summary>
        /// Метод для выбора из пары особей лучшей особи. Чем ниже ранг, тем лучше особь.
        /// Если ранги равны, то чем больше разреженность, тем лучше особь.
        /// </summary>
        /// <param name="selectedPair">Список номеров отобранных в пару особей</param>
        /// <param name="initPop">Популяция, в которой находятся отобранные особи</param>
        /// <returns></returns>
        private static NsgaIndividual SelectFittestOfTwo(IList<int> selectedPair, Population<NsgaIndividual> initPop)
        {
            if (selectedPair == null) throw new ArgumentNullException("selectedPair");
            if (initPop == null) throw new ArgumentNullException("initPop");

            var first = initPop[selectedPair[0]];
            var second = initPop[selectedPair[1]];

            if (!first.IsRanked || !second.IsRanked)
            {
                throw new Exception("One of the selected individuals was not ranked");
            }

            if (first.Rank != second.Rank)
            {
                // Чем меньше ранг, тем лучше особь
                return first.Rank < second.Rank ? first : second;
            }
            else
            {
                // Если ранги равны, то будем ориентироваться на разреженность
                // Чем больше разреженность, тем лучше
                return first.Sparsity > second.Sparsity ? first : second;
            }
        }

        /// <summary>
        /// Метод для проверки того, может ли особь с данным номером 
        /// быть отобрана в пару для участия в турнире
        /// </summary>
        /// <param name="numToCheck">Номер особи, которую нужно проверить</param>
        /// <param name="pair">Список особей, уже отобранных в пару</param>
        /// <param name="selectedIndividuals">Популяция особей, уже отобранных 
        /// на предыдущих итерациях турнира</param>
        /// <param name="population">Популяция, в которой предполагается существование 
        /// особи с таким номером</param>
        /// <returns>True, если особь: 
        /// - имеет номер, больше либо равный нулю; 
        /// - существует в популяции; 
        /// - не была отобрана в пару ранее на этой итерации; 
        /// - не была отобрана на предыдущих итерациях отбора</returns>
        private static bool IsValidPairUnit(
            int numToCheck,
            ICollection<int> pair,
            Population<NsgaIndividual> selectedIndividuals,
            Population<NsgaIndividual> population)
        {
            // Номер должен быть больше либо равен нулю
            if (numToCheck < 0)
            {
                return false;
            }

            // Номер не должен быть уже в паре
            if (pair.Contains(numToCheck))
            {
                return false;
            }

            // Номер не должен быть уже отобран
            if (selectedIndividuals.ContainsUnit(numToCheck))
            {
                return false;
            }

            // Особь с таким номером должна существовать в популяции
            if (!population.ContainsUnit(numToCheck))
            {
                return false;
            }

            // Норма
            return true;
        }

        public static Population<NsgaIndividual> SelectBestIndividuals(Population<NsgaIndividual> population, int numberToSelect)
        {
            var result = new Population<NsgaIndividual>(population.GetMaxUnitNumber());

            int minRank = 1;
            int maxRank = (from NsgaIndividual individual in population
                           select individual.Rank).Max();

            for (int rank = minRank; rank <= maxRank; rank++)
            {
                var individuals = (from NsgaIndividual individual in population
                                   where individual.Rank == rank
                                   select individual).ToList();

                // В книжке >=, но надо ли тут = ?
                if(result.Count + individuals.Count > numberToSelect)
                {
                    var sortedIndividuals = individuals.OrderByDescending(i => i.Sparsity).ToList();
                    int numberToCopy = numberToSelect - result.Count;
                    for (int i = 0; i < numberToCopy; i++ )
                    {
                        result.Add(sortedIndividuals[i].Number, sortedIndividuals[i]);
                    }
                    break;
                }
                else
                {
                    foreach (NsgaIndividual individual in individuals)
                    {
                        result.Add(individual.Number, individual);
                    }
                }
            }

            return result;
        }
    }
}