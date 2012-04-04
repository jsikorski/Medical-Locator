using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services.LocationServices;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile
{
    [SingleInstance]
    public class MainPageViewModel : Screen, IBusyScope, IBingMapHandler
    {
        private readonly IContainer _container;

        public MainPageViewModel(IContainer container)
        {
            _container = container;
            BingMap = new Map();
        }

        public void FindNearby()
        {
            var command = _container.Resolve<FindNearby>();
            CommandInvoker.Invoke(command);
        }

        public void Search()
        {
            MessageBox.Show("To do...");
        }

        public void OpenSettings()
        {
            var command = _container.Resolve<OpenSettingsPage>();
            CommandInvoker.Execute(command);
        }

        public void OpenAboutPage()
        {
            var command = _container.Resolve<ShowAboutPage>();
            CommandInvoker.Execute(command);
        }

        protected override void OnDeactivate(bool close)
        {
            var command = _container.Resolve<StopLocationServices>();
            CommandInvoker.Invoke(command);
            base.OnDeactivate(close);
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

        #endregion
    }
}

