using System;
using System.Configuration;

namespace opt
{
    /// <summary>
    /// Stores opt.Core settings
    /// </summary>
    /// <remarks>Singleton</remarks>
    public sealed class SettingsManager : SettingsBase
    {
        private static readonly object syncRoot = new object();
        private static volatile SettingsManager instance;

        /// <summary>
        /// Gets instance of <see cref="SettingsManager"/>
        /// </summary>
        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new SettingsManager();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Gets or sets name of the application that uses opt.Core
        /// </summary>
        /// <value>Default value: opt.Core.dll</value>
        [UserScopedSetting()]
        [DefaultSettingValue("opt.Core.dll")]
        public string ApplicationName
        {
            get
            {
                return ((string)(this["ApplicationName"]));
            }
            set
            {
                this["ApplicationName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets number of decimal places (digits in the fractional part of a number written in decimal form)
        /// </summary>
        /// <value>Default value: 3</value>
        [UserScopedSetting()]
        [DefaultSettingValue("3")]
        public int ValuesDecimalPlaces
        {
            get
            {
                return ((int)(this["ValuesDecimalPlaces"]));
            }
            set
            {
                this["ValuesDecimalPlaces"] = value;
            }
        }

        /// <summary>
        /// Gets or sets relative path to the file with quantitive model characteristics
        /// </summary>
        /// <value>Default value: \Models\numpk.txt</value>
        /// <remarks>Only for the simplified calc modules</remarks>
        [UserScopedSetting()]
        [DefaultSettingValue("\\Models\\numpk.txt")]
        public string QuantitiesFileName
        {
            get
            {
                return ((string)(this["QuantitiesFileName"]));
            }
            set
            {
                this["QuantitiesFileName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets relative path to the file with model parameters values
        /// </summary>
        /// <value>Default value: \Models\par.opt</value>
        /// <remarks>Only for the simplified calc modules</remarks>
        [UserScopedSetting()]
        [DefaultSettingValue("\\Models\\par.opt")]
        public string ParametersFileName
        {
            get
            {
                return ((string)(this["ParametersFileName"]));
            }
            set
            {
                this["ParametersFileName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets relative path to the file with model criteria and constraints values
        /// </summary>
        /// <value>Default value: \Models\fun.opt</value>
        /// <remarks>Only for the simplified calc modules</remarks>
        [UserScopedSetting()]
        [DefaultSettingValue("\\Models\\fun.opt")]
        public string ResultsFileName
        {
            get
            {
                return ((string)(this["ResultsFileName"]));
            }
            set
            {
                this["ResultsFileName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to use old XML model provider or the new one
        /// </summary>
        /// <value>Default value: false</value>
        /// <remarks>Use only for backward compatibility</remarks>
        [UserScopedSetting()]
        [DefaultSettingValue("False")]
        public bool UseOldXmlProvider
        {
            get
            {
                return ((bool)(this["UseOldXmlProvider"]));
            }
            set
            {
                this["UseOldXmlProvider"] = value;
            }
        }

        /// <summary>
        /// Gets a format of double to string conversion for ToString() method
        /// </summary>
        /// <value>Default value: F3 (results in #.###)</value>
        [UserScopedSetting()]
        public string DoubleStringFormat
        {
            get
            {
                return "F" + ValuesDecimalPlaces;
            }
        }

        /// <summary>
        /// Initializes new instance of <see cref="SettingsManager"/>, creates empty storage for properties
        /// and fills it with default property values
        /// </summary>
        private SettingsManager()
        {
            Initialize(new SettingsContext(), new SettingsPropertyCollection(), new SettingsProviderCollection());
            SettingsHelper.AddDefaultProperties(GetType(), Properties, PropertyValues);
        }

        /// <summary>
        /// Copies properties and their values from <paramref name="propertyValueCollection"/>
        /// </summary>
        /// <param name="propertyValueCollection">Property value storage to copy data from</param>
        /// <remarks>Existing values are overwritten by values from <paramref name="propertyValueCollection"/></remarks>
        public void Merge(SettingsPropertyValueCollection propertyValueCollection)
        {
            if (propertyValueCollection == null)
            {
                throw new ArgumentNullException("propertyValueCollection");
            }

            foreach (SettingsPropertyValue propertyValue in propertyValueCollection)
            {
                SettingsProperty property = propertyValue.Property;

                if (Properties[property.Name] != null)
                {
                    Properties.Remove(property.Name);
                }

                Properties.Add(property);

                if (PropertyValues[propertyValue.Name] != null)
                {
                    PropertyValues.Remove(propertyValue.Name);
                }

                PropertyValues.Add(propertyValue);
            }
        }
    }
}