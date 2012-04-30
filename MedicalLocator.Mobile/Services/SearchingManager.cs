using System.Collections.Generic;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services
{
    public class SearchingManager : ISearchingManager
    {
        private readonly IBingMapHelper _bingMapHelper;
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;

        public SearchingManager(
            IBingMapHelper bingMapHelper,
            IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy)
        {
            _bingMapHelper = bingMapHelper;
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
        }

        public void ExecuteSearching(Location centerLocation, int range, IEnumerable<MedicalType> searchedTypes)
        {
            _bingMapHelper.ResetMap();
            GooglePlacesWcfResponse response = GetResponseFromGooglePlacesApi(centerLocation, searchedTypes, range);
            _bingMapHelper.SetPushpinsUsingGooglePlacesWcfResponse(centerLocation, response);
        }

        private GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(
            Location userLocation, IEnumerable<MedicalType> searchedTypes, int range)
        {
            GooglePlacesWcfResponse response =
                _googleMapsInterfaceServiceProxy.GetResponseFromGooglePlacesApi(userLocation, searchedTypes, range);
            if (response.Status == Status.Zero_Results)
            {
                throw new NoSearchResultsException();
            }

            return response;
        }
    }
}