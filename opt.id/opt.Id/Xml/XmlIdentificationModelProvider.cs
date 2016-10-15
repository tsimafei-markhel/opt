using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using opt.DataModel;
using opt.Extensions;

// TODO: Come up with XSD schema for this
// TODO: Add schema validation to Open()

namespace opt.Xml
{
    /// <summary>
    /// XML provider (writes <see cref="IdentificationModel"/> to XML and reads it from XML)
    /// </summary>
    public static class XmlIdentificationModelProvider
    {
        /// <summary>
        /// Namespace to be used in XML model files
        /// </summary>
        public const string Namespace = "http://www.opt.com/identification.model";

        /// <summary>
        /// <see cref="XmlWriterSettings"/> instance to use when writing XML
        /// </summary>
        private static readonly XmlWriterSettings modelFileWriterSettings = new XmlWriterSettings()
        {
            CloseOutput = true,
            Indent = true,
            IndentChars = "    ",
            NamespaceHandling = NamespaceHandling.OmitDuplicates
        };

        /// <summary>
        /// <see cref="XmlReaderSettings"/> instance to use when reading XML
        /// </summary>
        private static readonly XmlReaderSettings modelFileReaderSettings = new XmlReaderSettings()
        {
            CloseInput = true,
            IgnoreWhitespace = true
        };

        /// <summary>
        /// Helper class, stores <see cref="XName"/> of different XML elements used in model XML
        /// </summary>
        private static class Elements
        {
            public static readonly XName AdequacyCriterionValue = XName.Get("adequacyCriterionValue", Namespace);
            public static readonly XName AdequacyCriterionValues = XName.Get("adequacyCriterionValues", Namespace);
            public static readonly XName Criteria = XName.Get("criteria", Namespace);
            public static readonly XName Criterion = XName.Get("criterion", Namespace);
            public static readonly XName FunctionalConstraint = XName.Get("functionalConstraint", Namespace);
            public static readonly XName FunctionalConstraints = XName.Get("functionalConstraints", Namespace);
            public static readonly XName FunctionalConstraintValue = XName.Get("functionalConstraintValue", Namespace);
            public static readonly XName FunctionalConstraintValues = XName.Get("functionalConstraintValues", Namespace);
            public static readonly XName IdentificationExperiment = XName.Get("identificationExperiment", Namespace);
            public static readonly XName IdentificationExperiments = XName.Get("identificationExperiments", Namespace);
            public static readonly XName IdentificationModel = XName.Get("identificationModel", Namespace);
            public static readonly XName IdentificationParameter = XName.Get("identificationParameter", Namespace);
            public static readonly XName IdentificationParameters = XName.Get("identificationParameters", Namespace);
            public static readonly XName IdentificationParameterValue = XName.Get("identificationParameterValue", Namespace);
            public static readonly XName IdentificationParameterValues = XName.Get("identificationParameterValues", Namespace);
            public static readonly XName MathematicalCriterionValue = XName.Get("mathematicalCriterionValue", Namespace);
            public static readonly XName MathematicalCriterionValues = XName.Get("mathematicalCriterionValues", Namespace);
            public static readonly XName OptimizationParameter = XName.Get("optimizationParameter", Namespace);
            public static readonly XName OptimizationParameters = XName.Get("optimizationParameters", Namespace);
            public static readonly XName OptimizationParameterValue = XName.Get("optimizationParameterValue", Namespace);
            public static readonly XName OptimizationParameterValues = XName.Get("optimizationParameterValues", Namespace);
            public static readonly XName Property = XName.Get("property", Namespace);
            public static readonly XName Properties = XName.Get("properties", Namespace);
            public static readonly XName RealCriterionValue = XName.Get("realCriterionValue", Namespace);
            public static readonly XName RealCriterionValues = XName.Get("realCriterionValues", Namespace);
            public static readonly XName RealExperiment = XName.Get("realExperiment", Namespace);
            public static readonly XName RealExperiments = XName.Get("realExperiments", Namespace);
        }

