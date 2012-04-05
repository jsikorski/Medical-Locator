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
    public class FindNearby : LocationServicesCommand
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
                Location userLocation = _locationProvider.GetUserLocation();
                GooglePlacesApiResponse response = GetDataFromGooglePlacesApi(userLocation);
                IEnumerable<Location> objectsLocations = GetObjectsLocationsFromResponse(response);
                SetDataOnMap(userLocation, objectsLocations);
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

        private IEnumerable<Location> GetObjectsLocationsFromResponse(GooglePlacesApiResponse googlePlacesApiResponse)
        {
            return googlePlacesApiResponse.Results.Select(result => result.Geometry.Location);
        }

        private void SetDataOnMap(Location userLocation, IEnumerable<Location> objectsLocations)
        {
            Map map = _bingMapHandler.BingMap;
            map.SetUserLocation(userLocation);
            map.SetObjectsPushpinsAndView(objectsLocations);
        }
    }
}