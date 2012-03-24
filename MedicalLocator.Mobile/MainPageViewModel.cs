using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Windows;
using Caliburn.Micro;
using MedicalLocator.Mobile.Commands;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile
{
    public class MainPageViewModel : Screen, IBusyScope
    {
        private readonly Func<ShowAboutPage> _showAboutPageFactory;
        private readonly Func<TestCommand> _testCommandFactory;
        public IEnumerable<Pushpin> MapPins { get; private set; }

        public MainPageViewModel(
            INavigationService navigationService, 
            Func<ShowAboutPage> showAboutPageFactory, 
            Func<TestCommand> testCommandFactory)
        {
            _showAboutPageFactory = showAboutPageFactory;
            _testCommandFactory = testCommandFactory;
        }

        public void FindMe()
        {
            //MessageBox.Show("To do...");
            ICommand testCommand = _testCommandFactory();
            CommandInvoker.Invoke(testCommand);
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
            ICommand command = _showAboutPageFactory();
            CommandInvoker.Execute(command);
        }

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
    }
}

