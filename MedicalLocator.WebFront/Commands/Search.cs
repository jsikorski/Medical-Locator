using System.Collections.Generic;
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
            var centerLocation = new Location {Lat = commandData.UserLatitude, Lng = commandData.UserLongitude};
            var searchedMedicalTypes = commandData.SearchedMedicalTypes;
            var searchingRange = commandData.SearchingRange;
            Result = _searchingManager.GetDataFromGooglePlacesApi(centerLocation, searchedMedicalTypes, (int)searchingRange);
        }
    }
}