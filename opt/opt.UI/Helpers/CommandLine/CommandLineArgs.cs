﻿using System;
using System.Globalization;
using CommandLine;

namespace opt.UI.Helpers.CommandLine
{
    /// <summary>
    /// Used to store and to parse command line arguments to
    /// </summary>
    internal sealed class CommandLineArgs
    {
        /// <summary>
        /// Gets or sets full path to the OPT model XML file to load
        /// </summary>
        [Option('m', "model", Required = false, HelpText = "OPT model file path.", DefaultValue = "")]
        public string ModelFilePath { get; set; }

        /// <summary>
        /// Gets or sets full path to the calculation application executable file
        /// </summary>
        [Option('c', "calcapp", Required = false, HelpText = "Calculation application executable file path.", DefaultValue = "")]
        public string CalcAppFilePath { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="CommandLineArgs"/>. Made private on purpose.
        /// Use <see cref="CommandLineArgs.Parse"/> to create new instance
        /// </summary>
        private CommandLineArgs()
        {
        }

        /// <summary>
        /// Reads command line arguments and creates <see cref="CommandLineArgs"/> instance
        /// based on their contents
        /// </summary>
        /// <param name="args">Command line arguments passed to the application</param>
        /// <returns><see cref="CommandLineArgs"/> instance filled with values from 
        /// command line arguments, or null if <paramref name="args"/> is null or empty or
        /// parsing was unsuccessful</returns>
        public static CommandLineArgs Parse(string[] args)
        {
            if (args == null || args.GetLength(0) == 0)
            {
                return null;
            }

            Parser argsParser = new Parser(new Action<ParserSettings>(ConfigureParser));
            CommandLineArgs parsedArgs = new CommandLineArgs();
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