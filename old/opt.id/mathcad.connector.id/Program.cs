using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using opt.Helpers;

namespace mathcad.connector
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string modelFilePath = string.Empty;
            string mathcadFilePath = string.Empty;
            CommandLineArgs parsedArgs = CommandLineArgs.Parse(args);
            if (parsedArgs != null)
            {
                modelFilePath = PathHelper.ResolveRelativePath(parsedArgs.ModelFilePath, Application.StartupPath);
                mathcadFilePath = PathHelper.ResolveRelativePath(parsedArgs.MathcadFilePath, Application.StartupPath);

                if (parsedArgs.QuietMode)
                {
                    ProcessQuietly(modelFilePath, mathcadFilePath);
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(modelFilePath, mathcadFilePath));
        }

        private static void ProcessQuietly(string modelFilePath, string mathcadFilePath)
        {
            AllocConsole();

            try
            {
                QuietHandler handler = new QuietHandler(modelFilePath, mathcadFilePath);
                handler.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}