using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using opt.DataModel;
using opt.Helpers;
using opt.Solvers.IntegralCriterion;
using opt.Text;
using opt.UI.Helpers;
using opt.Xml;

// TODO: Use Id instead of Number in the below

namespace opt.Solvers.Genetics.Additive
{
    public static class AdditiveSolver
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
        public static AdditiveMethodResult FindDecision(Model model, AdditiveParams gaParams, DataGridView table)
        {
            bool showProcess = (table != null);
            int currentGeneration = 0;

            // 1. Получим начальную популяцию из модели
            AdditivePopulation population = 
                AdditiveSolver.ModelToPopulation(model, currentGeneration);
            // Рассчитаем значения функции приспособленности
            AdditiveSolver.CalcUnitsFitness(
                    ref model,
                    ref population,
                    gaParams.ExternalAppPath);

            // Если надо, подготовим таблицу к выводу процесса и
            // выведем начальную популяцию (без разделителя)
            if (showProcess)
            {
                AdditiveDataGridFiller.PrepareProcessDataGrid(table);
                AdditiveDataGridFiller.AddPopulationToDataGrid(table, population, false);
            }

            // 2. Пока не достигнуто нужное количество поколений
            while (currentGeneration < gaParams.MaxGenerationsNumber)
            {
                // Увеличим счетчик поколений
                currentGeneration++;

                // 3. Отбор
                population = 
                    AdditiveSelection.TournamentSelection(population, gaParams.SelectionLimit);

                // 4. Скрещивание
                population =
                    AdditiveCrossover.OnePointCrossover(population, currentGeneration);

                // 5. Мутация
                population =
                    AdditiveMutation.PerformMutation(population, gaParams.MutationProbability);

                // 6. Расчет приспособленности
                // Модель обновится, метод CalcUnitsFitness рассчитает
                // для популяции значения функции приспособленности, а для 
                // модели - значения критериев и Ф.О.
                model = AdditiveSolver.PopulationToModel(model, population);
                AdditiveSolver.CalcUnitsFitness(
                    ref model, 
                    ref population, 
                    gaParams.ExternalAppPath);

                // Если надо, то выведем на экран информацию (с разделителем)
                if (showProcess)
                {
                    AdditiveDataGridFiller.AddPopulationToDataGrid(table, population, true);
                }
            }

            // Подготовим результат на основе конечной популяции
            AdditiveMethodResult result = AdditiveSolver.PrepareResult(population);

            // Вернем результат
            return result;
        }

        /// <summary>
        /// Метод для преобразования модели в популяцию
        /// </summary>
        /// <param name="model">Исходная модель для преобразования</param>
        /// <param name="generationNumber">Номер поколения, который будет присвоен 
        /// всем особям в создаваемой популяции</param>
        /// <returns></returns>
        private static AdditivePopulation ModelToPopulation(Model model, int generationNumber)
        {
            AdditivePopulation pop = new AdditivePopulation();

            // 1. Сформируем словарь с параметрами особей. Все особи
            // данной популяции должны характеризоваться одинаковым 
            // набором параметров, поэтому сформируем его заранее, а 
            // потом будем передавать в качестве параметра конструктора 
            // всем особям. Значения параметров будем затем назначать 
            // вручную
            Dictionary<TId, IndividualAttribute> attributes =
                new Dictionary<TId, IndividualAttribute>();

            foreach (Parameter param in model.Parameters.Values)
            {
                IndividualAttribute attribute =
                    new IndividualAttribute(
                        param.Id,
                        param.MinValue,
                        param.MaxValue,
                        Program.ApplicationSettings.ValuesDecimalPlaces);
                attributes.Add(param.Id, attribute);
            }

            // 2. Добавим в популяцию особи - столько же, сколько 
            // АКТИВНЫХ экспериментов в модели
            foreach (Experiment exp in model.Experiments.Values)
            {
                if (exp.IsActive)
                {
                    AdditiveIndividual unit =
                        new AdditiveIndividual(
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
                    // Добавим особь в популяцию
                    pop.Add(exp.Number, unit);
                }
            }

            return pop;

            throw new NotImplementedException();
        }

        private static void CalcUnitsFitness(
            ref Model initModel, 
            ref AdditivePopulation population,
            string externalAppPath)
        {
            // У нас есть модель. Рассчитаем для нее с помощью внешней 
            // программы значения критериев оптимальности и Ф.О.
#if DUMMY
            // Запустим внешнюю программу и дождемся, пока она отработает
            if (!AdditiveSolver.UseDummyExternalApplication(initModel, externalAppPath))
            {
                throw new Exception("Can not calculate fitness values using external program");
            }
#else
            // Файл для обмена данными между opt и расчетной программой
            string dataFilePath = System.IO.Path.GetDirectoryName(externalAppPath) + "\\_ga_temp_file.xml";

            // Запустим внешнюю программу и дождемся, пока она отработает
            if (!AdditiveSolver.UseExternalApplication(
                    initModel,
                    externalAppPath,
                    dataFilePath))
            {
                throw new Exception("Can not calculate fitness values using external program");
            }

            // Раз программа отработала, прочтем результаты из файла
            initModel = XmlModelProvider.Open(dataFilePath);

            // Удалим файл с данными
            if (System.IO.File.Exists(dataFilePath))
            {
                System.IO.File.Delete(dataFilePath);
            }
#endif
            // Применим решатель для аддитивного критерия, чтобы получить его значения.
            // Они послужат нам эквивалентом функции приспособленности
            AdditiveCriterionSolver solver = new AdditiveCriterionSolver();
            IntegralCriterionMethodResult result = solver.FindDecision(initModel);

            // Из результатов аддитивного критерия выдерем его значения
            foreach (TId expId in result.SortedPoints)
            {
                int unitNumber = initModel.Experiments[expId].Number;
                population[unitNumber].FitnessValue = result.AdditionalData[expId];
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
        private static Model PopulationToModel(Model initModel, AdditivePopulation population)
        {
            Model result = new Model();

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
            foreach (AdditiveIndividual unit in population)
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
        private static AdditiveMethodResult PrepareResult(AdditivePopulation population)
        {
            AdditiveMethodResult result = new AdditiveMethodResult("Генетический алгоритм", "Значение функции приспособленности");

            // Отсортируем результаты по возрастанию по значению
            // аддитивного критерия (меньше - лучше)
            List<SortableDouble> sortedIndividuals = population.Select<AdditiveIndividual, SortableDouble>(
                    ind => new SortableDouble() { Direction = SortDirection.Ascending, Id = ind.Number, Value = ind.FitnessValue }
                ).ToList();
            sortedIndividuals.Sort();

            // Заполним результаты
            foreach (SortableDouble sortedIndividual in sortedIndividuals)
            {
                result.SortedPoints.Add(sortedIndividual.Id);
                result.AdditionalData.Add(sortedIndividual.Id, sortedIndividual.Value);
            }

            return result;
        }
    }
}