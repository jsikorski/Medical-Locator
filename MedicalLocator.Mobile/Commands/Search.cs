using System.Collections.Generic;
using System.Collections.ObjectModel;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Infrastructure;
using System.Linq;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Commands
{
    public class Search : SearchingCommand
    {
        private readonly ILocationProvider _locationProvider;
        private readonly CurrentContext _currentContext;
        private readonly IBusyScope _busyScope;
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;
        private readonly IBingMapsHelper _bingMapsHelper;
        private readonly IBingMapHandler _bingMapHandler;

        public Search(
            ILocationProvider locationProvider,
            CurrentContext currentContext,
            MainPageViewModel mainPageViewModel,
            IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy,
            IBingMapsHelper bingMapsHelper)
        {
            _locationProvider = locationProvider;
            _currentContext = currentContext;
            _busyScope = mainPageViewModel;
            _bingMapHandler = mainPageViewModel;         
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
            _bingMapsHelper = bingMapsHelper;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                Location centerLocation = _locationProvider.GetCenterLocation();
                GooglePlacesWcfResponse response = GetResponseFromGooglePlacesApi(centerLocation);
                _bingMapsHelper.SetObjectsUsingGooglePlacesWcfResponse(_bingMapHandler, centerLocation, response);
            }
        }

        private GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(Location centerLocation)
        {
            IEnumerable<MedicalType> searchedObjects = _currentContext.SelectedSearchedObjects;
            int range = _currentContext.Range;
            return _googleMapsInterfaceServiceProxy
                .GetResponseFromGooglePlacesApi(centerLocation, searchedObjects, range);
        }
    }
}