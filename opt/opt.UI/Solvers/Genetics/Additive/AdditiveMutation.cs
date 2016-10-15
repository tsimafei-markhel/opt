using System;

namespace opt.Solvers.Genetics.Additive
{
    public abstract class AdditiveMutation
    {
        public static AdditivePopulation PerformMutation(
            AdditivePopulation initPop,
            double mutationProbability)
        {
            // Реализация мутации
            // Генератор случайных чисел
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Second);

            // В популяции переберем каждую особь
            foreach (AdditiveIndividual unit in initPop)
            {
                string newChromo = string.Empty;
                // Для данной особи проверим каждый ген в 
                // хромосоме
                char[] unitChromo = unit.GetChromo().ToCharArray();
                foreach (char gene in unitChromo)
                {
                    double rndNum = rnd.NextDouble();
                    // Если выпало меньше, чем вероятность, 
                    // то мутация произошла, иначе - нет
                    if (rndNum <= mutationProbability)
                    {
                        // Выполним добавление гена к новой хромосоме,
                        // попутно инвертировав его
                        switch (gene)
                        {
                            case '1':
                                newChromo += "0";
                                break;
                            case '0':
                                newChromo += "1";
                                break;
                        }
                    }
                    else
                    {
                        // Выполним добавление гена к новой хромосоме,
                        // не инвертируя его
                        newChromo += gene.ToString();
                    }
                }
                // Обновим данные об особи на основе новой
                // хромосомы
                unit.UpdateAttributes(newChromo);
                // Обнулим значение пригодности, потому что оно уже 
                // не соответствует значению признаков
                unit.FitnessValue = double.NaN;
            }

            // Вернем измененную популяцию
            return initPop;
        }
    }
}
