using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using opt.DataModel;
using opt.Xml;

namespace mathcad.connector
{
    internal sealed class ProgressChangedEventArgs : EventArgs
    {
        public int MinProgress { get; private set; }
        public int MaxProgress { get; private set; }
        public int CurrentProgress { get; private set; }
        public string CurrentAction { get; private set; }

        public ProgressChangedEventArgs() : this(0, 1, 0, string.Empty)
        {
        }

        public ProgressChangedEventArgs(
            int minProgress,
            int maxProgress,
            int currentProgress,
            string currentAction)
        {
            MinProgress = minProgress;
            MaxProgress = maxProgress;
            CurrentProgress = currentProgress;
            CurrentAction = currentAction;
        }
    }

    internal sealed class Processor
    {
        private MathcadWrapper mathcadWrapper;
        private readonly string optFile;
        private Model model;

        public EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public EventHandler<EventArgs> ProcessingComplete;

        public Processor(string mathcadFilePath, string optFilePath)
        {
            if (string.IsNullOrEmpty(optFilePath))
            {
                throw new ArgumentNullException("optFilePath");
            }

            if (!File.Exists(optFilePath))
            {
                throw new ArgumentException("OPT model file does not exist", "optFilePath");
            }

            mathcadWrapper = new MathcadWrapper(mathcadFilePath);
            optFile = optFilePath;

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        ~Processor()
        {
            if (mathcadWrapper != null)
            {
                mathcadWrapper.Close();
            }
        }

        public void ProcessModel(object data)
        {
            CancellationToken cancellationToken;
            if (data == null)
            {
                cancellationToken = new CancellationToken(false);
            }
            else
            {
                cancellationToken = (CancellationToken)data;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                OnProcessingComplete(new EventArgs());
                return;
            }

            model = XmlModelProvider.Open(optFile);
            if (cancellationToken.IsCancellationRequested)
            {
                OnProcessingComplete(new EventArgs());
                return;
            }

            int maxProgress = model.Experiments.Count;
            OnProgressChanged(new ProgressChangedEventArgs(0, maxProgress, 0, "Initialized"));

            int exp = 0;
            foreach (Experiment experiment in model.Experiments.Values)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                ProcessExperiment(experiment);
                OnProgressChanged(new ProgressChangedEventArgs(0, maxProgress, ++exp, "Processed experiment #" + experiment.Number.ToString()));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                OnProcessingComplete(new EventArgs());
                return;
            }

            XmlModelProvider.Save(model, optFile);

            OnProcessingComplete(new EventArgs());
        }

        private void ProcessExperiment(Experiment experiment)
        {
            experiment.CriterionValues.Clear();
            experiment.ConstraintValues.Clear();

            mathcadWrapper.RefreshWorksheet();

            foreach (KeyValuePair<TId, double> parameter in experiment.ParameterValues)
            {
                string parameterVariableIdentifier = model.Parameters[parameter.Key].VariableIdentifier;
                mathcadWrapper.SetValue(parameterVariableIdentifier, parameter.Value);
            }

            mathcadWrapper.Recalculate();

            foreach (Criterion criterion in model.Criteria.Values)
            {
                double value = mathcadWrapper.GetValue(criterion.VariableIdentifier);
                experiment.CriterionValues.Add(criterion.Id, value);
            }

            foreach (Constraint constraint in model.FunctionalConstraints.Values)
            {
                double value = mathcadWrapper.GetValue(constraint.VariableIdentifier);
                experiment.ConstraintValues.Add(constraint.Id, value);
            }
        }

        private void OnProgressChanged(ProgressChangedEventArgs e)
        {
            EventHandler<ProgressChangedEventArgs> eventDelegate = ProgressChanged;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }

        private void OnProcessingComplete(EventArgs e)
        {
            EventHandler<EventArgs> eventDelegate = ProcessingComplete;
            if (eventDelegate != null)
            {
                eventDelegate(this, e);
            }
        }
    }
}