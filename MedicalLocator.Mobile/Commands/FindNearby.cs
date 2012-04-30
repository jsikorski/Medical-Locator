using System.Collections;
using System.Collections.Generic;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Commands
{
    public class FindNearby : SearchingCommand
    {
        private const int NearestRange = 1000;

        private readonly ILocationProvider _locationProvider;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly ISearchingManager _searchingManager;
        private readonly IBusyScope _mainPageViewModel;

        public FindNearby(
            ILocationProvider locationProvider,
            IEnumsValuesProvider enumsValuesProvider,
            ISearchingManager searchingManager,
            MainPageViewModel mainPageViewModel)
        {
            _locationProvider = locationProvider;
            _enumsValuesProvider = enumsValuesProvider;
            _searchingManager = searchingManager;
            _mainPageViewModel = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_mainPageViewModel))
            {
                Location userLocation = _locationProvider.GetUserLocation();
                var allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
                _searchingManager.ExecuteSearching(userLocation, NearestRange, allMedicalTypes);
            }
        }
    }
}