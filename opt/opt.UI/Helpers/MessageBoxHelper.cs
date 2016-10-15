using System.Windows.Forms;

namespace opt.UI.Helpers
{
    /// <summary>
    /// Contains shortened methods for displaying <see cref="MessageBox"/>
    /// </summary>
    internal static class MessageBoxHelper
    {
        /// <summary>
        /// Shows <see cref="MessageBox"/> with <paramref name="message"/> text, OK button and 
        /// <paramref name="icon"/> icon
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="icon">Icon to be displayed</param>
        private static void ShowOkMessage(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, Program.ApplicationSettings.ApplicationName, MessageBoxButtons.OK, icon);
        }

        /// <summary>
        /// Shows <see cref="MessageBox"/> with <paramref name="message"/> text, OK button and 
        /// <see cref="MessageBoxIcon.Error"/> icon
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void ShowError(string message)
        {
            ShowOkMessage(message, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows <see cref="MessageBox"/> with <paramref name="message"/> text, OK button and 
        /// <see cref="MessageBoxIcon.Exclamation"/> icon
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void ShowExclamation(string message)
        {
            ShowOkMessage(message, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Shows <see cref="MessageBox"/> with <paramref name="message"/> text, OK button and 
        /// <see cref="MessageBoxIcon.Information"/> icon
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void ShowInformation(string message)
        {
            ShowOkMessage(message, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows <see cref="MessageBox"/> with <paramref name="message"/> text, OK button and 
        /// <see cref="MessageBoxIcon.Stop"/> icon
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        public static void ShowStop(string message)
        {
            ShowOkMessage(message, MessageBoxIcon.Stop);
        }
    }
}