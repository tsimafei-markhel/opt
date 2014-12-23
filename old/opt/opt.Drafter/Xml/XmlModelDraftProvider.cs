using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using opt.Drafter.DataModel;
using opt.DataModel;
using opt.Extensions;

namespace opt.Drafter.Xml
{
    public static class XmlModelDraftProvider
    {
        /// <summary>
        /// Namespace to be used in XML model draft files
        /// </summary>
        public const string Namespace = "http://www.opt.com/model.draft";

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
        /// Helper class, stores <see cref="XName"/> of different XML elements used in model draft XML
        /// </summary>
        private static class Elements
        {
            public static readonly XName ModelDraft = XName.Get("modelDraft", Namespace);
            public static readonly XName PromotableConstant = XName.Get("promotableConstant", Namespace);
            public static readonly XName PromotableConstants = XName.Get("promotableConstants", Namespace);
            public static readonly XName PromotableCriteria = XName.Get("promotableCriteria", Namespace);
            public static readonly XName PromotableCriterion = XName.Get("promotableCriterion", Namespace);
        }

        /// <summary>
        /// Helper class, stores <see cref="XName"/> of different attributes used in model draft XML
        /// </summary>
        private static class Attributes
        {
            public static readonly XName Id = XName.Get("id");
            public static readonly XName IsPromoted = XName.Get("isPromoted");
            public static readonly XName MaxValue = XName.Get("maxValue");
            public static readonly XName MinValue = XName.Get("minValue");
            public static readonly XName Name = XName.Get("name");
            public static readonly XName Relation = XName.Get("relation");
            public static readonly XName Type = XName.Get("type");
            public static readonly XName Value = XName.Get("value");
            public static readonly XName VariableIdentifier = XName.Get("variableIdentifier");
        }

        #region Export

