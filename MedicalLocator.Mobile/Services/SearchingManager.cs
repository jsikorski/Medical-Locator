using System.Collections.Generic;
using Caliburn.Micro;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Services
{
    public class SearchingManager : ISearchingManager
    {
        private readonly IBusyScope _busyScope;
        private readonly IBingMapHelper _bingMapHelper;
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;
        private readonly INavigationService _navigationService;

        public SearchingManager(
            MainPageViewModel mainPageViewModel,
            IBingMapHelper bingMapHelper,
            IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy, 
            INavigationService navigationService)
        {
            _busyScope = mainPageViewModel;
            _bingMapHelper = bingMapHelper;
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
            _navigationService = navigationService;
        }

        public void ExecuteSearching(Location centerLocation, int range, IEnumerable<MedicalType> searchedTypes)
        {
            using (new BusyArea(_busyScope))
            {
                GoToMapPage();
                GooglePlacesWcfResponse response = GetResponseFromGooglePlacesApi(centerLocation, searchedTypes, range);
                _bingMapHelper.SetObjectsUsingGooglePlacesWcfResponse(centerLocation, response);
            }
        }

        private void GoToMapPage()
        {
            Execute.OnUIThread(() => _navigationService.UriFor<MainPageViewModel>().Navigate());            
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