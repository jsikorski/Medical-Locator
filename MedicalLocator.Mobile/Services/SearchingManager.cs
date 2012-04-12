using System.Collections.Generic;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public class SearchingManager : ISearchingManager
    {
        private readonly IBusyScope _busyScope;
        private readonly IBingMapHelper _bingMapHelper;
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;

        public SearchingManager(
            MainPageViewModel mainPageViewModel,
            IBingMapHelper bingMapHelper,
            IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy)
        {
            _busyScope = mainPageViewModel;
            _bingMapHelper = bingMapHelper;
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
        }

        public void ExecuteSearching(Location centerLocation, int range, IEnumerable<MedicalType> searchedTypes)
        {
            using (new BusyArea(_busyScope))
            {
                GooglePlacesWcfResponse response = GetResponseFromGooglePlacesApi(centerLocation, searchedTypes, range);
                if (response.Status == Status.Zero_Results)
                {
                    throw new NoSearchResultsException();
                }

                _bingMapHelper.SetObjectsUsingGooglePlacesWcfResponse(centerLocation, response);
            }
        }

        private GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(
            Location userLocation, IEnumerable<MedicalType> searchedTypes, int range)
        {
            return _googleMapsInterfaceServiceProxy
                .GetResponseFromGooglePlacesApi(userLocation, searchedTypes, range);
        }
    }
}