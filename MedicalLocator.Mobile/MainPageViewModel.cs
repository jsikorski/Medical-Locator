using System.Collections.Generic;
using System.Device.Location;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile
{
    public class MainPageViewModel : Screen, IBusyScope, IBingMapHandler
    {
        private readonly IContainer _container;

        public MainPageViewModel(IContainer container)
        {
            _container = container;
            BingMap = new Map();
        }

        public void FindMe()
        {
            var command = _container.Resolve<FindMe>();
            CommandInvoker.Execute(command);
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
            var command = _container.Resolve<ShowAboutPage>();
            CommandInvoker.Execute(command);
        }

        protected override void OnViewLoaded(object view)
        {
            var command = _container.Resolve<StartGps>();
            CommandInvoker.Invoke(command);
        }

        #region Implementation of IBusyScope

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        #endregion

        #region Implementation of IBingMapHandler

        public Map BingMap { get; private set; }

        public IEnumerable<Pushpin> LocationsPins { get; set; }

        #endregion
    }
}

