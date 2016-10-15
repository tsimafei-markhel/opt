using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using opt.DataModel;
using opt.Extensions;

namespace opt.Text
{
    /// <summary>
    /// Model-to-Text provider (for Dummy mode)
    /// </summary>
    public static class TextModelProvider
    {
        /// <summary>
        /// Writes <see cref="Model"/> partially to text files - only general information about model and
        /// parameter values are written
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be written</param>
        /// <param name="providerSettings"><see cref="TextModelProviderSettings"/> with necessary export information</param>
        public static void WriteModel(Model model, TextModelProviderSettings providerSettings)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (providerSettings == null)
            {
                throw new ArgumentNullException("providerSettings");
            }

            WriteModelInformation(model, providerSettings.InformationFilePath);
            WriteModelParameters(model, providerSettings.ParametersFilePath);
        }

        /// <summary>
        /// Writes general <see cref="Model"/> information: number of parameters, criteria and functional constraints
        /// and also number of experiments to text file
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be written</param>
        /// <param name="informationFilePath">Full path to the file to be written</param>
        private static void WriteModelInformation(Model model, string informationFilePath)
        {
            if (string.IsNullOrEmpty(informationFilePath))
            {
                throw new ArgumentNullException("informationFilePath");
            }

            using (FileStream informationFileStream = File.Open(informationFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter informationFileWriter = new StreamWriter(informationFileStream, Encoding.UTF8))
            {
                informationFileWriter.WriteLine(model.Parameters.Count.ToString());
                informationFileWriter.WriteLine(model.Criteria.Count.ToString());
                informationFileWriter.WriteLine(model.FunctionalConstraints.Count.ToString());
                informationFileWriter.WriteLine(model.Experiments.Count.ToString());

                informationFileWriter.Flush();
            }
        }

        /// <summary>
        /// Writes parameter values for all experiments to the text file
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to take data from</param>
        /// <param name="parametersFilePath">Full path to the file to be written</param>
        private static void WriteModelParameters(Model model, string parametersFilePath)
        {
            if (string.IsNullOrEmpty(parametersFilePath))
            {
                throw new ArgumentNullException("parametersFilePath");
            }

            using (FileStream parametersFileStream = File.Open(parametersFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter parametersFileWriter = new StreamWriter(parametersFileStream, Encoding.UTF8))
            {
                foreach (Experiment experiment in model.Experiments.Values)
                {
                    foreach (Parameter parameter in model.Parameters.Values)
                    {
                        parametersFileWriter.WriteLine(experiment.ParameterValues[parameter.Id].ToStringInvariant());
                    }
                }

                parametersFileWriter.Flush();
            }
        }

        /// <summary>
        /// Reads calculation results (values of criteria and functional constraints) from text file to the <paramref name="targetModel"/>
        /// </summary>
        /// <param name="targetModel"><see cref="Model"/> instance to read values to</param>
        /// <param name="providerSettings"><see cref="TextModelProviderSettings"/> with full path to the file to be read</param>
        public static void ReadResultToModel(Model targetModel, TextModelProviderSettings providerSettings)
        {
            if (targetModel == null)
            {
                throw new ArgumentNullException("targetModel");
            }

            if (providerSettings == null)
            {
                throw new ArgumentNullException("providerSettings");
            }

            using (FileStream resultFileStream = File.Open(providerSettings.ResultFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
            using (StreamReader resultFileReader = new StreamReader(resultFileStream, Encoding.UTF8))
            {
                foreach (Experiment experiment in targetModel.Experiments.Values)
                {
                    ReadValues<Criterion>(targetModel.Criteria.Values, experiment.CriterionValues, resultFileReader);
                    ReadValues<Constraint>(targetModel.FunctionalConstraints.Values, experiment.ConstraintValues, resultFileReader);
                }
            }
        }

        /// <summary>
        /// Reads <see cref="Double"/> values of entities represented by <typeparamref name="T"/> from <paramref name="streamReader"/>
        /// to the <paramref name="valuesCollection"/>
        /// </summary>
        /// <typeparam name="T">Type of the entity which value should be read</typeparam>
        /// <param name="entitiesCollection">Collection of entities to read values of</param>
        /// <param name="valuesCollection">A collection to read values to</param>
        /// <param name="streamReader"><see cref="StreamReader"/> instance used to read values</param>
        private static void ReadValues<T>(IEnumerable<T> entitiesCollection, IDictionary<TId, double> valuesCollection, StreamReader streamReader) where T : ModelEntity
        {
            if (entitiesCollection == null)
            {
                throw new ArgumentNullException("entitiesCollection");
            }

            if (valuesCollection == null)
            {
                throw new ArgumentNullException("valuesCollection");
            }

            if (streamReader == null)
            {
                throw new ArgumentNullException("streamReader");
            }

            foreach (T entity in entitiesCollection)
            {
                string valueString = streamReader.ReadLine();
                if (string.IsNullOrEmpty(valueString))
                {
                    throw new InvalidOperationException("Cannot read Double value from file stream");
                }

                double value = ConvertExtensions.ToDoubleInvariant(valueString);
                if (valuesCollection.ContainsKey(entity.Id))
                {
                    valuesCollection[entity.Id] = value;
                }
                else
                {
                    valuesCollection.Add(entity.Id, value);
                }
            }
        }
    }
}