using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.ServiceModel;
using System.Windows;
using MedicalLocator.Mobile.BingMaps;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;
using Microsoft.Phone.Controls.Maps;
using System.Linq;

namespace MedicalLocator.Mobile.Commands
{
    public class FindNearby : SearchingCommand
    {
        private const int NearestRange = 1000;

        private readonly ILocationProvider _locationProvider;
        private readonly IBingMapHandler _bingMapHandler;
        private readonly IEnumsValuesProvider _enumsValuesProvider;
        private readonly IGoogleMapsInterfaceServiceProxy _googleMapsInterfaceServiceProxy;
        private readonly IBingMapsHelper _bingMapsHelper;
        private readonly IBusyScope _busyScope;

        public FindNearby(
            ILocationProvider locationProvider,
            MainPageViewModel mainPageViewModel,
            IEnumsValuesProvider enumsValuesProvider,
            IGoogleMapsInterfaceServiceProxy googleMapsInterfaceServiceProxy, 
            BingMapsHelper bingMapsHelper)
        {
            _locationProvider = locationProvider;
            _bingMapHandler = mainPageViewModel;
            _enumsValuesProvider = enumsValuesProvider;
            _googleMapsInterfaceServiceProxy = googleMapsInterfaceServiceProxy;
            _bingMapsHelper = bingMapsHelper;
            _busyScope = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                Location userLocation = _locationProvider.GetUserLocation();
                GooglePlacesWcfResponse response = GetResponseFromGooglePlacesApi(userLocation);
                _bingMapsHelper.SetObjectsUsingGooglePlacesWcfResponse(_bingMapHandler, userLocation, response);
            }
        }

        private GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(Location userLocation)
        {
            IEnumerable<MedicalType> allMedicalTypes = _enumsValuesProvider.GetAllMedicalTypes();
            return _googleMapsInterfaceServiceProxy
                .GetResponseFromGooglePlacesApi(userLocation, allMedicalTypes, NearestRange);
        }
    }
}