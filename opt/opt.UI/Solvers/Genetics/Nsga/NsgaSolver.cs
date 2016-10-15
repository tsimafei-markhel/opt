using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Text;
using opt.UI.Helpers;
using opt.Xml;

namespace opt.Solvers.Genetics.Nsga
{
    public static class NsgaSolver
    {
        private static readonly TextModelProviderSettings textProviderSettings = new TextModelProviderSettings()
        {
            InformationFilePath = Application.StartupPath + Program.ApplicationSettings.QuantitiesFileName,
            ParametersFilePath = Application.StartupPath + Program.ApplicationSettings.ParametersFileName,
            ResultFilePath = Application.StartupPath + Program.ApplicationSettings.ResultsFileName
        };

        /// <summary>
        /// Метод для поиска решения с помощью генетического алгоритма
        /// </summary>
        /// <param name="model">Оптимизационная модель, эксперименты из которой 
        /// выступят в качестве начальной популяции</param>
        /// <param name="gaParams">Параметры генетического алгоритма</param>
        /// <param name="table">Таблица для отображения процесса поиска решения. 
        /// Если null, то процесс поиска решения не отображается</param>
        public static NsgaMethodResult FindDecision(
            ref Model model,
            NsgaParams gaParams,
            DataGridView table)
        {
            bool showProcess = (table != null);
            int currentGeneration = 0;

            // 1. Получим начальную популяцию из модели
            var population = ModelToPopulation(model, currentGeneration);

            // 2. Отыщем в ней паретовские фронты, рассчитаем ранги и разреженности
            ComputeRanksAndSparsities(population, model.Criteria);

            // Если надо, подготовим таблицу к выводу процесса и
            // выведем начальную популяцию (без разделителя)
            if (showProcess)
            {
                NsgaDataGridFiller.PrepareProcessDataGrid(table);
                NsgaDataGridFiller.AddPopulationToDataGrid(table, population, false);
            }

            // 3. Набором лучших особей будем считать паретовский фронт всей популяции
            var bestIndividuals = GetPopulationParetoFront(population);

            // 4. Пока не достигнуто нужное количество поколений
            while (currentGeneration < gaParams.MaxGenerationsNumber)
            {
                // Увеличим счетчик поколений
                currentGeneration++;

                // 5.1. Отбор
                var selectedIndividuals =
                    NsgaSelection.TournamentSelection(population, gaParams.SelectionLimit);

                // 5.2. Скрещивание
                selectedIndividuals =
                    NsgaCrossover.OnePointCrossover(selectedIndividuals, currentGeneration);

                // 7. Объединим предков с потомками
                selectedIndividuals = UnitePopulations(population, selectedIndividuals);

                // 6. Расчет приспособленности
                // Модель обновится, метод CalcUnitsFitness рассчитает
                // для популяции значения функции приспособленности, а для 
                // модели - значения критериев и Ф.О.
                model = PopulationToModel(model, selectedIndividuals);
                CalcUnitsFitness(
                    ref model,
                    ref selectedIndividuals, 
                    gaParams.ExternalAppPath);

                // 8. Отыщем в объединенной популяции паретовские фронты, рассчитаем ранги и разреженности
                ComputeRanksAndSparsities(selectedIndividuals, model.Criteria);

                // 9. Сохраним паретовский фронт текущей популяции как лучшее решение
                bestIndividuals = GetPopulationParetoFront(selectedIndividuals);

                // 10. Образуем популяцию для нового шага
                population = NsgaSelection.SelectBestIndividuals(selectedIndividuals, gaParams.InitialGenerationCount);

                // Если надо, то выведем на экран информацию (с разделителем)
                if (showProcess)
                {
                    NsgaDataGridFiller.AddPopulationToDataGrid(table, selectedIndividuals, true);
                }
            }

            // Подготовим результат на основе конечной популяции
            var result = PrepareResult(bestIndividuals);

            // Вернем результат
            return result;
        }

