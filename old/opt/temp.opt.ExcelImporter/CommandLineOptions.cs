using System;
using System.Globalization;
using CommandLine;

namespace temp.opt.ExcelImporter
{
    public sealed class CommandLineOptions
    {
        [Option('m', "model", Required = true, HelpText = "Path to OPT model file")]
        public string ModelFilePath { get; set; }

        [Option('e', "excel", Required = true, HelpText = "Path to Excel file with data")]
        public string ExcelFilePath { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return string.Empty;
        }

        /// <summary>
        /// Reads command line arguments and creates <see cref="CommandLineOptions"/> instance
        /// based on their contents
        /// </summary>
        /// <param name="args">Command line arguments passed to the application</param>
        /// <returns><see cref="CommandLineOptions"/> instance filled with values from 
        /// command line arguments, or null if <paramref name="args"/> is null or empty or
        /// parsing was unsuccessful</returns>
        public static CommandLineOptions Parse(string[] args)
        {
            if (args == null || args.GetLength(0) == 0)
            {
                return null;
            }

            Parser argsParser = new Parser(new Action<ParserSettings>(ConfigureParser));
            CommandLineOptions parsedArgs = new CommandLineOptions();
            if (!argsParser.ParseArguments(args, parsedArgs))
            {
                return null;
            }

            return parsedArgs;
        }

        /// <summary>
        /// Configures command line arguments parser
        /// </summary>
        /// <param name="settings">Settings of the new parser; will be changed inside the method</param>
        private static void ConfigureParser(ParserSettings settings)
        {
            settings.CaseSensitive = false;
            settings.HelpWriter = null;
            settings.IgnoreUnknownArguments = true;
            settings.MutuallyExclusive = false;
            settings.ParsingCulture = CultureInfo.InvariantCulture;
        }
    }
}