        /// <summary>
        /// Writes <paramref name="modelDraft"/> to XML file
        /// </summary>
        /// <param name="modelDraft"><see cref="ModelDraft"/> instance to be written to XML</param>
        /// <param name="filePath">Full path to target XML file</param>
        public static void Save(ModelDraft modelDraft, string filePath)
        {
            if (modelDraft == null)
            {
                throw new ArgumentNullException("modelDraft");
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            XDocument modelDraftDocument = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            WriteModelDraftElement(modelDraftDocument);
            WritePromotableConstants(modelDraft, modelDraftDocument.Root);
            WritePromotableCriteria(modelDraft, modelDraftDocument.Root);

            FileInfo modelDraftFileInfo = new FileInfo(filePath);
            using (FileStream modelDraftFileStream = modelDraftFileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            using (XmlWriter modelDraftFileWriter = XmlWriter.Create(modelDraftFileStream, modelFileWriterSettings))
            {
                modelDraftDocument.Save(modelDraftFileWriter);
            }
        }

        private static void WriteModelDraftElement(XDocument modelDraftDocument)
        {
            modelDraftDocument.Add(new XElement(Elements.ModelDraft));
        }

        private static void WritePromotableConstants(ModelDraft modelDraft, XElement modelDraftDocumentRoot)
        {
            XElement promotableConstantsCollectionElement = new XElement(Elements.PromotableConstants);
            foreach (PromotableConstant promotableConstant in modelDraft.PromotableConstants.Values)
            {
                XElement promotableConstantElement = new XElement(Elements.PromotableConstant,
                    new XAttribute(Attributes.Id, promotableConstant.Id.ToString()),
                    new XAttribute(Attributes.Name, promotableConstant.Name),
                    new XAttribute(Attributes.VariableIdentifier, promotableConstant.VariableIdentifier),
                    new XAttribute(Attributes.IsPromoted, promotableConstant.IsPromoted.ToString()),
                    new XAttribute(Attributes.Value, promotableConstant.Value.ToStringInvariant()),
                    new XAttribute(Attributes.MinValue, promotableConstant.MinValue.ToStringInvariant()),
                    new XAttribute(Attributes.MaxValue, promotableConstant.MaxValue.ToStringInvariant())
                );

                promotableConstantsCollectionElement.Add(promotableConstantElement);
            }

            modelDraftDocumentRoot.Add(promotableConstantsCollectionElement);
        }

        private static void WritePromotableCriteria(ModelDraft modelDraft, XElement modelDraftDocumentRoot)
        {
            XElement promotableCriterionCollectionElement = new XElement(Elements.PromotableCriteria);
            foreach (PromotableCriterion promotableCriterion in modelDraft.PromotableCriteria.Values)
            {
                XElement criterionElement = new XElement(Elements.PromotableCriterion,
                    new XAttribute(Attributes.Id, promotableCriterion.Id.ToString()),
                    new XAttribute(Attributes.Name, promotableCriterion.Name),
                    new XAttribute(Attributes.VariableIdentifier, promotableCriterion.VariableIdentifier),
                    new XAttribute(Attributes.IsPromoted, promotableCriterion.IsPromoted.ToString()),
                    new XAttribute(Attributes.Type, promotableCriterion.Type.ToString()),
                    new XAttribute(Attributes.Relation, promotableCriterion.ConstraintRelation.ToString()),
                    new XAttribute(Attributes.Value, promotableCriterion.Value.ToStringInvariant())
                );

                promotableCriterionCollectionElement.Add(criterionElement);
            }

            modelDraftDocumentRoot.Add(promotableCriterionCollectionElement);
        }

        #endregion

        #region Import

        /// <summary>
        /// Reads <see cref="ModelDraft"/> from XML file
        /// </summary>
        /// <param name="filePath">Full path to model XML file</param>
        /// <returns><see cref="ModelDraft"/> instance read from <paramref name="filePath"/></returns>
        public static ModelDraft Open(string filePath)
        {
            ModelDraft modelDraft = new ModelDraft();

            using (FileStream modelDraftFileStream = File.OpenRead(filePath))
            using (XmlReader modelDraftFileReader = XmlReader.Create(filePath, modelFileReaderSettings))
            {
                XDocument modelDraftFileDocument = XDocument.Load(modelDraftFileReader, LoadOptions.None);

                XElement promotableConstantCollectionElement = ReadCollectionElement(Elements.PromotableConstants, modelDraftFileDocument.Root);
                XElement promotableCriterionCollectionElement = ReadCollectionElement(Elements.PromotableCriteria, modelDraftFileDocument.Root);

                ReadPromotableConstants(modelDraft, promotableConstantCollectionElement);
                ReadPromotableCriteria(modelDraft, promotableCriterionCollectionElement);
            }

            return modelDraft;
        }

        /// <summary>
        /// Finds collection element among descendants of the <paramref name="parentElement"/> by name
        /// </summary>
        /// <param name="collectionElementName"><see cref="XName"/> of the collection element to be found</param>
        /// <param name="parentElement"><see cref="XElement"/> instance to look for the collection element in</param>
        /// <returns><see cref="XElement"/> instance representing the required collection</returns>
        private static XElement ReadCollectionElement(XName collectionElementName, XElement parentElement)
        {
            XElement collectionElement = parentElement.Descendants(collectionElementName).FirstOrDefault();
            if (collectionElement == null)
            {
                throw new InvalidDataException("Missing " + collectionElementName.ToString() + " element");
            }

            return collectionElement;
        }

        private static void ReadPromotableConstants(ModelDraft modelDraft, XElement promotableConstantCollectionElement)
        {
            IEnumerable<XElement> promotableConstantElements = promotableConstantCollectionElement.Descendants(Elements.PromotableConstant);
            foreach (XElement promotableConstantElement in promotableConstantElements)
            {
                TId id = TId.Parse(promotableConstantElement.Attribute(Attributes.Id).Value);
                string name = promotableConstantElement.Attribute(Attributes.Name).Value;
                string variableIdentifier = promotableConstantElement.Attribute(Attributes.VariableIdentifier).Value;
                bool isPromoted = Convert.ToBoolean(promotableConstantElement.Attribute(Attributes.IsPromoted).Value);
                double value = ConvertExtensions.ToDoubleInvariant(promotableConstantElement.Attribute(Attributes.Value).Value);
                double minValue = ConvertExtensions.ToDoubleInvariant(promotableConstantElement.Attribute(Attributes.MinValue).Value);
                double maxValue = ConvertExtensions.ToDoubleInvariant(promotableConstantElement.Attribute(Attributes.MaxValue).Value);

                PromotableConstant promotableConstant = new PromotableConstant(id, name, variableIdentifier, value)
                {
                    IsPromoted = isPromoted,
                    MaxValue = maxValue,
                    MinValue = minValue
                };

                modelDraft.PromotableConstants.Add(promotableConstant);
            }
        }

        private static void ReadPromotableCriteria(ModelDraft modelDraft, XElement promotableCriterionCollectionElement)
        {
            IEnumerable<XElement> promotableCriterionElements = promotableCriterionCollectionElement.Descendants(Elements.PromotableCriterion);
            foreach (XElement promotableCriterionElement in promotableCriterionElements)
            {
                TId id = TId.Parse(promotableCriterionElement.Attribute(Attributes.Id).Value);
                string name = promotableCriterionElement.Attribute(Attributes.Name).Value;
                string variableIdentifier = promotableCriterionElement.Attribute(Attributes.VariableIdentifier).Value;
                bool isPromoted = Convert.ToBoolean(promotableCriterionElement.Attribute(Attributes.IsPromoted).Value);
                CriterionType criterionType = EnumExtensions.Parse<CriterionType>(promotableCriterionElement.Attribute(Attributes.Type).Value);
                Relation constraintRelation = EnumExtensions.Parse<Relation>(promotableCriterionElement.Attribute(Attributes.Relation).Value);
                double value = ConvertExtensions.ToDoubleInvariant(promotableCriterionElement.Attribute(Attributes.Value).Value);

                PromotableCriterion promotableCriterion = new PromotableCriterion(id, name, variableIdentifier, criterionType)
                {
                    ConstraintRelation = constraintRelation,
                    IsPromoted = isPromoted,
                    Value = value
                };

                modelDraft.PromotableCriteria.Add(promotableCriterion);
            }
        }

        #endregion
    }
}