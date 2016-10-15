using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using opt.DataModel;

// TODO: Use Singleton?
// TODO: Make two internal providers non-static?
// TODO: Add schema for new provider

namespace opt.Xml
{
    /// <summary>
    /// XML provider (writes <see cref="Model"/> to XML and reads it from XML)
    /// </summary>
    public static class XmlModelProvider
    {
        /// <summary>
        /// Old XML file format indicator
        /// </summary>
        private const string oldFormatRootElementName = "ModelInfo";

        /// <summary>
        /// Reads <see cref="Model"/> from XML file. Automatically detects and handles XML files of old format
        /// </summary>
        /// <param name="filePath">Full path to model XML file</param>
        /// <returns><see cref="Model"/> instance read from <paramref name="filePath"/></returns>
        public static Model Open(string filePath)
        {
            if (IsOfOldFormat(filePath))
            {
                return OldXmlModelProvider.Open(filePath);
            }
            else
            {
                return NewXmlModelProvider.Open(filePath);
            }
        }

        /// <summary>
        /// Writes <paramref name="model"/> to XML file. Format (old/current) is controlled by a setting
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be written to XML</param>
        /// <param name="filePath">Full path to target XML file</param>
        public static void Save(Model model, string filePath)
        {
            if (SettingsManager.Instance.UseOldXmlProvider)
            {
                OldXmlModelProvider.Save(model, filePath);
            }
            else
            {
                NewXmlModelProvider.Save(model, filePath);
            }
        }

        /// <summary>
        /// Creates <see cref="XDocument"/> with <paramref name="model"/> contents. Format (old/current) is controlled by a setting
        /// </summary>
        /// <param name="model"><see cref="Model"/> instance to be written to XML</param>
        /// <returns><see cref="XDocument"/> with <paramref name="model"/> contents</returns>
        /// <remarks>Left for possible external usage</remarks>
        public static XDocument GetXDocument(Model model)
        {
            if (SettingsManager.Instance.UseOldXmlProvider)
            {
                return OldXmlModelProvider.GetXDocument(model);
            }
            else
            {
                return NewXmlModelProvider.GetXDocument(model);
            }
        }

        /// <summary>
        /// Detects old XMl file format
        /// </summary>
        /// <param name="filePath">Full path to target XML file</param>
        /// <returns>True if XML model file is of old format</returns>
        private static bool IsOfOldFormat(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("filePath");
            }

            using (FileStream fileStream = File.OpenRead(filePath))
            using (XmlReader fileReader = XmlReader.Create(fileStream))
            {
                fileReader.MoveToContent();
                if (fileReader.LocalName.Equals(oldFormatRootElementName, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
        }
    }
}