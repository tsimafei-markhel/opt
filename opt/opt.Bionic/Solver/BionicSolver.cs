using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using opt.Bionic.DataModel;
using opt.Bionic.Helpers;
using opt.DataModel;
using opt.Provider;
using opt.Provider.Xml;

namespace opt.Bionic.Solver
{
    public sealed class BionicSolverSettings
    {
        public uint MaxGenerations { get; set; }
        public uint DescendantsNum { get; set; }
        public bool ApplyElitism { get; set; }
        public uint InitialPopulationSize { get; set; }
        public uint DescendantsRangePercent { get; set; }
        public uint SelectionCap { get; set; }
        public string CalcApplicationPath { get; set; }
        public string CalcApplicationCommandLineArgumentsFormat { get; set; }

        public BionicSolverSettings()
        {
            MaxGenerations = 20;
            DescendantsNum = 5;
            ApplyElitism = false;
            InitialPopulationSize = 50;
            DescendantsRangePercent = 5;
            SelectionCap = 10;
            CalcApplicationPath = string.Empty;
            CalcApplicationCommandLineArgumentsFormat = "{0}";
        }
    }

    public sealed class SolverFinishedEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public SolverFinishedEventArgs()
            : this(string.Empty)
        {
        }

        public SolverFinishedEventArgs(
            string message)
        {
            Message = message;
        }
    }

    public sealed class BionicSolver
    {
        // TODO: Dependency injection.
        private readonly IModelProvider modelProvider = new XmlModelProvider();

        public event EventHandler<EventArgs> SolverStarting;
        public event EventHandler<EventArgs> SolverStarted;
        public event EventHandler<SolverFinishedEventArgs> SolverFinished;
        public event EventHandler<EventArgs> PopulationUpdated;

        public void Solve(BionicModel model, BionicSolverSettings settings)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            OnSolverStarting(new EventArgs());

            IInitialPopulationGenerator initializer = InitialPopulationGeneratorFactory.CreateInitialPopulationGenerator();
            ISelector selector = SelectorFactory.CreateSelector();
            IBreeder breeder = BreederFactory.CreateBreeder();

            // 1. Zeroing generation number
            model.CurrentGeneration = 0;

            OnSolverStarted(new EventArgs());

            // 2. Creating initial population
            CopyIndividuals(initializer.GenerateInitialPopulation(settings.InitialPopulationSize, model.Attributes), model.CurrentPopulation);
            CalculateFitness(model, model.CurrentPopulation, settings);
            model.ApplyFunctionalConstraints();

            OnPopulationUpdated(new EventArgs());

            while (model.CurrentGeneration < settings.MaxGenerations)
            {
                // 3. Selecting most fit individuals
                IEnumerable<Individual> fitIndividuals = selector.Select(model.CurrentPopulation, model.FitnessCriterion, settings.SelectionCap);
                if (fitIndividuals.Count() == 0)
                {
                    OnSolverFinished(new SolverFinishedEventArgs("All individuals are inactive"));
                    return;
                }

                // Selected subpopulation will contain only selected active individuals
                Population selectedSubPopulation = new Population(fitIndividuals.Count());
                foreach (Individual fitIndividual in fitIndividuals)
                {
                    selectedSubPopulation.Add(fitIndividual);
                }

                // 4. Breeding the selected ones
                IEnumerable<Individual> descendants = breeder.Breed(selectedSubPopulation, model.Attributes, 
                    settings.DescendantsRangePercent, settings.DescendantsNum, model.CurrentGeneration + 1);
                if (descendants.Count() == 0)
                {
                    OnSolverFinished(new SolverFinishedEventArgs("No descendants was created"));
                    return;
                }

                // Descendants subpopulation will contain only new individuals
                Population descendantsSubPopulation = new Population(descendants.Count());
                foreach (Individual descendant in descendants)
                {
                    descendantsSubPopulation.Add(descendant);
                }

                // 5. Calculating fitness of the descendants
                CalculateFitness(model, descendantsSubPopulation, settings);
                // At this point, all descendants are still active, although
                // there may be individuals that don't fit f. c.

                // 6. Forming new population
                if (settings.ApplyElitism)
                {
                    // First unite descendants with their parents (elitism)
                    // We can do this without fear of ID collision because this
                    // was taken into account on the breeding step
                    CopyIndividuals(descendantsSubPopulation, selectedSubPopulation);

                    // Now this united population becomes current, we just
                    // throw away old individuals
                    model.CurrentPopulation.Clear();
                    CopyIndividuals(selectedSubPopulation, model.CurrentPopulation);
                }
                else
                {
                    // We throw away parents and old individuals,
                    // descendants are taking over the place
                    model.CurrentPopulation.Clear();
                    CopyIndividuals(descendantsSubPopulation, model.CurrentPopulation);
                }

                model.ApplyFunctionalConstraints();

                // 7. Updating current generation number
                model.CurrentGeneration = model.CurrentPopulation.Max(ind => ind.Value.GenerationNumber);

                OnPopulationUpdated(new EventArgs());
            }

            OnSolverFinished(new SolverFinishedEventArgs());
        }

        private void CalculateFitness(BionicModel model, Population targetPopulation, BionicSolverSettings settings)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (targetPopulation == null)
            {
                throw new ArgumentNullException("targetPopulation");
            }

            BionicModel tempModel = InitTempBionicModel(model, targetPopulation);

            Model optModel = ModelsConverter.BionicModelToModel(tempModel);
            string exchangeFilePath = CreateExchangeFile(optModel, settings);

            // This call will wait for external application to exit
            RunCalculationApplication(exchangeFilePath, settings);

            optModel = modelProvider.Load(exchangeFilePath);
            foreach (Experiment experiment in optModel.Experiments.Values)
            {
                targetPopulation[experiment.Id].FitnessValue = experiment.CriterionValues[model.FitnessCriterion.Id];

                foreach (TId constraintId in optModel.FunctionalConstraints.Keys)
                {
                    targetPopulation[experiment.Id].ConstraintValues[constraintId] = experiment.ConstraintValues[constraintId];
                }
            }
        }

        private static void RunCalculationApplication(string exchangeFilePath, BionicSolverSettings settings)
        {
            string argumentsFormat = settings.CalcApplicationCommandLineArgumentsFormat.Trim();
            string arguments = string.Format(argumentsFormat, "\"" + exchangeFilePath + "\"");

            ProcessStartInfo externalAppInfo = new ProcessStartInfo();
            externalAppInfo.FileName = settings.CalcApplicationPath;
            externalAppInfo.Arguments = " " + arguments;
            externalAppInfo.UseShellExecute = false;

            Process extAppProc = Process.Start(externalAppInfo);
            extAppProc.WaitForExit();
        }

        private string CreateExchangeFile(Model optModel, BionicSolverSettings settings)
        {
            string exchangeFilePath = Path.Combine(Path.GetDirectoryName(settings.CalcApplicationPath), "temp.xml");
            modelProvider.Save(optModel, exchangeFilePath);

            // Wait for the file to be created and written to disk
            // TODO: Looks like a dirty hack. Maybe there is more elegant solution...
            while (true)
            {
                if (File.Exists(exchangeFilePath))
                {
                    break;
                }

                Thread.Sleep(500);
            }

            return exchangeFilePath;
        }

        private BionicModel InitTempBionicModel(BionicModel sourceModel, Population targetPopulation)
        {
            BionicModel tempModel = (BionicModel)sourceModel.Clone();
            tempModel.CurrentPopulation.Clear();
            CopyIndividuals(targetPopulation, tempModel.CurrentPopulation);
            return tempModel;
        }

        private void CopyIndividuals(Population copyFrom, Population copyTo)
        {
            if (copyFrom == null)
            {
                throw new ArgumentNullException("copyFrom");
            }

            if (copyTo == null)
            {
                throw new ArgumentNullException("copyTo");
            }

            foreach (Individual individual in copyFrom.Values)
            {
                // Do not use Clone(), references should stay intact
                copyTo.Add(individual);
            }
        }

        private void OnSolverStarting(EventArgs e)
        {
            EventHandler<EventArgs> eventDelegate = SolverStarting;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }

        private void OnSolverStarted(EventArgs e)
        {
            EventHandler<EventArgs> eventDelegate = SolverStarted;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }

        private void OnSolverFinished(SolverFinishedEventArgs e)
        {
            EventHandler<SolverFinishedEventArgs> eventDelegate = SolverFinished;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }

        private void OnPopulationUpdated(EventArgs e)
        {
            EventHandler<EventArgs> eventDelegate = PopulationUpdated;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }
    }
}