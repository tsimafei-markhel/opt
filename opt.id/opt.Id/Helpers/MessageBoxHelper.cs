using System.Windows.Forms;
using opt.Id;

namespace opt.Helpers
{
    internal static class MessageBoxHelper
    {
        /// <summary>
        /// Shows Exclamation <see cref="MessageBox"/>
        /// </summary>
        /// <param name="message">Text to show in message box</param>
        public static void ShowExclamation(string message)
        {
            MessageBox.Show(message, Program.ApplicationSettings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Shows Error <see cref="MessageBox"/>
        /// </summary>
        /// <param name="message">Text to show in message box</param>
        public static void ShowError(string message)
        {
            MessageBox.Show(message, Program.ApplicationSettings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows Information <see cref="MessageBox"/>
        /// </summary>
        /// <param name="message">Text to show in message box</param>
        public static void ShowInformation(string message)
        {
            MessageBox.Show(message, Program.ApplicationSettings.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}