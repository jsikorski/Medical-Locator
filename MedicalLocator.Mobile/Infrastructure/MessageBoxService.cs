using System.Windows;
using Caliburn.Micro;

namespace MedicalLocator.Mobile.Infrastructure
{
    public class MessageBoxService
    {
        public static void ShowError(string message)
        {
            Execute.OnUIThread(() => MessageBox.Show(message, "Error", MessageBoxButton.OK));
        }
    }
}