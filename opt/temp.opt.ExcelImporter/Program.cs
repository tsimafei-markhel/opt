using System;
using System.Globalization;
using System.IO;
using System.Threading;
using OfficeOpenXml;
using opt.DataModel;
using opt.Provider;
using opt.Provider.Xml;

namespace temp.opt.ExcelImporter
{
    public class Program
    {
        private static IModelProvider modelProvider = new XmlModelProvider();

        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            CommandLineOptions options = CommandLineOptions.Parse(args);
            if (options != null)
            {
                Model model = modelProvider.Load(options.ModelFilePath);

                ExcelPackage excel = new ExcelPackage(new FileInfo(options.ExcelFilePath));
                ExcelWorksheet dataSheet = excel.Workbook.Worksheets["Single-objective points"];

                for (int i = 1; i <= 60; i++)
                {
                    Experiment e = new Experiment(model.Experiments.GetFreeConsequentId(), i + 100);
                    for (int col = 1; col <= 11; col++)
                    {
                        e.ParameterValues.Add(col - 1, Convert.ToDouble(dataSheet.Cells[i, col].Value));
                    }

                    model.Experiments.Add(e.Id, e);
                }

                modelProvider.Save(model, options.ModelFilePath);
            }
        }
    }
}