using System;
using System.IO;
using System.Text;
using opt.DataModel;
using opt.Extensions;
using opt.UI.Helpers.DataModel;

namespace opt.UI.Exporters
{
    /// <summary>
    /// Provides basic functionality on exporting optimization results to UTF-8 text file
    /// </summary>
    public sealed class TextResultExporter : IDataExporter
    {
        /// <summary>
        /// <see cref="TextResultExporterSettings"/> to be used during export
        /// </summary>
        private TextResultExporterSettings settings;

        /// <summary>
        /// Helper class, contains various string constants and formats used during export
        /// </summary>
        private static class NamesAndFormats
        {
            public const string Constraints = "Функциональные ограничения:";
            public const string ConstraintFormat = "   {0}{1} {2} {3}";
            public const string Criteria = "Критерии оптимальности:";
            public const string CriterionFormat = "   {0}{1} → {2}";
            public const string DateLineFormat = "Дата:\t{0} GMT";
            public const string DateTimeFormat = "dd.MM.yyyy HH:mm:ss";
            public const string Delimiter = "================================================";
            public const string ExperimentNumberFormat = "   {0}.\t";
            public const string FileHeader = "Результаты поиска окончательного решения";
            public const string MethodLineFormat = "Метод:\t{0}";
            public const string ParameterFormat = "   {0}{1} [{2}; {3}]";
            public const string Parameters = "Оптимизируемые параметры:";
            public const string Results = "Окончательные результаты (в порядке ухудшения):";
            public const string ValueFormat = "{0} = {1}\r\n   \t";
            public const string VariableIdentifierFormat = " ({0})";
        }

        /// <summary>
        /// Gets <see cref="ExportableData"/> flags showing what parts of <see cref="Model"/> <see cref="TextResultExporter"/> can export
        /// </summary>
        public static ExportableData SupportedExportableData
        {
            get
            {
                return ExportableData.None | ExportableData.Results;
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="TextResultExporter"/> with proper <see cref="TextResultExporterSettings"/> settings
        /// </summary>
        /// <param name="exportSettings"><see cref="TextResultExporterSettings"/> instance with export settings</param>
        public TextResultExporter(TextResultExporterSettings exportSettings)
        {
            if (exportSettings == null)
            {
                throw new ArgumentNullException("exportSettings");
            }

            settings = exportSettings;
        }

        /// <summary>
        /// Exports <paramref name="model"/> (optimization results) to text format
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        public void Export(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            OptimizationMethodResult result = model.Properties.GetProperty<OptimizationMethodResult>(OptimizationMethodResult.PropertyName);
            if (result == null)
            {
                throw new InvalidOperationException("Optimization result was not found in model properties");
            }

            FileInfo outputFile = new FileInfo(settings.FilePath);
            WriteResult(model, result, outputFile);
        }

        /// <summary>
        /// Writes model information and optimization results
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="result"><see cref="OptimizationMethodResult"/> or derived class instance describing optimization result</param>
        /// <param name="outputFile">File to write results to</param>
        private void WriteResult(Model model, OptimizationMethodResult result, FileInfo outputFile)
        {
            using (FileStream outputFileStream = outputFile.OpenWrite())
            using (StreamWriter outputFileWriter = new StreamWriter(outputFileStream, Encoding.UTF8))
            {
                WriteFileHeader(result, outputFileWriter);
                WriteModelDetails(model, outputFileWriter);
                WriteOptimizationResult(model, result, outputFileWriter);

                outputFileWriter.Flush();
            }
        }

        /// <summary>
        /// Writes results file header with some basic information
        /// </summary>
        /// <param name="result"><see cref="OptimizationMethodResult"/> or derived class instance describing optimization result</param>
        /// <param name="outputFileWriter"><see cref="StreamWriter"/> to be used for the output</param>
        private void WriteFileHeader(OptimizationMethodResult result, StreamWriter outputFileWriter)
        {
            outputFileWriter.WriteLine(NamesAndFormats.Delimiter);
            outputFileWriter.WriteLine(NamesAndFormats.FileHeader);
            outputFileWriter.WriteLine(string.Format(NamesAndFormats.DateLineFormat, DateTime.UtcNow.ToString(NamesAndFormats.DateTimeFormat)));
            outputFileWriter.WriteLine(string.Format(NamesAndFormats.MethodLineFormat, result.MethodName));
            outputFileWriter.WriteLine(NamesAndFormats.Delimiter);
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
        }

        /// <summary>
        /// Writes model information (parameters, criteria, functional constraints)
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="outputFileWriter"><see cref="StreamWriter"/> to be used for the output</param>
        private void WriteModelDetails(Model model, StreamWriter outputFileWriter)
        {
            outputFileWriter.WriteLine(NamesAndFormats.Parameters);
            foreach (Parameter parameter in model.Parameters.Values)
            {
                string variableIdentifier = string.IsNullOrEmpty(parameter.VariableIdentifier)
                    ? string.Empty
                    : string.Format(NamesAndFormats.VariableIdentifierFormat, parameter.VariableIdentifier);
                outputFileWriter.WriteLine(string.Format(
                    NamesAndFormats.ParameterFormat,
                    parameter.Name,
                    variableIdentifier,
                    parameter.MinValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat),
                    parameter.MaxValue.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat)));
            }

            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine(NamesAndFormats.Criteria);
            foreach (Criterion criterion in model.Criteria.Values)
            {
                string variableIdentifier = string.IsNullOrEmpty(criterion.VariableIdentifier)
                    ? string.Empty
                    : string.Format(NamesAndFormats.VariableIdentifierFormat, criterion.VariableIdentifier);
                outputFileWriter.WriteLine(string.Format(
                    NamesAndFormats.CriterionFormat,
                    criterion.Name,
                    variableIdentifier,
                    CriterionTypeManager.GetCriterionTypeName(criterion.Type)));
            }

            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine(NamesAndFormats.Constraints);
            foreach (Constraint constraint in model.FunctionalConstraints.Values)
            {
                string variableIdentifier = string.IsNullOrEmpty(constraint.VariableIdentifier)
                    ? string.Empty
                    : string.Format(NamesAndFormats.VariableIdentifierFormat, constraint.VariableIdentifier);
                outputFileWriter.WriteLine(string.Format(
                    NamesAndFormats.ConstraintFormat,
                    constraint.Name,
                    variableIdentifier,
                    RelationManager.GetRelationName(constraint.ConstraintRelation),
                    constraint.Value.ToStringInvariant(SettingsManager.Instance.DoubleStringFormat)));
            }
        }

