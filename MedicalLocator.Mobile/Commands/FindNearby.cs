using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.ServiceModel;
using System.Windows;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;
using Microsoft.Phone.Controls.Maps;
using System.Linq;

namespace MedicalLocator.Mobile.Commands
{
    public class FindNearby : LocationServicesCommand, IHasErrorHandler<WcfConnectionErrorException>
    {
        private const int NearestRange = 1000;

        private readonly ILocationProvider _locationProvider;
        private readonly IBingMapHandler _bingMapHandler;
        private readonly GoogleMapsInterfaceServiceClient _googleMapsInterfaceServiceClient;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly CurrentContext _currentContext;
        private readonly IBusyScope _busyScope;

        public FindNearby(
            ILocationProvider locationProvider,
            MainPageViewModel mainPageViewModel,
            GoogleMapsInterfaceServiceClient googleMapsInterfaceServiceClient,
            IEnumsValuesProvider enumsValuesProvider,
            CurrentContext currentContext)
        {
            _locationProvider = locationProvider;
            _bingMapHandler = mainPageViewModel;
            _googleMapsInterfaceServiceClient = googleMapsInterfaceServiceClient;
            _enumsValuesProvider = enumsValuesProvider;
            _currentContext = currentContext;
            _busyScope = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                Location userCoordinates = _locationProvider.GetUserLocation();
                GooglePlacesApiResponse response = GetDataFromGooglePlacesApi(userCoordinates);
                IEnumerable<GeoCoordinate> objectsCoordinates = GetObjectsCoordinatesFromResponse(response);
                SetDataOnMap(userCoordinates, objectsCoordinates);
            }
        }

        private GooglePlacesApiResponse GetDataFromGooglePlacesApi(Location userLocation)
        {
            bool isGpsUsed = _currentContext.AreLocationServicesAllowed;
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            var searchedObjects = new ObservableCollection<MedicalType>(allMedicalTypes);

            var request = new GooglePlacesApiRequest
                              {
                                  IsGpsUsed = isGpsUsed,
                                  Location = userLocation,
                                  MedicalTypes = searchedObjects,
                                  Radius = NearestRange
                              };

            return _googleMapsInterfaceServiceClient.SendGooglePlacesApiRequest(request);
        }

        private IEnumerable<GeoCoordinate> GetObjectsCoordinatesFromResponse(GooglePlacesApiResponse googlePlacesApiResponse)
        {
            return googlePlacesApiResponse.Results.Select(
                result => new GeoCoordinate(result.Geometry.Location.Lat, result.Geometry.Location.Lng));
        }

        private void SetDataOnMap(Location userLocation, IEnumerable<GeoCoordinate> objectsCoordinates)
        {
            Map map = _bingMapHandler.BingMap;
            map.SetUserLocation(userLocation);
            map.SetObjectsPushpinsAndView(objectsCoordinates);
        }

        public void HandleError(WcfConnectionErrorException exception)
        {
            MessageBoxService.ShowConnectionError();
        }
    }
}