using opt.Bionic.Properties;
using opt.Bionic.UI;
using System;
using System.Windows.Forms;

namespace opt.Bionic
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
            SetCoreParameters();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void SetCoreParameters()
        {
            SettingsManager.Instance.Merge(ApplicationSettings.PropertyValues);
        }
    }
}