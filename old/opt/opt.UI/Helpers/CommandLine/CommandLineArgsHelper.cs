using System;
using opt.UI.Properties;

// TODO: Refactor options application

namespace opt.UI.Helpers.CommandLine
{
    /// <summary>
    /// Helper class, contains routines for applying parsed command line arguments to the
    /// application settings storage
    /// </summary>
    internal static class CommandLineArgsHelper
    {
        /// <summary>
        /// Copies values from parsed command line arguments to application settings storage
        /// </summary>
        /// <param name="args">Parsed command line arguments</param>
        /// <param name="settingsStorage">Application settings storage</param>
        public static void ApplyCommandLineArgs(CommandLineArgs args, Settings settingsStorage)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            if (settingsStorage == null)
            {
                throw new ArgumentNullException("settingsStorage");
            }

            settingsStorage.ModelFilePath = args.ModelFilePath;
            settingsStorage.CalcAppFilePath = args.CalcAppFilePath;
        }
    }
}