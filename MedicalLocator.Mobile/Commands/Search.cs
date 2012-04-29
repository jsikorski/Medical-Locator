using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class Search : SearchingCommand
    {
        private readonly ILocationProvider _locationProvider;
        private readonly CurrentContext _currentContext;
        private readonly ISearchingManager _searchingManager;

        public Search(
            ILocationProvider locationProvider,
            CurrentContext currentContext,
            ISearchingManager searchingManager)
        {
            _locationProvider = locationProvider;
            _currentContext = currentContext;
            _searchingManager = searchingManager;
        }

        public override void Execute()
        {
            Location centerLocation = _locationProvider.GetCenterLocation();
            _searchingManager.ExecuteSearching(centerLocation, _currentContext.LastRange, _currentContext.LastSearchedObjects);
        }
    }
}