using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using opt.DataModel;
using opt.Drafter.CommandLine;
using opt.Drafter.DataModel;
using opt.Drafter.Xml;
using opt.Provider.Xml;

// TODO: Refactor this!

namespace opt.Drafter
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
            Application.CurrentCulture = CultureInfo.InvariantCulture;

            CommandLineArgs parsedArgs = CommandLineArgs.Parse(args);
            if (parsedArgs != null)
            {
                AllocConsole();
                Console.WriteLine("Entering batch mode...");

                if (!string.IsNullOrEmpty(parsedArgs.ModelDraftFilePath) &&
                    !string.IsNullOrEmpty(parsedArgs.OutputFolderPath))
                {
                    ModelDraft draft;
                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Reading model draft XML...");
                        draft = XmlModelDraftProvider.Open(parsedArgs.ModelDraftFilePath);
                        Console.WriteLine("    Model draft XML was loaded!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.ReadKey();
                        return;
                    }

                    if (draft == null)
                    {
                        Console.WriteLine("Could not load model draft from XML");
                        Console.ReadKey();
                        return;
                    }

                    try
                    {
                        if (!Directory.Exists(parsedArgs.OutputFolderPath))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Creating output folder...");
                            Directory.CreateDirectory(parsedArgs.OutputFolderPath);
                            Console.WriteLine("    Output was folder created!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.ReadKey();
                        return;
                    }

                    try
                    {
                        Console.WriteLine();
                        Console.WriteLine("Converting draft to model...");
                        Model model = ModelDraftToModelConverter.Convert(draft);
                        Console.WriteLine("    Draft was converted to model!");

                        Console.WriteLine();
                        Console.WriteLine("Saving model XML to 'model.xml'...");
                        (new XmlModelProvider()).Save(model, Path.Combine(parsedArgs.OutputFolderPath, "model.xml"));
                        Console.WriteLine("    Model XML was saved!");

                        Console.WriteLine();
                        Console.WriteLine("Saving model constants XML to 'constants.xml'...");
                        XmlConstantProvider.Save(draft, Path.Combine(parsedArgs.OutputFolderPath, "constants.xml"));
                        Console.WriteLine("    Model constants XML was saved!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.ReadKey();
                        return;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ReadKey();
                return;
            }

            // No UI for now...
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            AllocConsole();
            Console.WriteLine("No UI mode!");
            Console.ReadKey();
        }

        
    }
}