using System;
using System.Linq;

namespace TestModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Count() < 1)
            {
                Console.WriteLine("Supply full path to the opt.id model as a single command line argument.");
                Environment.Exit(1);
            }

            string modelFilePath = args[0];
            try
            {
                ModelCalculator calculator = new ModelCalculator(modelFilePath);
                calculator.CalculateModel();
                calculator.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing model: " + ex.Message);
                Console.ReadKey();
                Environment.Exit(1);
            }

            Environment.Exit(0);
        }
    }
}