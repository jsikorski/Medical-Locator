using System.Collections.Generic;
using System.Device.Location;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile
{
    public class MainPageViewModel
    {
        public IEnumerable<Pushpin> MapPins { get; private set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //MapPins = new List<Pushpin>
            //              {
            //                  new Pushpin() {Location = new GeoCoordinate(50.0, 25.0)},
            //                  new Pushpin() {Location = new GeoCoordinate(45.0, 25.0)}
            //              };
        }

        public void FindMe()
        {
            MessageBox.Show("To do...");
        }

        public void Search()
        {
            MessageBox.Show("To do...");
        }

        public void OpenSettings()
        {
            MessageBox.Show("To do...");
        }

        public void OpenAboutPage()
        {
            MessageBox.Show("To do...");
        }
    }
}

