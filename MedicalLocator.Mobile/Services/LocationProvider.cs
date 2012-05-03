using System;
using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Model;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Services
{
    public class LocationProvider : ILocationProvider
    {
        private readonly CurrentContext _currentContext;
        private readonly IGeocodingManager _geocodingManager;
        private readonly ILocationServicesManager _locationServicesManager;

        public LocationProvider(
            CurrentContext currentContext, 
            IGeocodingManager geocodingManager,
            ILocationServicesManager locationServicesManager)
        {
            _currentContext = currentContext;
            _geocodingManager = geocodingManager;
            _locationServicesManager = locationServicesManager;
        }

        public Location GetUserLocation()
        {
            TryStartLocationServices();
            return _locationServicesManager.GetCoordinates().ToLocation();
        }

        private Location GetLocationByAddress(string address)
        {
            return _geocodingManager.ExecuteGeocoding(address);
        }

        public Location GetCenterLocation()
        {
            TryStartLocationServices();
            switch (_currentContext.LastCenterType)
            {
                case CenterType.MyLocation:
                    return GetUserLocation();
                case CenterType.Address:
                    return GetLocationByAddress(_currentContext.LastAddress);
                case CenterType.Coordinates:
                    return new Location { Lat = _currentContext.LastLatitude, Lng = _currentContext.LastLongitude };
            }

            return null;
        }

        private void TryStartLocationServices()
        {
            _locationServicesManager.TryStart();
        }
    }
}