using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Caliburn.Micro;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Messages;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Commands
{
    public class BeginSearch : ICommand
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public BeginSearch(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
        }

        public void Execute()
        {
            _navigationService.GoBack();
            _eventAggregator.Publish(new ShouldSearchMessage());
        }
    }
}