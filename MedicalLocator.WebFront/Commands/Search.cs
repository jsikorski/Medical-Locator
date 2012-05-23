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

        public object Result { get; private set; }

        public Search(ISearchingManager searchingManager)
        {
            _searchingManager = searchingManager;
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
            Result = new { CenterLocation = centerLocation, GooglePlacesApiResponse = googlePlacesApiResponse };
        }

        private Location GetCenterLocationFromCommandData(SearchData commandData)
        {
            switch (commandData.CenterType)
            {
                case CenterType.MyLocation:
                    return new Location { Lat = commandData.UserLatitude, Lng = commandData.UserLongitude };
                case CenterType.Address:
                    return null;
                case CenterType.Coordinates:
                    return new Location { Lat = commandData.SearchedLatitude.Value, Lng = commandData.SearchedLongitude.Value };
            }

            throw new Exception("Unknown center type.");
        }
    }
}