        private static Population<NsgaIndividual> UnitePopulations(Population<NsgaIndividual> initPop, Population<NsgaIndividual> selectedIndividuals)
        {
            var result = new Population<NsgaIndividual>(selectedIndividuals.GetMaxUnitNumber());

            foreach (NsgaIndividual individual in initPop)
            {
                result.Add(individual.Number, (NsgaIndividual)individual.Clone());
            }
            
            foreach (NsgaIndividual individual in selectedIndividuals)
            {
                if (result.ContainsUnit(individual.Number))
                {
                    throw new Exception("Suprisingly, but population already contains unit with such number");
                }
                result.Add(individual.Number, (NsgaIndividual)individual.Clone());
            }
            
            return result;
        }

        private static void ComputeRanksAndSparsities(Population<NsgaIndividual> population, Dictionary<TId, Criterion> criteria)
        {
            var fronts = ComputeRanks(population, criteria);
            foreach (var front in fronts.Values)
            {
                ComputeFrontSparsities(front, population, criteria);
            }
        }

        private static void ComputeFrontSparsities(IList<int> front, Population<NsgaIndividual> population, Dictionary<TId, Criterion> criteria)
        {
            foreach (NsgaIndividual indiviadual in population)
            {
                if (front.Contains(indiviadual.Number))
                {
                    indiviadual.Sparsity = 0;
                }
            }

            foreach (var criterion in criteria)
            {
                List<SortableDouble> sortedIndividuals = front.Select<int, SortableDouble>(
                        ind => new SortableDouble() { Direction = SortDirection.Descending, Id = ind, Value = population[ind].Criteria[criterion.Key] }
                    ).ToList();
                sortedIndividuals.Sort();

                IList<int> sortedFront = sortedIndividuals.Select<SortableDouble, int>(ind => ind.Id).ToList();
                (population[sortedFront[0]]).Sparsity = Double.MaxValue;
                (population[sortedFront[sortedFront.Count - 1]]).Sparsity = Double.MaxValue;
                for(int i = 1; i < sortedFront.Count - 1; i++)
                {
                    (population[sortedFront[i]]).Sparsity +=
                        Math.Abs(population[sortedFront[i + 1]].Criteria[criterion.Key] - 
                                 population[sortedFront[i - 1]].Criteria[criterion.Key]);
                }
            }
        }

        private static IDictionary<int, IList<int>> ComputeRanks(Population<NsgaIndividual> population, Dictionary<TId, Criterion> criteria)
        {
            var cPopulation = (Population<NsgaIndividual>)population.Clone();
            var ranks = new Dictionary<int, IList<int>>();

            int rank = 1;
            while(cPopulation.Count > 0)
            {
                var front = ComputeParetoFront(cPopulation, criteria);
                foreach (int i in front)
                {
                    population[i].Rank = rank;
                    population[i].IsRanked = true;
                    cPopulation.Remove(i);
                }
                ranks.Add(rank, front);
                rank++;
            }

            return ranks;
        }

        private static IList<int> ComputeParetoFront(Population<NsgaIndividual> population, Dictionary<TId, Criterion> criteria)
        {
            var currentFront = new List<int>();

            foreach (NsgaIndividual individual in population)
            {
                currentFront.Add(individual.Number);
                var cfCopy = new List<int>(currentFront);
                foreach (int frontIndividualId in cfCopy)
                {
                    if (frontIndividualId == individual.Number)
                    {
                        continue;
                    }

                    var frontIndividual = population[frontIndividualId];
                    frontIndividual.Rank = -1;
                    frontIndividual.IsRanked = false;
                    if (CheckStrictDomination(criteria, frontIndividual, individual))
                    {
                        currentFront.Remove(individual.Number);
                        break;
                    }
                    else if (CheckStrictDomination(criteria, individual, frontIndividual))
                    {
                        currentFront.Remove(frontIndividualId);
                    }
                }
            }

            return currentFront;
        }

        /// <summary>
        /// Сновую популяцию на основе переданной. В новую популяцию попадают только особи
        /// с рангом 1
        /// </summary>
        /// <param name="population">Исходная популяция</param>
        /// <returns>Популяция, целиком состоящая из паретовского фронта исходной</returns>
        private static Population<NsgaIndividual> GetPopulationParetoFront(Population<NsgaIndividual> population)
        {
            var result = new Population<NsgaIndividual>();

            foreach (NsgaIndividual individual in population)
            {
                if (individual.Rank == 1)
                {
                    result.Add(individual.Number, (NsgaIndividual)individual.Clone());
                }
            }

            return result;
        }

