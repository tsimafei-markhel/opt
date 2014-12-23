using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using opt.DataModel;

namespace opt.UI.Exporters
{
    /// <summary>
    /// Provides basic functionality on exporting <see cref="Model"/> to MS Excel 2007+ (xlsx) format
    /// </summary>
    public sealed class ExcelExporter : IDataExporter
    {
        /// <summary>
        /// <see cref="ExcelExporterSettings"/> to be used during export
        /// </summary>
        private ExcelExporterSettings settings;

        /// <summary>
        /// Regular expression to match Results sheets (to get next free number)
        /// For example, "Results 1" to get free results sheet number 2 etc.
        /// </summary>
        private readonly Regex resultsSheetNameExpression = new Regex(SheetNames.Results + @"\s(?<" + Names.RegexNumberGroup + @">\d+)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        /// <summary>
        /// Foreground color for the experiments that do not match functional constraints
        /// </summary>
        private readonly Color inactiveExperimentTextColor = Color.DimGray;

        /// <summary>
        /// Helper class, contains different sheet names used during export
        /// </summary>
        private static class SheetNames
        {
            public const string Experiments = "Experiments";
            public const string ParetoFront = "Pareto Front";
            public const string Results = "Results";
            public const string ValidExperiments = "Valid Experiments";
        }

        /// <summary>
        /// Helper class, contains various string constants used during export
        /// </summary>
        private static class Names
        {
            public const string RegexNumberGroup = "Number";
            public const string PointNumberColumn = "#";
        }

        /// <summary>
        /// Helper class, contains row/column numbers and indices used during export
        /// </summary>
        private static class Indices
        {
            public static int HeaderRowIndex { get; private set; }
            public static int DataRowOffset { get; private set; }
            public static int PointNumberColumnIndex { get; private set; }
            public static int ParametersColumnOffset { get; private set; }
            public static int CriteriaColumnOffset { get; private set; }
            public static int ConstraintsColumnOffset { get; private set; }

            /// <summary>
            /// Initializes static members of <see cref="ExcelExporter.Indices"/> class
            /// </summary>
            static Indices()
            {
                HeaderRowIndex = 1;
                DataRowOffset = HeaderRowIndex + 1;
                PointNumberColumnIndex = 1;
                ParametersColumnOffset = -1;
                CriteriaColumnOffset = -1;
                ConstraintsColumnOffset = -1;
            }

            /// <summary>
            /// Re-calculates some indices according to the contents of <paramref name="model"/>
            /// </summary>
            /// <param name="model"><see cref="Model"/> instance to be used for indices re-calculation</param>
            public static void UpdateColumnOffsets (Model model)
            {
                ParametersColumnOffset = PointNumberColumnIndex + 1;
                CriteriaColumnOffset = ParametersColumnOffset + model.Parameters.Count;
                ConstraintsColumnOffset = CriteriaColumnOffset + model.Criteria.Count;
            }
        }

        /// <summary>
        /// Helper class, contains various cell formats
        /// </summary>
        private static class CellFormats
        {
            public const string Integer = "#";
            public static string Double { get; private set; }

            /// <summary>
            /// Initializes static members of <see cref="CellFormats"/> class
            /// </summary>
            /// <remarks>Double format will contain as much decimal places as there is in application settings</remarks>
            static CellFormats()
            {
                Double = "#0.";
                for (int decimalPlace = 1; decimalPlace < Program.ApplicationSettings.ValuesDecimalPlaces; decimalPlace++)
                {
                    Double += "#";
                }

                Double += "0";
            }
        }

        /// <summary>
        /// Target file extension, can be used for various checks
        /// </summary>
        public const string ExcelFileExtension = "xlsx";

        /// <summary>
        /// Gets <see cref="ExportableData"/> flags showing what parts of <see cref="Model"/> <see cref="ExcelExporter"/> can export
        /// </summary>
        public static ExportableData SupportedExportableData
        {
            get
            {
                return ExportableData.None | ExportableData.Experiments | ExportableData.ValidExperiments | ExportableData.ParetoFront | ExportableData.Results;
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="ExcelExporter"/> with proper <see cref="ExcelExporterSettings"/> settings
        /// </summary>
        /// <param name="exportSettings"><see cref="ExcelExporterSettings"/> instance with export settings</param>
        public ExcelExporter(ExcelExporterSettings exportSettings)
        {
            if (exportSettings == null)
            {
                throw new ArgumentNullException("exportSettings");
            }

            settings = exportSettings;
        }

        /// <summary>
        /// Exports <paramref name="model"/> to MS Excel 2007+ (xlsx) format
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        public void Export(Model model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            FileInfo targetFileInfo = new FileInfo(settings.FilePath);
            using (ExcelPackage targetPackage = new ExcelPackage(targetFileInfo))
            {
                TryWriteSheet(ExportableData.Experiments, WriteExperiments, model, targetPackage);
                TryWriteSheet(ExportableData.ValidExperiments, WriteValidExperiments, model, targetPackage);
                TryWriteSheet(ExportableData.ParetoFront, WriteParetoFront, model, targetPackage);
                TryWriteSheet(ExportableData.Results, WriteResults, model, targetPackage);

                targetPackage.Save();
            }
        }

        /// <summary>
        /// Calls <paramref name="WriteSheetMethod"/> if current exporter settings have <paramref name="sheetFlag"/> flag
        /// </summary>
        /// <param name="sheetFlag"><see cref="ExportableData"/> flag specifying what exactly should be exported</param>
        /// <param name="WriteSheetMethod">Method to be called to write sheet</param>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance to write exported data to</param>
        private void TryWriteSheet(ExportableData sheetFlag, Action<Model, ExcelPackage> WriteSheetMethod, Model model, ExcelPackage targetPackage)
        {
            if (settings.ExportWhat.HasFlag(sheetFlag))
            {
                WriteSheetMethod(model, targetPackage);
            }
        }

        /// <summary>
        /// Exports experiments
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance to write exported data to</param>
        private void WriteExperiments(Model model, ExcelPackage targetPackage)
        {
            if (targetPackage == null)
            {
                throw new ArgumentNullException("targetPackage");
            }

            if (targetPackage.Workbook.Worksheets[SheetNames.Experiments] != null)
            {
                targetPackage.Workbook.Worksheets.Delete(SheetNames.Experiments);
            }

            ExcelWorksheet experimentsSheet = targetPackage.Workbook.Worksheets.Add(SheetNames.Experiments);
            WriteExperimentColumnHeaders(model, experimentsSheet);
            WriteExperimentRows(model, experimentsSheet, false);
        }

        /// <summary>
        /// Exports only valid experiments (those fitting functional constraints)
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance to write exported data to</param>
        private void WriteValidExperiments(Model model, ExcelPackage targetPackage)
        {
            if (targetPackage == null)
            {
                throw new ArgumentNullException("targetPackage");
            }

            if (targetPackage.Workbook.Worksheets[SheetNames.Experiments] != null)
            {
                targetPackage.Workbook.Worksheets.Delete(SheetNames.Experiments);
            }

            ExcelWorksheet experimentsSheet = targetPackage.Workbook.Worksheets.Add(SheetNames.Experiments);
            WriteExperimentColumnHeaders(model, experimentsSheet);
            WriteExperimentRows(model, experimentsSheet, true);
        }

        /// <summary>
        /// Exports only experiments that belong to Pareto front
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance to write exported data to</param>
        private void WriteParetoFront(Model model, ExcelPackage targetPackage)
        {
            if (targetPackage == null)
            {
                throw new ArgumentNullException("targetPackage");
            }

            if (targetPackage.Workbook.Worksheets[SheetNames.ParetoFront] != null)
            {
                targetPackage.Workbook.Worksheets.Delete(SheetNames.ParetoFront);
            }

            ExcelWorksheet paretoFrontSheet = targetPackage.Workbook.Worksheets.Add(SheetNames.ParetoFront);
            WriteExperimentColumnHeaders(model, paretoFrontSheet);
            WriteParetoFrontRows(model, paretoFrontSheet);
        }

        /// <summary>
        /// Exports optimization results (experiments in the order suggested by some solver)
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance to write exported data to</param>
        private void WriteResults(Model model, ExcelPackage targetPackage)
        {
            if (targetPackage == null)
            {
                throw new ArgumentNullException("targetPackage");
            }

            int freeResultsSheetNumber = GetFreeResultsSheetNumber(targetPackage);
            ExcelWorksheet resultsSheet = targetPackage.Workbook.Worksheets.Add(SheetNames.Results + freeResultsSheetNumber);
            WriteExperimentColumnHeaders(model, resultsSheet);
            WriteResultRows(model, resultsSheet);
        }

        /// <summary>
        /// Fills in header row
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="sheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        private void WriteExperimentColumnHeaders(Model model, ExcelWorksheet sheet)
        {
            if (sheet == null)
            {
                throw new ArgumentNullException("sheet");
            }

            int columnOffset = Indices.PointNumberColumnIndex;

            WriteColumnHeaderCell(sheet, columnOffset, Names.PointNumberColumn);
            columnOffset++;

            foreach(Parameter parameter in model.Parameters.Values)
            {
                WriteColumnHeaderCell(sheet, columnOffset, parameter.Name);
                columnOffset++;
            }

            foreach (Criterion criterion in model.Criteria.Values)
            {
                WriteColumnHeaderCell(sheet, columnOffset, criterion.Name);
                columnOffset++;
            }

            foreach (Constraint constraint in model.FunctionalConstraints.Values)
            {
                WriteColumnHeaderCell(sheet, columnOffset, constraint.Name);
                columnOffset++;
            }
        }

        /// <summary>
        /// Writes data rows (all or only valid experiments) to the <paramref name="experimentsSheet"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="experimentsSheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        /// <param name="activeOnly">Flag specifying whether to export only valid experiments or all experiments</param>
        private void WriteExperimentRows(Model model, ExcelWorksheet experimentsSheet, bool activeOnly)
        {
            if (experimentsSheet == null)
            {
                throw new ArgumentNullException("experimentsSheet");
            }

            Indices.UpdateColumnOffsets(model);
            int rowOffset = Indices.DataRowOffset;

            IEnumerable<Experiment> experimentsCollection = model.Experiments.Values;
            if (activeOnly)
            {
                experimentsCollection = model.Experiments.Values.Where(e => e.IsActive);
            }

            foreach (Experiment experiment in experimentsCollection)
            {
                WriteExperiment(experiment, rowOffset, experimentsSheet, model);
                if (!experiment.IsActive)
                {
                    experimentsSheet.Row(rowOffset).Style.Font.Color.SetColor(inactiveExperimentTextColor);
                }

                rowOffset++;
            }
        }

        /// <summary>
        /// Writes data rows (Pareto front experiments) to the <paramref name="paretoFrontSheet"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="paretoFrontSheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        private void WriteParetoFrontRows(Model model, ExcelWorksheet paretoFrontSheet)
        {
            if (paretoFrontSheet == null)
            {
                throw new ArgumentNullException("paretoFrontSheet");
            }

            Indices.UpdateColumnOffsets(model);
            int rowOffset = Indices.DataRowOffset;

            IEnumerable<Experiment> paretoFront = model.Experiments.Values.Where(e => e.IsActive && e.IsParetoOptimal);
            foreach (Experiment experiment in paretoFront)
            {
                WriteExperiment(experiment, rowOffset, paretoFrontSheet, model);
                rowOffset++;
            }
        }

        /// <summary>
        /// Writes data rows (result experiments) to the <paramref name="resultSheet"/>
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        /// <param name="resultSheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        private void WriteResultRows(Model model, ExcelWorksheet resultSheet)
        {
            if (resultSheet == null)
            {
                throw new ArgumentNullException("resultSheet");
            }

            Indices.UpdateColumnOffsets(model);
            int rowOffset = Indices.DataRowOffset;

            OptimizationMethodResult result = model.Properties.GetProperty<OptimizationMethodResult>(OptimizationMethodResult.PropertyName);
            if (result == null)
            {
                throw new InvalidOperationException("Optimization result was not found in model properties");
            }

            foreach (TId experimentId in result.SortedPoints)
            {
                Experiment experiment = model.Experiments[experimentId];
                if (experiment.IsActive)
                {
                    WriteExperiment(experiment, rowOffset, resultSheet, model);
                    rowOffset++;
                }
            }
        }

        /// <summary>
        /// Writes single experiment row
        /// </summary>
        /// <param name="experiment"><see cref="Experiment"/> instance to be exported</param>
        /// <param name="rowIndex">Target row index on <paramref name="targetSheet"/> worksheet</param>
        /// <param name="targetSheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        /// <param name="model"><see cref="Model"/> instance to be exported</param>
        private void WriteExperiment(Experiment experiment, int rowIndex, ExcelWorksheet targetSheet, Model model)
        {
            targetSheet.Cells[rowIndex, Indices.PointNumberColumnIndex].Style.Numberformat.Format = CellFormats.Integer;
            targetSheet.Cells[rowIndex, Indices.PointNumberColumnIndex].Value = experiment.Number;

            WriteEntityCollectionValuesRow(targetSheet, rowIndex, Indices.ParametersColumnOffset, experiment.ParameterValues, model.Parameters.Keys);
            WriteEntityCollectionValuesRow(targetSheet, rowIndex, Indices.CriteriaColumnOffset, experiment.CriterionValues, model.Criteria.Keys);
            WriteEntityCollectionValuesRow(targetSheet, rowIndex, Indices.ConstraintsColumnOffset, experiment.ConstraintValues, model.FunctionalConstraints.Keys);
        }

        /// <summary>
        /// Writes values <paramref name="collection"/> to the specified row on the <paramref name="sheet"/>
        /// </summary>
        /// <param name="sheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        /// <param name="rowIndex">Target row index on <paramref name="sheet"/> worksheet</param>
        /// <param name="columnOffset">Target column offset on <paramref name="sheet"/> worksheet</param>
        /// <param name="collection">Values collection to be written</param>
        /// <param name="entityIds">A collection of IDs specifying what exactly should be taken from <paramref name="collection"/></param>
        private void WriteEntityCollectionValuesRow(ExcelWorksheet sheet, int rowIndex, int columnOffset, IDictionary<TId, double> collection, IEnumerable<TId> entityIds)
        {
            int i = 0;
            foreach (TId entityId in entityIds)
            {
                int columnIndex = columnOffset + i;
                if (!double.IsNaN(collection[entityId]) && !double.IsInfinity(collection[entityId]))
                {
                    sheet.Cells[rowIndex, columnIndex].Style.Numberformat.Format = CellFormats.Double;
                    sheet.Cells[rowIndex, columnIndex].Value = collection[entityId];
                }
                else
                {
                    sheet.Cells[rowIndex, columnIndex].Value = collection[entityId].ToString();
                }

                i++;
            }
        }

        /// <summary>
        /// Writes header cell
        /// </summary>
        /// <param name="sheet"><see cref="ExcelWorksheet"/> instance to write exported data to</param>
        /// <param name="columnIndex">Index of a column to write header cell for</param>
        /// <param name="cellText">Text of a header cell</param>
        private void WriteColumnHeaderCell(ExcelWorksheet sheet, int columnIndex, string cellText)
        {
            sheet.Column(columnIndex).BestFit = true;
            sheet.Cells[Indices.HeaderRowIndex, columnIndex].Value = cellText;
            sheet.Cells[Indices.HeaderRowIndex, columnIndex].Style.Font.Bold = true;
            sheet.Cells[Indices.HeaderRowIndex, columnIndex].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        }

        /// <summary>
        /// Gets free number for results worksheet
        /// </summary>
        /// <param name="targetPackage"><see cref="ExcelPackage"/> instance where exported data will be written</param>
        /// <returns>Free number for results worksheet</returns>
        /// <example>If there are "Results 1" and "Results 2" worksheets in <paramref name="targetPackage"/>, 3 will be returned</example>
        private int GetFreeResultsSheetNumber(ExcelPackage targetPackage)
        {
            int freeSheetNumber = 1;
            foreach(ExcelWorksheet sheet in targetPackage.Workbook.Worksheets)
            {
                Match resultsSheetNameExpressionMatch = resultsSheetNameExpression.Match(sheet.Name);
                if (resultsSheetNameExpressionMatch != null && resultsSheetNameExpressionMatch.Success)
                {
                    int resultsSheetNumber = Convert.ToInt32(resultsSheetNameExpressionMatch.Groups[Names.RegexNumberGroup].Value);
                    if (resultsSheetNumber >= freeSheetNumber)
                    {
                        freeSheetNumber = resultsSheetNumber + 1;
                    }
                }
            }

            return freeSheetNumber;
        }
    }
}