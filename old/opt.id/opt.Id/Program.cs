using System;
using System.Globalization;
using System.Windows.Forms;
using opt.Properties;
using opt.UI;

namespace opt.Id
{
    static class Program
    {
        public static Settings ApplicationSettings = new Settings();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.CurrentCulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SetCoreParameters();

            Application.Run(new StartForm());
        }

        private static void SetCoreParameters()
        {
            SettingsManager.Instance.Merge(ApplicationSettings.PropertyValues);
        }
    }
}