        /// <summary>
        /// Helper class, stores <see cref="XName"/> of different attributes used in model XML
        /// </summary>
        private static class Attributes
        {
            public static readonly XName Expression = XName.Get("expression");
            public static readonly XName Id = XName.Get("id");
            public static readonly XName Key = XName.Get("key");
            public static readonly XName MaxValue = XName.Get("maxValue");
            public static readonly XName MinValue = XName.Get("minValue");
            public static readonly XName Name = XName.Get("name");
            public static readonly XName Number = XName.Get("number");
            public static readonly XName RealExperimentId = XName.Get("realExperimentId");
            public static readonly XName Relation = XName.Get("relation");
            public static readonly XName Type = XName.Get("type");
            public static readonly XName Value = XName.Get("value");
            public static readonly XName VariableIdentifier = XName.Get("variableIdentifier");
            public static readonly XName Weight = XName.Get("weight");
        }

        #region Export

        /// <summary>
        /// Writes <paramref name="model"/> to XML file
        /// </summary>
        /// <param name="model"><see cref="IdentificationModel"/> instance to be written to XML</param>
        /// <param name="filePath">Full path to target XML file</param>
        public static void Save(IdentificationModel model, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            XDocument modelDocument = GetXDocument(model);
            FileInfo modelFileInfo = new FileInfo(filePath);
            using (FileStream modelFileStream = modelFileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            using (XmlWriter modelFileWriter = XmlWriter.Create(modelFileStream, modelFileWriterSettings))
            {
                modelDocument.Save(modelFileWriter);
            }
        }

        /// <summary>
        /// Creates <see cref="XDocument"/> with <paramref name="model"/> contents
        /// </summary>
        /// <param name="model"><see cref="IdentificationModel"/> instance to be written to XML</param>
        /// <returns><see cref="XDocument"/> with <paramref name="model"/> contents</returns>
        private static XDocument GetXDocument(IdentificationModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            XDocument modelDocument = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            WriteModelElement(modelDocument);
            WriteParameters(model.OptimizationParameters, modelDocument.Root, Elements.OptimizationParameters, Elements.OptimizationParameter);
            WriteParameters(model.IdentificationParameters, modelDocument.Root, Elements.IdentificationParameters, Elements.IdentificationParameter);
            WriteCriteria(model.Criteria, modelDocument.Root);
            WriteFunctionalConstraints(model.FunctionalConstraints, modelDocument.Root);
            WriteRealExperiments(model.RealExperiments, modelDocument.Root);
            WriteIdentificationExperiments(model.IdentificationExperiments, modelDocument.Root);
            WritePropertyCollection(model.Properties, modelDocument.Root);

            return modelDocument;
        }

        /// <summary>
        /// Writes root element to the <paramref name="modelDocument"/>
        /// </summary>
        /// <param name="modelDocument"><see cref="XDocument"/> instance with <see cref="IdentificationModel"/> contents</param>
        private static void WriteModelElement(XDocument modelDocument)
        {
            modelDocument.Add(new XElement(Elements.IdentificationModel));
        }

        /// <summary>
        /// Writes a collection of <see cref="Parameter"/> to XML
        /// </summary>
        /// <param name="parameterCollection">A collection to be written to XML</param>
        /// <param name="modelDocumentRoot"><see cref="XElement"/> instance that represents root of model XML document</param>
        /// <param name="collectionName">Name of the parameter collection</param>
        /// <param name="elementName">Name of the parameter element</param>
        private static void WriteParameters(NamedModelEntityCollection<Parameter> parameterCollection, XElement modelDocumentRoot, XName collectionName, XName elementName)
        {
            XElement parametersCollectionElement = new XElement(collectionName);
            foreach (Parameter parameter in parameterCollection.Values)
            {
                XElement parameterElement = new XElement(elementName,
                    new XAttribute(Attributes.Id, parameter.Id.ToString()),
                    new XAttribute(Attributes.Name, parameter.Name),
                    new XAttribute(Attributes.VariableIdentifier, parameter.VariableIdentifier),
                    new XAttribute(Attributes.MinValue, parameter.MinValue.ToStringInvariant()),
                    new XAttribute(Attributes.MaxValue, parameter.MaxValue.ToStringInvariant())
                );

                WritePropertyCollection(parameter.Properties, parameterElement);

                parametersCollectionElement.Add(parameterElement);
            }

            modelDocumentRoot.Add(parametersCollectionElement);
        }

        /// <summary>
        /// Writes a collection of <see cref="AdequacyCriterion"/> to XML
        /// </summary>
        /// <param name="criterionCollection">A collection to be written to XML</param>
        /// <param name="modelDocumentRoot"><see cref="XElement"/> instance that represents root of model XML document</param>
        private static void WriteCriteria(NamedModelEntityCollection<AdequacyCriterion> criterionCollection, XElement modelDocumentRoot)
        {
            XElement criteriaCollectionElement = new XElement(Elements.Criteria);
            foreach (AdequacyCriterion criterion in criterionCollection.Values)
            {
                XElement criterionElement = new XElement(Elements.Criterion,
                    new XAttribute(Attributes.Id, criterion.Id.ToString()),
                    new XAttribute(Attributes.Name, criterion.Name),
                    new XAttribute(Attributes.VariableIdentifier, criterion.VariableIdentifier),
                    new XAttribute(Attributes.Type, criterion.AdequacyType.ToString())
                );

                WritePropertyCollection(criterion.Properties, criterionElement);

                criteriaCollectionElement.Add(criterionElement);
            }

            modelDocumentRoot.Add(criteriaCollectionElement);
        }

        /// <summary>
        /// Writes a collection of <see cref="Constraint"/> to XML
        /// </summary>
        /// <param name="constraintCollection">A collection to be written to XML</param>
        /// <param name="modelDocumentRoot"><see cref="XElement"/> instance that represents root of model XML document</param>
        private static void WriteFunctionalConstraints(NamedModelEntityCollection<Constraint> constraintCollection, XElement modelDocumentRoot)
        {
            XElement constraintsCollectionElement = new XElement(Elements.FunctionalConstraints);
            foreach (Constraint constraint in constraintCollection.Values)
            {
                XElement constraintElement = new XElement(Elements.FunctionalConstraint,
                    new XAttribute(Attributes.Id, constraint.Id.ToString()),
                    new XAttribute(Attributes.Name, constraint.Name),
                    new XAttribute(Attributes.VariableIdentifier, constraint.VariableIdentifier),
                    new XAttribute(Attributes.Relation, constraint.ConstraintRelation.ToString()),
                    new XAttribute(Attributes.Value, constraint.Value.ToStringInvariant()),
                    new XAttribute(Attributes.Expression, constraint.Expression)
                );

                WritePropertyCollection(constraint.Properties, constraintElement);

                constraintsCollectionElement.Add(constraintElement);
            }

            modelDocumentRoot.Add(constraintsCollectionElement);
        }

        /// <summary>
        /// Writes a collection of <see cref="Experiment"/> to XML
        /// </summary>
        /// <param name="experimentCollection">A collection to be written to XML</param>
        /// <param name="modelDocumentRoot"><see cref="XElement"/> instance that represents root of model XML document</param>
        private static void WriteRealExperiments(ExperimentCollection experimentCollection, XElement modelDocumentRoot)
        {
            XElement experimentsCollectionElement = new XElement(Elements.RealExperiments);
            foreach (Experiment experiment in experimentCollection.Values)
            {
                XElement experimentElement = new XElement(Elements.RealExperiment,
                    new XAttribute(Attributes.Id, experiment.Id.ToString()),
                    new XAttribute(Attributes.Number, experiment.Number.ToString())
                );

                XElement parameterValuesCollectionElement =
                    WriteValueCollection(experiment.ParameterValues, Elements.OptimizationParameterValues, Elements.OptimizationParameterValue);
                experimentElement.Add(parameterValuesCollectionElement);

                XElement criterionValuesCollectionElement =
                    WriteValueCollection(experiment.CriterionValues, Elements.RealCriterionValues, Elements.RealCriterionValue);
                experimentElement.Add(criterionValuesCollectionElement);

                XElement constraintValuesCollectionElement =
                    WriteValueCollection(experiment.ConstraintValues, Elements.FunctionalConstraintValues, Elements.FunctionalConstraintValue);
                experimentElement.Add(constraintValuesCollectionElement);

                WritePropertyCollection(experiment.Properties, experimentElement);

                experimentsCollectionElement.Add(experimentElement);
            }

            modelDocumentRoot.Add(experimentsCollectionElement);
        }

        /// <summary>
        /// Writes a collection of <see cref="IdentificationExperiment"/> to XML
        /// </summary>
        /// <param name="experimentCollection">A collection to be written to XML</param>
        /// <param name="modelDocumentRoot"><see cref="XElement"/> instance that represents root of model XML document</param>
        private static void WriteIdentificationExperiments(IdentificationExperimentCollection experimentCollection, XElement modelDocumentRoot)
        {
            XElement experimentsCollectionElement = new XElement(Elements.IdentificationExperiments);
            foreach (IdentificationExperiment experiment in experimentCollection.Values)
            {
                XElement experimentElement = new XElement(Elements.IdentificationExperiment,
                    new XAttribute(Attributes.Id, experiment.Id.ToString()),
                    new XAttribute(Attributes.Number, experiment.Number.ToString()),
                    new XAttribute(Attributes.RealExperimentId, experiment.RealExperimentId.ToString())
                );

                XElement parameterValuesCollectionElement =
                    WriteValueCollection(experiment.IdentificationParameterValues, Elements.IdentificationParameterValues, Elements.IdentificationParameterValue);
                experimentElement.Add(parameterValuesCollectionElement);

                XElement realCriterionValuesCollectionElement =
                    WriteValueCollection(experiment.MathematicalCriterionValues, Elements.MathematicalCriterionValues, Elements.MathematicalCriterionValue);
                experimentElement.Add(realCriterionValuesCollectionElement);

                XElement adequacyCriterionValuesCollectionElement =
                    WriteValueCollection(experiment.AdequacyCriterionValues, Elements.AdequacyCriterionValues, Elements.AdequacyCriterionValue);
                experimentElement.Add(adequacyCriterionValuesCollectionElement);

                XElement constraintValuesCollectionElement =
                    WriteValueCollection(experiment.ConstraintValues, Elements.FunctionalConstraintValues, Elements.FunctionalConstraintValue);
                experimentElement.Add(constraintValuesCollectionElement);

                WritePropertyCollection(experiment.Properties, experimentElement);

                experimentsCollectionElement.Add(experimentElement);
            }

            modelDocumentRoot.Add(experimentsCollectionElement);
        }

        /// <summary>
        /// Writes a collection of <see cref="Double"/> values to XML
        /// </summary>
        /// <param name="collection">Collection to be written to XML</param>
        /// <param name="collectionElementName"><see cref="XName"/> of the collection XML element</param>
        /// <param name="valueElementName"><see cref="XName"/> of the item XML element</param>
        /// <returns><see cref="XElement"/> instance that represents the collection, with corresponding items added to it as children</returns>
        private static XElement WriteValueCollection(IDictionary<TId, double> collection, XName collectionElementName, XName valueElementName)
        {
            XElement valueCollectionElement = new XElement(collectionElementName);
            foreach (TId valueId in collection.Keys)
            {
                XElement valueElement = new XElement(valueElementName,
                    new XAttribute(Attributes.Id, valueId.ToString()),
                    new XAttribute(Attributes.Value, collection[valueId].ToStringInvariant())
                );

                valueCollectionElement.Add(valueElement);
            }

            return valueCollectionElement;
        }

        /// <summary>
        /// Writes <paramref name="properties"/> to XML. Does nothing if <paramref name="properties"/> collection is empty
        /// </summary>
        /// <param name="properties"><see cref="PropertyCollection"/> instance with custom properties</param>
        /// <param name="parentElement"><see cref="XElement"/> instance to write custom properties collection to (as a child element)</param>
        private static void WritePropertyCollection(PropertyCollection properties, XElement parentElement)
        {
            if (properties.Count == 0)
            {
                return;
            }

            XElement propertiesCollectionElement = new XElement(Elements.Properties);
            foreach (KeyValuePair<string, CustomProperty> property in properties)
            {
                IExportable exportableProperty = property.Value as IExportable;
                if (exportableProperty != null)
                {
                    XElement propertyElement = new XElement(Elements.Property,
                        new XAttribute(Attributes.Key, property.Key),
                        new XAttribute(Attributes.Type, property.Value.GetType().FullName)
                    );

                    exportableProperty.Export(propertyElement);

                    propertiesCollectionElement.Add(propertyElement);
                }
            }

            parentElement.Add(propertiesCollectionElement);
        }

        #endregion

        #region Import

        /// <summary>
        /// Reads <see cref="IdentificationModel"/> from XML file
        /// </summary>
        /// <param name="filePath">Full path to model XML file</param>
        /// <returns><see cref="IdentificationModel"/> instance read from <paramref name="filePath"/></returns>
        /// <exception cref="ArgumentNullException">If <paramref name="filePath"/> is null or empty</exception>
        public static IdentificationModel Open(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            FileInfo modelFileInfo = new FileInfo(filePath);
            IdentificationModel model = new IdentificationModel();

            using (FileStream modelFileStream = File.OpenRead(modelFileInfo.FullName))
            using (XmlReader modelFileReader = XmlReader.Create(modelFileStream, modelFileReaderSettings))
            {
                XDocument modelFileDocument = XDocument.Load(modelFileReader, LoadOptions.None);

                XElement optimizationParametersCollectionElement = ReadCollectionElement(Elements.OptimizationParameters, modelFileDocument.Root);
                XElement identificationParametersCollectionElement = ReadCollectionElement(Elements.IdentificationParameters, modelFileDocument.Root);
                XElement criteriaCollectionElement = ReadCollectionElement(Elements.Criteria, modelFileDocument.Root);
                XElement constraintsCollectionElement = ReadCollectionElement(Elements.FunctionalConstraints, modelFileDocument.Root);
                XElement realExperimentsCollectionElement = ReadCollectionElement(Elements.RealExperiments, modelFileDocument.Root);
                XElement identificationExperimentsCollectionElement = ReadCollectionElement(Elements.IdentificationExperiments, modelFileDocument.Root);
                XElement propertiesCollectionElement = ReadCollectionElement(Elements.Properties, modelFileDocument.Root, false);

                ReadParameters(model.OptimizationParameters, optimizationParametersCollectionElement, Elements.OptimizationParameter);
                ReadParameters(model.IdentificationParameters, identificationParametersCollectionElement, Elements.IdentificationParameter);
                ReadCriteria(model.Criteria, criteriaCollectionElement);
                ReadConstraints(model.FunctionalConstraints, constraintsCollectionElement);
                ReadRealExperiments(model.RealExperiments, realExperimentsCollectionElement);
                ReadIdentificationExperiments(model.IdentificationExperiments, identificationExperimentsCollectionElement);
                ReadPropertyCollection(model.Properties, propertiesCollectionElement);
            }

            return model;
        }

        /// <summary>
        /// Finds collection element among descendants of the <paramref name="parentElement"/> by name
        /// </summary>
        /// <param name="collectionElementName"><see cref="XName"/> of the collection element to be found</param>
        /// <param name="parentElement"><see cref="XElement"/> instance to look for the collection element in</param>
        /// <param name="throwIfMissing">Controls whether to throw exception if <paramref name="collectionElementName"/>
        /// not found or not</param>
        /// <returns><see cref="XElement"/> instance representing the required collection</returns>
        private static XElement ReadCollectionElement(XName collectionElementName, XElement parentElement, bool throwIfMissing = true)
        {
            XElement collectionElement = parentElement.Descendants(collectionElementName).FirstOrDefault();
            if (collectionElement == null && throwIfMissing)
            {
                throw new InvalidDataException("Missing " + collectionElementName.ToString() + " element");
            }

            return collectionElement;
        }

        /// <summary>
        /// Reads a collection of <see cref="Parameter"/> from XML
        /// </summary>
        /// <param name="parametersCollection">A collection to be read from XML</param>
        /// <param name="parametersCollectionElement"><see cref="XElement"/> to read a collection from</param>
        /// <param name="parameterElementName">Name of the XML element that represents <see cref="Parameter"/></param>
        private static void ReadParameters(NamedModelEntityCollection<Parameter> parametersCollection, XElement parametersCollectionElement, XName parameterElementName)
        {
            IEnumerable<XElement> parameterElements = parametersCollectionElement.Descendants(parameterElementName);
            foreach (XElement parameterElement in parameterElements)
            {
                TId id = TId.Parse(parameterElement.Attribute(Attributes.Id).Value);
                string name = parameterElement.Attribute(Attributes.Name).Value;
                string variableIdentifier = parameterElement.Attribute(Attributes.VariableIdentifier).Value;
                double minValue = ConvertEx.ToDoubleInvariant(parameterElement.Attribute(Attributes.MinValue).Value);
                double maxValue = ConvertEx.ToDoubleInvariant(parameterElement.Attribute(Attributes.MaxValue).Value);

                Parameter parameter = new Parameter(id, name, variableIdentifier, minValue, maxValue);
                ReadPropertyCollection(parameter.Properties, ReadCollectionElement(Elements.Properties, parameterElement, false));

                parametersCollection.Add(parameter);
            }
        }

        /// <summary>
        /// Reads a collection of <see cref="AdequacyCriterion"/> from XML
        /// </summary>
        /// <param name="criteriaCollection">A collection to be read from XML</param>
        /// <param name="criteriaCollectionElement"><see cref="XElement"/> to read a collection from</param>
        private static void ReadCriteria(NamedModelEntityCollection<AdequacyCriterion> criteriaCollection, XElement criteriaCollectionElement)
        {
            IEnumerable<XElement> criterionElements = criteriaCollectionElement.Descendants(Elements.Criterion);
            foreach (XElement criterionElement in criterionElements)
            {
                TId id = TId.Parse(criterionElement.Attribute(Attributes.Id).Value);
                string name = criterionElement.Attribute(Attributes.Name).Value;
                string variableIdentifier = criterionElement.Attribute(Attributes.VariableIdentifier).Value;
                AdequacyCriterionType criterionType = EnumEx.Parse<AdequacyCriterionType>(criterionElement.Attribute(Attributes.Type).Value);

                AdequacyCriterion criterion = new AdequacyCriterion(id, name, variableIdentifier, criterionType);
                ReadPropertyCollection(criterion.Properties, ReadCollectionElement(Elements.Properties, criterionElement, false));

                criteriaCollection.Add(criterion);
            }
        }

        /// <summary>
        /// Reads a collection of <see cref="Constraint"/> from XML
        /// </summary>
        /// <param name="constraintsCollection">A collection to be read from XML</param>
        /// <param name="constraintsCollectionElement"><see cref="XElement"/> to read a collection from</param>
        private static void ReadConstraints(NamedModelEntityCollection<Constraint> constraintsCollection, XElement constraintsCollectionElement)
        {
            IEnumerable<XElement> constraintElements = constraintsCollectionElement.Descendants(Elements.FunctionalConstraint);
            foreach (XElement constraintElement in constraintElements)
            {
                TId id = TId.Parse(constraintElement.Attribute(Attributes.Id).Value);
                string name = constraintElement.Attribute(Attributes.Name).Value;
                string variableIdentifier = constraintElement.Attribute(Attributes.VariableIdentifier).Value;
                Relation constraintRelation = EnumEx.Parse<Relation>(constraintElement.Attribute(Attributes.Relation).Value);
                double value = ConvertEx.ToDoubleInvariant(constraintElement.Attribute(Attributes.Value).Value);
                string expression = constraintElement.Attribute(Attributes.Expression).Value;

                Constraint constraint = new Constraint(id, name, variableIdentifier, constraintRelation, value, expression);
                ReadPropertyCollection(constraint.Properties, ReadCollectionElement(Elements.Properties, constraintElement, false));

                constraintsCollection.Add(constraint);
            }
        }

        /// <summary>
        /// Reads a collection of real <see cref="Experiment"/> from XML
        /// </summary>
        /// <param name="experimentCollection">A collection to be read from XML</param>
        /// <param name="experimentsCollectionElement"><see cref="XElement"/> to read a collection from</param>
        private static void ReadRealExperiments(ExperimentCollection experimentCollection, XElement experimentsCollectionElement)
        {
            IEnumerable<XElement> experimentElements = experimentsCollectionElement.Descendants(Elements.RealExperiment);
            foreach (XElement experimentElement in experimentElements)
            {
                TId id = TId.Parse(experimentElement.Attribute(Attributes.Id).Value);
                int number = Convert.ToInt32(experimentElement.Attribute(Attributes.Number).Value);

                Experiment experiment = new Experiment(id, number);

                ReadValueCollection(experiment.ParameterValues, Elements.OptimizationParameterValues, Elements.OptimizationParameterValue, experimentElement);
                ReadValueCollection(experiment.CriterionValues, Elements.RealCriterionValues, Elements.RealCriterionValue, experimentElement);
                ReadValueCollection(experiment.ConstraintValues, Elements.FunctionalConstraintValues, Elements.FunctionalConstraintValue, experimentElement);
                ReadPropertyCollection(experiment.Properties, ReadCollectionElement(Elements.Properties, experimentElement, false));

                experimentCollection.Add(experiment);
            }
        }

        /// <summary>
        /// Reads a collection of <see cref="IdentificationExperiment"/> from XML
        /// </summary>
        /// <param name="experimentCollection">A collection to be read from XML</param>
        /// <param name="experimentsCollectionElement"><see cref="XElement"/> to read a collection from</param>
        private static void ReadIdentificationExperiments(IdentificationExperimentCollection experimentCollection, XElement experimentsCollectionElement)
        {
            IEnumerable<XElement> experimentElements = experimentsCollectionElement.Descendants(Elements.IdentificationExperiment);
            foreach (XElement experimentElement in experimentElements)
            {
                TId id = TId.Parse(experimentElement.Attribute(Attributes.Id).Value);
                int number = Convert.ToInt32(experimentElement.Attribute(Attributes.Number).Value);
                TId realExperimentId = TId.Parse(experimentElement.Attribute(Attributes.RealExperimentId).Value);

                IdentificationExperiment experiment = new IdentificationExperiment(id, number, realExperimentId);

                ReadValueCollection(experiment.IdentificationParameterValues, Elements.IdentificationParameterValues, Elements.IdentificationParameterValue, experimentElement);
                ReadValueCollection(experiment.MathematicalCriterionValues, Elements.MathematicalCriterionValues, Elements.MathematicalCriterionValue, experimentElement);
                ReadValueCollection(experiment.AdequacyCriterionValues, Elements.AdequacyCriterionValues, Elements.AdequacyCriterionValue, experimentElement);
                ReadValueCollection(experiment.ConstraintValues, Elements.FunctionalConstraintValues, Elements.FunctionalConstraintValue, experimentElement);
                ReadPropertyCollection(experiment.Properties, ReadCollectionElement(Elements.Properties, experimentElement, false));

                experimentCollection.Add(experiment);
            }
        }

        /// <summary>
        /// Reads a collection of <see cref="Double"/> values from XML
        /// </summary>
        /// <param name="collection">Collection to be filled with values read from XML</param>
        /// <param name="collectionElementName">Name of the collection parent XML element</param>
        /// <param name="valueElementName">Name of the XML element that represents collection item</param>
        /// <param name="parentElement"><see cref="XElement"/> instance that is parent to the collection element</param>
        private static void ReadValueCollection(IDictionary<TId, double> collection, XName collectionElementName, XName valueElementName, XElement parentElement)
        {
            XElement valueCollectionElement = ReadCollectionElement(collectionElementName, parentElement);
            IEnumerable<XElement> valueElements = valueCollectionElement.Descendants(valueElementName);
            foreach (XElement valueElement in valueElements)
            {
                TId id = TId.Parse(valueElement.Attribute(Attributes.Id).Value);
                double value = ConvertEx.ToDoubleInvariant(valueElement.Attribute(Attributes.Value).Value);

                collection.Add(id, value);
            }
        }

        /// <summary>
        /// Reads <see cref="PropertyCollection"/> of custom properties from XML. Does nothing if
        /// <paramref name="propertiesCollectionElement"/> is null
        /// </summary>
        /// <param name="propertyCollection"><see cref="PropertyCollection"/> instance to be filled from XML</param>
        /// <param name="propertiesCollectionElement">Name of the element that is parent to the collection element</param>
        private static void ReadPropertyCollection(PropertyCollection propertyCollection, XElement propertiesCollectionElement)
        {
            if (propertiesCollectionElement == null)
            {
                return;
            }

            IEnumerable<XElement> propertyElements = propertiesCollectionElement.Descendants(Elements.Properties);
            foreach (XElement propertyElement in propertyElements)
            {
                string key = propertyElement.Attribute(Attributes.Key).Value;
                string propertyTypeName = propertyElement.Attribute(Attributes.Type).Value;

                Type propertyType = Type.GetType(propertyTypeName);
                if (typeof(CustomProperty).IsAssignableFrom(propertyType))
                {
                    CustomProperty property = (CustomProperty)Activator.CreateInstance(propertyType);
                    IImportable importableProperty = property as IImportable;
                    if (importableProperty != null)
                    {
                        importableProperty.Import(propertyElement);
                        propertyCollection.Add(key, property);
                    }
                }
            }
        }

        #endregion
    }
}