        /// <summary>
        /// Метод для преобразования модели в популяцию
        /// </summary>
        /// <param name="model">Исходная модель для преобразования</param>
        /// <param name="generationNumber">Номер поколения, который будет присвоен 
        /// всем особям в создаваемой популяции</param>
        /// <returns></returns>
        private static Population<NsgaIndividual> ModelToPopulation(Model model, int generationNumber)
        {
            var population = new Population<NsgaIndividual>();

            // 1. Сформируем словарь с параметрами особей. Все особи
            // данной популяции должны характеризоваться одинаковым 
            // набором параметров, поэтому сформируем его заранее, а 
            // потом будем передавать в качестве параметра конструктора 
            // всем особям. Значения параметров будем затем назначать 
            // вручную
            var attributes = new Dictionary<TId, IndividualAttribute>();

            foreach (Parameter param in model.Parameters.Values)
            {
                var attribute =
                    new IndividualAttribute(
                        param.Id,
                        param.MinValue,
                        param.MaxValue,
                        Program.ApplicationSettings.ValuesDecimalPlaces);
                attributes.Add(param.Id, attribute);
            }

            // Подготовим нормализованные критерии
            var normalizedExpCriteria = new Dictionary<TId, Dictionary<TId, double>>();
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (!exp.IsActive)
                {
                    continue;
                }

                var critValues = new Dictionary<TId, double>();

                normalizedExpCriteria.Add(exp.Id, critValues);
            }

            // Смена ингридиента:
            // Для каждого максимизируемого критерия выполним Y_new = 1 / Y_old
            // так он станет минимизируемым
            // Затем - нормализация
            var experiments = PrepareCriteria(model);

            // 2. Добавим в популяцию особи - столько же, сколько 
            // АКТИВНЫХ экспериментов в модели
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (!exp.IsActive)
                {
                    continue;
                }

                var unit = new NsgaIndividual(
                        exp.Number,
                        generationNumber,
                        attributes);
                // Запишем значения оптимизируемых параметров эксперимента 
                // в словарь признаков особи
                foreach (Parameter param in model.Parameters.Values)
                {
                    unit.Attributes[param.Id].Value =
                        exp.ParameterValues[param.Id];
                    // Рассчитаем генетический код этой особи
                    unit.Attributes[param.Id].ResolveCodeFromValue();
                }
                // Запишем значения критериев оптимальности в словарь
                // критериев особи
                foreach (Criterion crit in model.Criteria.Values)
                {
                    unit.Criteria.Add(crit.Id, experiments[exp.Id].CriterionValues[crit.Id]);
                }
                // Добавим особь в популяцию
                population.Add(exp.Number, unit);
            }

