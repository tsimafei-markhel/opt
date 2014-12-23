using System;
using System.Collections.Generic;
using opt.DataModel;

namespace opt.Solvers.Genetics.Additive
{
    public abstract class AdditiveCrossover
    {
        public static AdditivePopulation OnePointCrossover(
            AdditivePopulation initPop,
            int newGenerationNumber)
        {
            // Для начала проверим валидность данных

            // Если в популяции ноль особей, то ошибка
            if (initPop.Count < 1)
            {
                throw new ArgumentException("Can not perform crossover on a population with 0 units in it");
            }
            // Если номер нового (следующего) поколения меньше или равен 
            // номеру текущего, то ошибка
            if (newGenerationNumber <= initPop.GetMaxGenerationNumber())
            {
                throw new Exception("New generation number is lesser than current");
            }

            // Все в порядке, можно проводить скрещивание
            
            // Генератор случайных чисел
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            
            // Для создания пар сформируем стек.
            // 1. Заполним его случайным образом (в случ. 
            // порядке) всеми имеющимися особями.
            // 2. Будем доставать по две и скрещивать их между собой.
            // 3. Если осталось 0 особей, то конец.
            // 4. Если осталась 1 особь, то инверсия и goto п. 3.
            Stack<int> unitsStack = new Stack<int>();
            int maxUnitNumber = initPop.GetMaxUnitNumber();
            while (unitsStack.Count < initPop.Count)
            {
                // Выберем из популяции случайную особь
                int rndNumber = -1;
                while (!IsValidRandomUnit(rndNumber, unitsStack, initPop))
                {
                    // "+ 1" из-за особенностей реализации метода
                    // Random.Next(Int32, Int32). Если не будет "+ 1",
                    // то maxUnitNumber не выпадет никогда
                    rndNumber = rnd.Next(0, maxUnitNumber + 1);
                }
                // Номер подходящий, добавим его в стек
                unitsStack.Push(rndNumber);
            }

            // Теперь стек заполнен номерами имеющихся особей в
            // случайном порядке
            // Будем доставать оттуда по две, пока там не останется 
            // 0 или 1 особь, и скрещивать
            while (unitsStack.Count >= 2)
            {
                int firstParent = unitsStack.Pop();
                int secondParent = unitsStack.Pop();

                AdditiveCrossover.CrossTwoUnits(
                    ref initPop, 
                    firstParent, 
                    secondParent,
                    newGenerationNumber);
            }

            // Если осталось 0 особей, то всё готово, вернем 
            // популяцию
            if (unitsStack.Count == 0)
            {
                return initPop;
            }
            else
            {
                // Иначе же осталась 1 особь и мы должны выполнить инверсию
                AdditiveCrossover.Inversion(
                    ref initPop, 
                    unitsStack.Pop(),
                    newGenerationNumber);

                return initPop;
            }
        }

