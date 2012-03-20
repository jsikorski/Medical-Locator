using System.Windows;
using Caliburn.Micro;

namespace MedicalLocator.Mobile
{
    public class MainPageViewModel
    {
        private readonly INavigationService _navigationService;

        //public MainPageViewModel(INavigationService navigationService)
        //{
        //    _navigationService = navigationService;
        //}

        public void OpenSettings()
        {
            
            MessageBox.Show("Hello from settings!");
        }

        public void OpenAboutPage()
        {
            MessageBox.Show("Hello from about page!");
        }
    }
}