        /// <summary>
        /// Writes list of experiments sorted according to the selected optimization method
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="result"><see cref="OptimizationMethodResult"/> or derived class instance describing optimization result</param>
        /// <param name="outputFileWriter"><see cref="StreamWriter"/> to be used for the output</param>
        private void WriteOptimizationResult(Model model, OptimizationMethodResult result, StreamWriter outputFileWriter)
        {
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine();
            outputFileWriter.WriteLine(NamesAndFormats.Results);
            outputFileWriter.WriteLine();
            foreach (TId experimentId in result.SortedPoints)
            {
                Experiment experiment = model.Experiments[experimentId];
                if (experiment.IsActive)
                {
                    outputFileWriter.Write(string.Format(NamesAndFormats.ExperimentNumberFormat, experiment.Number));
                    foreach (Parameter parameter in model.Parameters.Values)
                    {
                        outputFileWriter.Write(string.Format(
                            NamesAndFormats.ValueFormat,
                            parameter.Name,
                            experiment.ParameterValues[parameter.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat)));
                    }

                    foreach (Criterion criterion in model.Criteria.Values)
                    {
                        outputFileWriter.Write(string.Format(
                            NamesAndFormats.ValueFormat,
                            criterion.Name,
                            experiment.CriterionValues[criterion.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat)));
                    }

                    foreach (Constraint constraint in model.FunctionalConstraints.Values)
                    {
                        outputFileWriter.Write(string.Format(
                            NamesAndFormats.ValueFormat,
                            constraint.Name,
                            experiment.ConstraintValues[constraint.Id].ToStringInvariant(SettingsManager.Instance.DoubleStringFormat)));
                    }

                    outputFileWriter.WriteLine();
                }
            }
        }
    }
}