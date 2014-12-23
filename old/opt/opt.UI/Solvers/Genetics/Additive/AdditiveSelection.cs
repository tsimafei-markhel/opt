using System;
using System.Collections.Generic;

namespace opt.Solvers.Genetics.Additive
{
    public abstract class AdditiveSelection
    {
        public static AdditivePopulation TournamentSelection(
            AdditivePopulation initPop,
            int selectionLimit)
        {
            // Сначала проверим: если надо отобрать больше, чем есть, 
            // то выбросим ошибку
            if (selectionLimit > initPop.Count)
            {
                throw new ArgumentException("Number of units to be selected is greater than number of units in population");
            }

            // Если надо отобрать столько же, сколько есть, просто 
            // вернем входную популяцию
            if (selectionLimit == initPop.Count)
            {
                return initPop;
            }

            // Список номеров отобранных особей
            List<int> selectedUnitNumbers = new List<int>();
            // Рандомайзер для выбора случайных особей
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            // Флагом того, что пора прекртатить итерации отбора, 
            // будет служить совпадение количества отобранных 
            // особей (в списке, объявленном выше) и переданного 
            // в качестве аргумента требуемого количества
            int maxUnitNumber = initPop.GetMaxUnitNumber();
            while (selectedUnitNumbers.Count != selectionLimit)
            {
                // В этом цикле будет проходить разбиение на пары 
                // и выбор лучшей особи из пары

                // Список пары отобранных для турнира особей
                List<int> selectedPair = new List<int>();

                // Проверим: если среди неотобранных особей осталось всего две,
                // то составим из них пару и не будем морочить себе голову 
                // случайностями
                if ((initPop.Count - selectedUnitNumbers.Count) == 2)
                {
                    foreach (AdditiveIndividual unit in initPop)
                    {
                        if (IsValidPairUnit(unit.Number, selectedPair, selectedUnitNumbers, initPop))
                        {
                            selectedPair.Add(unit.Number);
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
                    while (!IsValidPairUnit(rndNumber, selectedPair, selectedUnitNumbers, initPop))
                    {
                        // "+ 1" из-за особенностей реализации метода
                        // Random.Next(Int32, Int32). Если не будет "+ 1",
                        // то maxUnitNumber не выпадет никогда
                        rndNumber = rnd.Next(0, maxUnitNumber + 1);
                    }
                    // Когда найден подходящий номер, добавим его в пару
                    selectedPair.Add(rndNumber);
                }

                // Выберем из пары наиболее приспособленную особь 
                // (ту, у которой значение функции приспособленности 
                // лучше - то есть меньше, потому что мы работаем с 
                // аддитивным критерием)
                if (opt.Helpers.Comparer.IsFirstValueBetter(
                        initPop[selectedPair[0]].FitnessValue,
                        initPop[selectedPair[1]].FitnessValue,
                        opt.DataModel.CriterionType.Minimizing))
                {
                    // Первая особь лучше второй
                    selectedUnitNumbers.Add(selectedPair[0]);
                }
                else
                {
                    // Вторая особь лучше первой
                    selectedUnitNumbers.Add(selectedPair[1]);
                }
            }

            // Пометим на удаление все особи, кроме отобранных во время турнира
            foreach (AdditiveIndividual unit in initPop)
            {
                if (!selectedUnitNumbers.Contains(unit.Number))
                {
                    initPop.MarkForRemoval(unit.Number);
                }
            }
            // Удалим помеченные особи
            initPop.RemoveMarked();

            // Вернем результат
            return initPop;
        }

        /// <summary>
        /// Метод для проверки того, может ли особь с данным номером 
        /// быть отобрана в пару для участия в турнире
        /// </summary>
        /// <param name="numToCheck">Номер особи, которую нужно проверить</param>
        /// <param name="pair">Список особей, уже отобранных в пару</param>
        /// <param name="selectedUnitNumbers">Список особей, уже отобранных 
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
            List<int> pair,
            List<int> selectedUnitNumbers,
            AdditivePopulation population)
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
            if (selectedUnitNumbers.Contains(numToCheck))
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
    }
}