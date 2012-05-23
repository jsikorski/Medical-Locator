using System;
using System.Web.Helpers;
using System.Web.Mvc;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using System.Linq;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Services;

namespace MedicalLocator.WebFront.Commands
{
    public class FindNearby : SearchingCommandBase, ICommand<FindNearbyData>
    {
        private const int FindNearbyRange = 1000;

        private readonly ISearchingManager _searchingManager;
        private readonly IEnumsValuesProvider _enumsValuesProvider;

        public FindNearby(
            ISearchingManager searchingManager,
            IEnumsValuesProvider enumsValuesProvider)
        {
            _searchingManager = searchingManager;
            _enumsValuesProvider = enumsValuesProvider;
        }

        public object Result { get; private set; }

        public void Execute(FindNearbyData commandData)
        {
            var centerPosition = new Location { Lat = commandData.Latitude, Lng = commandData.Longitude };
            var allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();

            GooglePlacesWcfResponse response
                = _searchingManager.GetDataFromGooglePlacesApi(centerPosition, allMedicalTypes, FindNearbyRange);
            Result = GetSearchingCommandResult(centerPosition, response);
        }
    }
}