            return population;
        }

        private static Dictionary<TId, Experiment> PrepareCriteria(Model model)
        {
            var experiments = new Dictionary<TId, Experiment>();

            foreach (Experiment exp in model.Experiments.Values)
            {
                if (!exp.IsActive)
                {
                    continue;
                }

                experiments.Add(exp.Id, new Experiment(exp.Id, exp.Number));
            }

            foreach (Criterion crit in model.Criteria.Values)
            {
                foreach (Experiment exp in model.Experiments.Values)
                {
                    if (!exp.IsActive)
                    {
                        continue;
                    }

                    //if (crit.Type == CriterionType.Maximizing)
                    //{
                    //    double oldCriterionValue = exp.CriterionValues[crit.Id];
                    //    if (oldCriterionValue == 0.0)
                    //    {
                    //        oldCriterionValue = 0.00001;
                    //    }
                    //    experiments[exp.Id].CriterionValues.Add(crit.Id, 1.0/oldCriterionValue);
                    //}
                    //else
                    //{
                        experiments[exp.Id].CriterionValues.Add(crit.Id, exp.CriterionValues[crit.Id]);
                    //}
                }

                Dictionary<TId, double> normalizedCrit = NormalizationHelper.NormalizeCriterionValues(experiments, crit);
                    //Normalization.NormalizeCriterion(experiments, crit);

                foreach (Experiment exp in experiments.Values)
                {
                    exp.CriterionValues[crit.Id] = normalizedCrit[exp.Id];
                }
            }

            return experiments;
        }

        private static void CalcUnitsFitness(
            ref Model initModel,
            ref Population<NsgaIndividual> population,
            string externalAppPath)
        {
            // У нас есть модель. Рассчитаем для нее с помощью внешней 
            // программы значения критериев оптимальности и Ф.О.
#if DUMMY
            // Запустим внешнюю программу и дождемся, пока она отработает
            if (!UseDummyExternalApplication(initModel, externalAppPath))
            {
                throw new Exception("Cannot calculate fitness values using external program");
            }
#else
            // Файл для обмена данными между opt и расчетной программой
            string dataFilePath = System.IO.Path.GetDirectoryName(externalAppPath) + "\\_ga_temp_file.xml";

            // Запустим внешнюю программу и дождемся, пока она отработает
            if (!UseExternalApplication(
                    initModel,
                    externalAppPath,
                    dataFilePath))
            {
                throw new Exception("Can not calculate fitness values using external program");
            }

            // Раз программа отработала, прочтем результаты из файла
            initModel = XmlModelProvider.Open(dataFilePath);

            // Удалим файл с данными
            if (File.Exists(dataFilePath))
            {
                File.Delete(dataFilePath);
            }
#endif
            var experiments = PrepareCriteria(initModel);

            // Из модели выберем значения критериев оптимальности
            foreach (Experiment exp in experiments.Values)
            {
                int unitNumber = initModel.Experiments[exp.Id].Number;
                var individual = population[unitNumber];
                foreach (Criterion crit in initModel.Criteria.Values)
                {
                    if (individual.Criteria.ContainsKey(crit.Id))
                    {
                        individual.Criteria[crit.Id] = exp.CriterionValues[crit.Id];
                    }
                    else
                    {
                        individual.Criteria.Add(crit.Id, exp.CriterionValues[crit.Id]);
                    }
                }
            }

            // Применим Ф.О. к модели
            initModel.ApplyFunctionalConstraints();

            // Пометим на удаление в популяции особи, соответсвующие экспериментам, 
            // ставшим неактивными после применения Ф.О.
            foreach (Experiment exp in initModel.Experiments.Values)
            {
                if (!exp.IsActive)
                {
                    population.MarkForRemoval(exp.Number);
                }
            }
            // И удалим помеченные
            population.RemoveMarked();
        }

#if DUMMY
        private static bool UseDummyExternalApplication(Model initModel, string externalAppPath)
        {
            try
            {
                TextModelProvider.WriteModel(initModel, textProviderSettings);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Не удалось создать файлы с данными о модели\nОригинальное сообщение: " + ex.Message);
                return false;
            }

            // Запустим программу на выполнение
            ProcessStartInfo midPrgInfo = new ProcessStartInfo();
            midPrgInfo.FileName = externalAppPath;
            midPrgInfo.WorkingDirectory = Path.GetDirectoryName(externalAppPath);
            midPrgInfo.UseShellExecute = true;

            Process extAppProc = Process.Start(midPrgInfo);
            extAppProc.EnableRaisingEvents = true;
            
            // Дождемся, пока внешний процесс не завершится
            while (!extAppProc.HasExited)
            {
                Thread.Sleep(500);
            }

            // Распарсим результат
            ParseTextResults(initModel);

            return true;
        }

        private static void ParseTextResults(Model initModel)
        {
            try
            {
                TextModelProvider.ReadResultToModel(initModel, textProviderSettings);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Невозможно считать файл с результатами расчета\nОригинальное сообщение: " + ex.Message);
                return;
            }
        }
