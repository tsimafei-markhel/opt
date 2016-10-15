using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using opt.UI.Forms;
using opt.UI.Helpers;
using opt.UI.Helpers.CommandLine;
using opt.UI.Properties;

// TODO: Add XML comments

namespace opt
{
    static class Program
    {
        public static Settings ApplicationSettings = new Settings();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!CanStart())
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ParseCommandLineArguments(args);
            SetCoreParameters();
            SetApplicationCulture();
            Application.Run(new Form5());
        }

        private static void ParseCommandLineArguments(string[] args)
        {
            CommandLineArgs parsedArgs = CommandLineArgs.Parse(args);
            if (parsedArgs != null)
            {
                try
                {
                    CommandLineArgsHelper.ApplyCommandLineArgs(parsedArgs, ApplicationSettings);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowError("Failed to process command line arguments: " + ex.Message);
                }
            }
        }

        private static bool CanStart()
        {
            string licenseFilePath = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + ApplicationSettings.LicenseFileName;
            try
            {
                return LicenseValidator.ValidateLicense(licenseFilePath);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex.Message);
                return false;
            }
        }

        private static void SetApplicationCulture()
        {
            if (ApplicationSettings.UseInvariantCulture)
            {
                Application.CurrentCulture = CultureInfo.InvariantCulture;
            }
        }

        private static void SetCoreParameters()
        {
            SettingsManager.Instance.Merge(ApplicationSettings.PropertyValues);
        }
    }
}