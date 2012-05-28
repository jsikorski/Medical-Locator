using System;
using System.Collections.Generic;
using System.Diagnostics;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;
using MedicalLocator.WebFront.Services;

namespace MedicalLocator.WebFront.Commands
{
    public class Search : SearchingCommandBase, ICommand<SearchData>
    {
        private readonly ISearchingManager _searchingManager;
        private readonly IGeocodingManager _geocodingManager;
        private readonly IDatabaseManager _databaseManager;

        public object Result { get; private set; }

        public Search(ISearchingManager searchingManager, IGeocodingManager geocodingManager, IDatabaseManager databaseManager)
        {
            _searchingManager = searchingManager;
            _geocodingManager = geocodingManager;
            _databaseManager = databaseManager;
        }

        public void Execute(SearchData commandData)
        {
            Location centerLocation = GetCenterLocationFromCommandData(commandData);
            IEnumerable<MedicalType> searchedMedicalTypes = commandData.SearchedMedicalTypes;
            int searchingRange = commandData.SearchingRange;
            GooglePlacesWcfResponse googlePlacesApiResponse =
                _searchingManager.GetDataFromGooglePlacesApi(centerLocation,
                                                             searchedMedicalTypes,
                                                             searchingRange);

            _databaseManager.TrySaveSettings();

            Result = GetSearchingCommandResult(centerLocation, googlePlacesApiResponse);
        }

        private Location GetCenterLocationFromCommandData(SearchData commandData)
        {
            switch (commandData.CenterType)
            {
                case CenterType.MyLocation:
                    return new Location { Lat = commandData.UserLatitude, Lng = commandData.UserLongitude };
                case CenterType.Address:
                    return _geocodingManager.ExecuteGeocoding(commandData.SearchedAddress);
                case CenterType.Coordinates:
                    return new Location { Lat = commandData.SearchedLatitude.Value, Lng = commandData.SearchedLongitude.Value };
            }

            throw new Exception("Unknown center type.");
        }
    }
}