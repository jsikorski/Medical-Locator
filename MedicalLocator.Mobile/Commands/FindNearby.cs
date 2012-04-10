using System.Collections.Generic;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Commands
{
    public class FindNearby : SearchingCommand
    {
        private const int NearestRange = 1000;

        private readonly ILocationProvider _locationProvider;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly ISearchingManager _searchingManager;

        public FindNearby(
            ILocationProvider locationProvider,
            IEnumsValuesProvider enumsValuesProvider,
            ISearchingManager searchingManager)
        {
            _locationProvider = locationProvider;
            _enumsValuesProvider = enumsValuesProvider;
            _searchingManager = searchingManager;
        }

        public override void Execute()
        {
            Location userLocation = _locationProvider.GetUserLocation();
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            _searchingManager.ExecuteSearching(userLocation, NearestRange, allMedicalTypes);
        }
    }
}