        /// <summary>
        /// Метод для проверки сгенерированного номера особи 
        /// на пригодность для включения в стек номеров особей
        /// </summary>
        /// <param name="numToCheck">Номер для проверки</param>
        /// <param name="selectedUnitNumbers">Стек с уже отобранными номерами</param>
        /// <param name="population">Популяция, в которой предполагается существование 
        /// особи с таким номером</param>
        /// <returns>True, если особь:
        /// - имеет номер, больше либо равный нулю; 
        /// - не была отобрана на предыдущих итерациях; 
        /// - существует в популяции</returns>
        private static bool IsValidRandomUnit(
            int numToCheck,
            Stack<int> selectedUnitNumbers,
            AdditivePopulation population)
        {
            // Номер должен быть больше либо равен нулю
            if (numToCheck < 0)
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

        /// <summary>
        /// Метод для выполнения одноточечного скрещивания двух 
        /// особей
        /// </summary>
        /// <param name="population">Популяция, в которой находятся две 
        /// родительские особи и куда будут помещены два потомка</param>
        /// <param name="firstUnitNumber">Номер первого родителя в популяции (уникальный)</param>
        /// <param name="secondUnitNumber">Номер второго родителя в популяции (уникальный)</param>
        /// <param name="newGenerationNumber">Номер поколения, к которому относятся потомки</param>
        private static void CrossTwoUnits(
            ref AdditivePopulation population,
            int firstUnitNumber,
            int secondUnitNumber,
            int newGenerationNumber)
        {
            // Признаки, у новых двух особей они будут такие же, 
            // за исключением значений признаков - их поправим позже
            Dictionary<TId, IndividualAttribute> attributes =
                population[firstUnitNumber].Attributes;

            // Генетические коды родителей
            string firstChromo = population[firstUnitNumber].GetChromo();
            string secondChromo = population[secondUnitNumber].GetChromo();

            // Небольшая проверка: длины кодов должны быть одинаковые
            int chromoLength = firstChromo.Length;
            if (chromoLength != secondChromo.Length)
            {
                throw new Exception("Chromosome lengths of two parents must be the same");
            }

            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            // Точка одноточечного скрещивания
            // Такая формула обусловлена следующим:
            //  - не должно получатся число, равное длине строки, потому что 
            //    нумерация символов zero-based и будет ошибка;
            //  - не должен получатся ноль, потому что тогда особи просто 
            //    обменяются кодами и ничего не выйдет
            int crossoverPointPosition = 1 + rnd.Next(chromoLength - 2);

            // Разделим хромосомы на части, из которых будут составлены 
            // хромосомы потомков
            string firstParentFirstPart = firstChromo.Substring(0, crossoverPointPosition);
            string firstParentSecondPart = firstChromo.Substring(crossoverPointPosition);
            string secondParentFirstPart = secondChromo.Substring(0, crossoverPointPosition);
            string secondParentSecondPart = secondChromo.Substring(crossoverPointPosition);

            // Составим хромосомы потомков
            string firstChildChromo = firstParentFirstPart + secondParentSecondPart;
            string secondChildChromo = secondParentFirstPart + firstParentSecondPart;

            // Получим и добавим в популяцию первого потомка
            AdditiveIndividual firstChild = new AdditiveIndividual(
                population.GetFreeUnitNumber(),
                newGenerationNumber,
                attributes);
            firstChild.UpdateAttributes(firstChildChromo);
            population.Add(firstChild.Number, firstChild);

            // Получим и добавим в популяцию второго потомка
            AdditiveIndividual secondChild = new AdditiveIndividual(
                            population.GetFreeUnitNumber(),
                            newGenerationNumber,
                            attributes);
            secondChild.UpdateAttributes(secondChildChromo);
            population.Add(secondChild.Number, secondChild);
        }

        /// <summary>
        /// Метод для выполнения одноточечной инверсии особи
        /// </summary>
        /// <param name="population">Популяция, в которой находится родительская 
        /// особь и в которую будет помещен потомок</param>
        /// <param name="unitNumber">Номер особи, над которой нужно выполнить инверсию 
        /// (уникальный)</param>
        /// <param name="newGenerationNumber">Номер поколения, к которому относится потомок</param>
        private static void Inversion(
            ref AdditivePopulation population,
            int unitNumber,
            int newGenerationNumber)
        {
            // Признаки, у новой особи они будут такие же, 
            // за исключением значений признаков - их поправим позже
            Dictionary<TId, IndividualAttribute> attributes =
                population[unitNumber].Attributes;

            // Генетический код родителя
            string parentChromo = population[unitNumber].GetChromo();

            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);
            // Точка инверсии
            // Такая формула обусловлена следующим:
            //  - не должно получатся число, равное длине строки, потому что 
            //    нумерация символов zero-based и будет ошибка;
            int crossoverPointPosition = rnd.Next(parentChromo.Length - 1);

            // Разделим хромосому на части, первая из которых останется неизменной, 
            // а вторая инвертируется
            string parentFirstPart = parentChromo.Substring(0, crossoverPointPosition);
            string parentSecondPart = parentChromo.Substring(crossoverPointPosition);

            // Инвертируем вторую часть хромосомы
            string newSecondPart = string.Empty;
            // Проверим каждый ген в этой части хромосомы
            char[] secondPart = parentSecondPart.ToCharArray();
            foreach (char gene in secondPart)
            {
                // Выполним добавление гена к новой хромосоме,
                // попутно инвертировав его
                switch (gene)
                {
                    case '1':
                        newSecondPart += "0";
                        break;
                    case '0':
                        newSecondPart += "1";
                        break;
                }
            }

            // Составим хромосому потомка
            string сhildChromo = parentFirstPart + newSecondPart;

            // Получим и добавим в популяцию потомка
            AdditiveIndividual child = new AdditiveIndividual(
                population.GetFreeUnitNumber(),
                newGenerationNumber,
                attributes);
            child.UpdateAttributes(сhildChromo);
            population.Add(child.Number, child);
        }
    }
}