#endif

        private static bool UseExternalApplication(
            Model initModel,
            string externalAppPath,
            string dataFilePath)
        {
            // Запишем файл модели
            try
            {
                XmlModelProvider.Save(initModel, dataFilePath);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError("Не удалось создать файл для обмена данными по указанному пути\nОригинальное сообщение: " + ex.Message);
                return false;
            }
            // Дождемся, пока будет создан файл
            bool fileExists = false;
            while (!fileExists)
            {
                if (System.IO.File.Exists(dataFilePath))
                {
                    fileExists = true;
                }
                else
                {
                    Thread.Sleep(500);
                }
            }

            // Запуск внешней проги и ожидание расчета
            ProcessStartInfo midPrgInfo = new ProcessStartInfo();
            midPrgInfo.FileName = externalAppPath;
            midPrgInfo.Arguments = "\"" + dataFilePath + "\"";
            midPrgInfo.UseShellExecute = false;

            Process extAppProc = Process.Start(midPrgInfo);
            extAppProc.EnableRaisingEvents = true;

            // Дождемся, пока внешний процесс не завершится
            while (!extAppProc.HasExited)
            {
                Thread.Sleep(500);
            }

            return true;
        }

        /// <summary>
        /// Метод для преобразования популяции в модель
        /// </summary>
        /// <param name="initModel">Изначальная модель, нужна для получения 
        /// информации о параметрах, критериях и Ф.О., которая не хранится 
        /// в популяции</param>
        /// <param name="population">Популяция, которую нужно превратить в модель</param>
        /// <returns>Модель, которая получена из популяции</returns>
        private static Model PopulationToModel(Model initModel, Population<NsgaIndividual> population)
        {
            var result = new Model();

            // Скопируем в новую модель информацию об оптимизируемых параметрах
            foreach (Parameter param in initModel.Parameters.Values)
            {
                result.Parameters.Add((Parameter)param.Clone());
            }

            // Скопируем в новую модель информацию о критериях оптимальности
            foreach (Criterion crit in initModel.Criteria.Values)
            {
                result.Criteria.Add((Criterion)crit.Clone());
            }

            // Скопируем в новую модель информацию о функциональных ограничениях
            foreach (Constraint constr in initModel.FunctionalConstraints.Values)
            {
                result.FunctionalConstraints.Add((Constraint)constr.Clone());
            }

            // Скопируем в модель информацию об экспериментах
            // Сколько в популяции особей, столько будет в модели экспериментов
            foreach (NsgaIndividual unit in population)
            {
                Experiment exp = new Experiment(unit.Number, unit.Number);
                // Значения параметров для данной особи
                foreach (Parameter param in result.Parameters.Values)
                {
                    exp.ParameterValues.Add(param.Id, unit.Attributes[param.Id].Value);
                }
                // Добавим эксперимент в модель
                result.Experiments.Add(exp);
            }

            // Вернем модель
            return result;
        }

        /// <summary>
        /// Метод для получения результатов работы генетического алгоритма
        /// </summary>
        /// <param name="population">Популяция, на основе которой строится результат</param>
        /// <returns>Результат работы генетического алгоритма</returns>
        private static NsgaMethodResult PrepareResult(Population<NsgaIndividual> population)
        {
            var result = new NsgaMethodResult("Генетический алгоритм многокритериальной оптимизации NSGA-II");

            foreach (NsgaIndividual individual in population)
            {
                result.SortedPoints.Add(individual.Number);
            }

            return result;
        }

        // TODO: Think over reusing ParetoFinder from opt.Core
        /// <summary>
        /// Метод для проверки строгого доминирования первой особи
        /// над второй
        /// </summary>
        /// <param name="criteria">Список критериев оптимальности</param>
        /// <param name="firstIndividual">Первая особь</param>
        /// <param name="secondIndividual">Вторая особь</param>
        /// <returns>True, если первая особь строго доминирует над второй, иначе false</returns>
        public static bool CheckStrictDomination(
            Dictionary<TId, Criterion> criteria,
            NsgaIndividual firstIndividual,
            NsgaIndividual secondIndividual)
        {
            // По каждому критерию - надо проверить все
            foreach (Criterion crit in criteria.Values)
            {
                // Для удобства скопируем значения
                double firstIndividualValue = firstIndividual.Criteria[crit.Id];
                double secondIndividualValue = secondIndividual.Criteria[crit.Id];

                // Если при переходе от первой особи ко второй
                // мы смогли улучшить хоть один критерий, то первая
                // особь НЕ ДОМИНИРУЕТ над второй
                switch (crit.Type)
                {
                    case CriterionType.Minimizing:
                        if (firstIndividualValue > secondIndividualValue) return false;
                        break;
                    case CriterionType.Maximizing:
                        if (firstIndividualValue < secondIndividualValue) return false;
                        break;
                }
            }

            // Если при переходе от первой особи ко второй
            // мы не улучшили ни одного критерия, то первая
            // особь ДОМИНИРУЕТ над второй
            return true;
        }
    }
}