using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using opt.Drafter.DataModel;
using opt.Extensions;

namespace opt.Drafter.Xml
{
    public static class XmlConstantProvider
    {
        /// <summary>
        /// Namespace to be used in XML model constants files
        /// </summary>
        public const string Namespace = "http://www.opt.com/model/constants";

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
        /// Helper class, stores <see cref="XName"/> of different XML elements used in model constants XML
        /// </summary>
        private static class Elements
        {
            public static readonly XName Constant = XName.Get("constant", Namespace);
            public static readonly XName ModelConstants = XName.Get("modelConstants", Namespace);
        }

        /// <summary>
        /// Helper class, stores <see cref="XName"/> of different attributes used in model constants XML
        /// </summary>
        private static class Attributes
        {
            public static readonly XName Id = XName.Get("id");
            public static readonly XName Name = XName.Get("name");
            public static readonly XName Value = XName.Get("value");
            public static readonly XName VariableIdentifier = XName.Get("variableIdentifier");
        }

        /// <summary>
        /// Writes constants from <paramref name="modelDraft"/> to XML file
        /// </summary>
        /// <param name="modelDraft"><see cref="ModelDraft"/> instance with constants to be written to XML</param>
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

            XDocument modelConstantsDocument = new XDocument(new XDeclaration("1.0", "UTF-8", null));

            WriteModelConstantsElement(modelConstantsDocument);
            WriteConstants(modelDraft, modelConstantsDocument.Root);

            FileInfo modelConstantsFileInfo = new FileInfo(filePath);
            using (FileStream modelConstantsFileStream = modelConstantsFileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.None))
            using (XmlWriter modelConstantsFileWriter = XmlWriter.Create(modelConstantsFileStream, modelFileWriterSettings))
            {
                modelConstantsDocument.Save(modelConstantsFileWriter);
            }
        }

        private static void WriteModelConstantsElement(XDocument modelConstantsDocument)
        {
            modelConstantsDocument.Add(new XElement(Elements.ModelConstants));
        }

        private static void WriteConstants(ModelDraft modelDraft, XElement modelConstantsDocumentRoot)
        {
            IEnumerable<PromotableConstant> constants = modelDraft.PromotableConstants.Values.Where(constant => !constant.IsPromoted);
            foreach (PromotableConstant constant in constants)
            {
                XElement constantElement = new XElement(Elements.Constant,
                    new XAttribute(Attributes.Id, constant.Id.ToString()),
                    new XAttribute(Attributes.Name, constant.Name),
                    new XAttribute(Attributes.VariableIdentifier, constant.VariableIdentifier),
                    new XAttribute(Attributes.Value, constant.Value.ToStringInvariant())
                );

                modelConstantsDocumentRoot.Add(constantElement);
            }
        }
    }
}