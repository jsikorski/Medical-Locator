using System.Windows;
using Caliburn.Micro;

namespace MedicalLocator.Mobile.Utils
{
    public class MessageBoxService
    {
        public static MessageBoxResult ShowQuestion(string message)
        {
            MessageBoxResult result = MessageBoxResult.None;
            result = MessageBox.Show(message, "Information", MessageBoxButton.OKCancel);
            return result;
        }

        public static void ShowError(string message)
        {
            Execute.OnUIThread(() => MessageBox.Show(message, "Error", MessageBoxButton.OK));
        }
    }
}