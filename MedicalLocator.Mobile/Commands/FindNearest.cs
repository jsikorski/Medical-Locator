using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.ServiceModel;
using System.Windows;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.LocationServices;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;
using Microsoft.Phone.Controls.Maps;
using System.Linq;

namespace MedicalLocator.Mobile.Commands
{
    public class FindNearest : LocationServicesCommand, IHasErrorHandler<Exception>
    {
        private const int NearestRange = 1000;

        private readonly ILocationServicesManager _locationServicesManager;
        private readonly IBingMapHandler _bingMapHandler;
        private readonly GoogleMapsInterfaceServiceClient _googleMapsInterfaceServiceClient;
        private readonly CurrentContext _currentContext;
        private readonly IBusyScope _busyScope;

        public FindNearest(
            ILocationServicesManager locationServicesManager,
            MainPageViewModel mainPageViewModel,
            GoogleMapsInterfaceServiceClient googleMapsInterfaceServiceClient,
            CurrentContext currentContext)
        {
            _locationServicesManager = locationServicesManager;
            _bingMapHandler = mainPageViewModel;
            _googleMapsInterfaceServiceClient = googleMapsInterfaceServiceClient;
            _currentContext = currentContext;
            _busyScope = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                StartLocationServices();
                GeoCoordinate userCoordinate = _locationServicesManager.GetGeoCoordinate();
                GooglePlacesApiResponse response = GetDataFromGooglePlacesApi(userCoordinate);
                SetDataOnBingMaps(userCoordinate, response);
            }
        }

        private void StartLocationServices()
        {
            _locationServicesManager.TryStart();
        }

        private GooglePlacesApiResponse GetDataFromGooglePlacesApi(GeoCoordinate userCoordinate)
        {
            var userLocation = new Location { Lat = userCoordinate.Latitude, Lng = userCoordinate.Longitude };
            var request = new GooglePlacesApiRequest
                              {
                                  IsGpsUsed = _currentContext.AreLocationServicesAllowed,
                                  Location = userLocation,
                                  MedicalTypes =
                                      new ObservableCollection<MedicalType> { MedicalType.Doctor, MedicalType.Dentist },
                                  Radius = NearestRange
                              };

            return _googleMapsInterfaceServiceClient.SendGooglePlacesApiRequest(request);
        }

        private void SetDataOnBingMaps(GeoCoordinate userCoordinate, GooglePlacesApiResponse googlePlacesApiResponse)
        {
            Map map = _bingMapHandler.BingMap;
            map.SetUserLocation(userCoordinate);

            IEnumerable<GeoCoordinate> pointsCoordinates =
                googlePlacesApiResponse.Results.Select(
                    result => new GeoCoordinate(result.Geometry.Location.Lat, result.Geometry.Location.Lng));
            Caliburn.Micro.Execute.OnUIThread(() =>
            {
                var pushpins = pointsCoordinates.Select(coordinate => new Pushpin { Location = coordinate }).ToList();
                pushpins.ForEach(pushpin => map.Children.Add(pushpin));
                map.SetView(LocationRect.CreateLocationRect(pointsCoordinates));
            });
        }

        public void HandleError(Exception exception)
        {
            MessageBoxService.ShowError("Cannot connect.");
        }
    }
}