using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace opt
{
    /// <summary>
    /// Helper class, contains routines for settings storage initialization
    /// </summary>
    internal static class SettingsHelper
    {
        /// <summary>
        /// Gets all properties of the <paramref name="typeToSearch"/> with attribute of <paramref name="attributeType"/>
        /// </summary>
        /// <param name="typeToSearch">Type to take properties from</param>
        /// <param name="attributeType">Attribute type to search for</param>
        /// <returns>Collection of properties that belong to <paramref name="typeToSearch"/> and are decorated
        /// with attribute of <paramref name="attributeType"/></returns>
        public static IEnumerable<PropertyInfo> GetPropertiesWithAttribute(Type typeToSearch, Type attributeType)
        {
            return typeToSearch.GetProperties().Where(property => Attribute.IsDefined(property, attributeType));
        }

        /// <summary>
        /// Creates instance of <see cref="SettingsProperty"/> with desired parameters
        /// </summary>
        /// <param name="name">Name of the new <see cref="SettingsProperty"/></param>
        /// <param name="defaultValue">Default value of the parameter</param>
        /// <param name="propertyValueType">Type of the parameter</param>
        /// <param name="attributes">Custom attributes to copy</param>
        /// <returns>New instance of <see cref="SettingsProperty"/> with desired parameters</returns>
        public static SettingsProperty BuildSettingsProperty(string name, object defaultValue, Type propertyValueType, object[] attributes)
        {
            SettingsProperty setting = new SettingsProperty(name)
            {
                DefaultValue = defaultValue,
                IsReadOnly = false,
                PropertyType = propertyValueType
            };

            foreach (object settingAttribute in attributes)
            {
                setting.Attributes.Add(settingAttribute.GetType(), settingAttribute);
            }

            return setting;
        }

        /// <summary>
        /// Creates instance of <see cref="SettingsPropertyValue"/> for a certain <see cref="SettingsProperty"/>
        /// </summary>
        /// <param name="property">Corresponding <see cref="SettingsProperty"/> instance this value belongs to</param>
        /// <returns>New instance of <see cref="SettingsPropertyValue"/> with desired parameters</returns>
        public static SettingsPropertyValue BuildSettingsPropertyValue(SettingsProperty property)
        {
            return new SettingsPropertyValue(property)
            {
                Deserialized = false,
                IsDirty = false
            };
        }

        /// <summary>
        /// Adds default properties to the settings storage of <paramref name="settingsStorageType"/> type.
        /// Properties are taken from the type definition. Only those are taken which are decorated with 
        /// <see cref="DefaultSettingValueAttribute"/> attribute (i.e. have default values)
        /// </summary>
        /// <param name="settingsStorageType">Type of the settings storage to take properties from</param>
        /// <param name="propertyCollection">Collection to add instances of <see cref="SettingsProperty"/> to</param>
        /// <param name="propertyValueCollection">Collection to add corresponding instances of <see cref="SettingsPropertyValue"/> to</param>
        public static void AddDefaultProperties(
            Type settingsStorageType,
            SettingsPropertyCollection propertyCollection,
            SettingsPropertyValueCollection propertyValueCollection)
        {
            IEnumerable<PropertyInfo> settingProperties = GetPropertiesWithAttribute(settingsStorageType, typeof(DefaultSettingValueAttribute));
            foreach (PropertyInfo settingProperty in settingProperties)
            {
                DefaultSettingValueAttribute defaultValueAttribute = settingProperty.GetCustomAttributes(typeof(DefaultSettingValueAttribute), false)[0]
                    as DefaultSettingValueAttribute;
                if (defaultValueAttribute != null)
                {
                    SettingsProperty setting = BuildSettingsProperty(
                        settingProperty.Name, defaultValueAttribute.Value, settingProperty.PropertyType, settingProperty.GetCustomAttributes(true));
                    SettingsPropertyValue settingValue = BuildSettingsPropertyValue(setting);

                    propertyCollection.Add(setting);
                    propertyValueCollection.Add(settingValue);
                }
            }
        }
    }
}