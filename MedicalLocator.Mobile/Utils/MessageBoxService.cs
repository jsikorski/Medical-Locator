using System.Windows;
using Caliburn.Micro;

namespace MedicalLocator.Mobile.Utils
{
    public class MessageBoxService
    {
        public static MessageBoxResult ShowQuestion(string message)
        {
            MessageBoxResult result = MessageBoxResult.None;
            Execute.OnUIThread(() => result = MessageBox.Show(message, "Information", MessageBoxButton.OKCancel));
            return result;
        }

        public static void ShowError(string message)
        {
            Execute.OnUIThread(() => MessageBox.Show(message, "Error", MessageBoxButton.OK));
        }

        public static void ShowInternalError(string message)
        {
            string fullMessage = message + " Please contact with application support.";
            Execute.OnUIThread(() => MessageBox.Show(fullMessage, "Error", MessageBoxButton.OK));
        }

        public static void ShowConnectionError()
        {
            ShowError("Cannot connect with server. Please " +
                      "check data transfer connection or Wi-Fi.");
        }
    }
}