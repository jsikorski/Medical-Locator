using System;
using System.Web.Helpers;
using System.Web.Mvc;
using MedicalLocator.WebFront.CommandsData;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using System.Linq;
using MedicalLocator.WebFront.Services;

namespace MedicalLocator.WebFront.Commands
{
    public class FindNearby : SearchingCommand, ICommand<FindNearbyData>
    {
        private const int FindNearbyRange = 2500;

        private readonly ISearchingManager _searchingManager;
        private readonly IMedicalTypesProvider _medicalTypesProvider;

        public FindNearby(
            ISearchingManager searchingManager,
            IMedicalTypesProvider medicalTypesProvider)
        {
            _searchingManager = searchingManager;
            _medicalTypesProvider = medicalTypesProvider;
        }

        public object Result { get; private set; }

        public void Execute(FindNearbyData commandData)
        {
            var centerPosition = new Location { Lat = commandData.Latitude, Lng = commandData.Longitude };
            var allMedicalTypes = _medicalTypesProvider.GetAllMedicalTypes();

            GooglePlacesWcfResponse response
                = _searchingManager.GetDataFromGooglePlacesApi(centerPosition, allMedicalTypes, FindNearbyRange);
            Result = response;
        }
    }
}