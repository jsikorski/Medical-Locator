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
        private readonly ILocationServicesManager _locationServicesManager;

        public LocationProvider(CurrentContext currentContext, ILocationServicesManager locationServicesManager)
        {
            _currentContext = currentContext;
            _locationServicesManager = locationServicesManager;
        }

        public Location GetUserLocation()
        {
            TryStartLocationServices();
            return _locationServicesManager.GetCoordinates().ToLocation();
        }

        public Location GetCenterLocation()
        {
            TryStartLocationServices();
            switch (_currentContext.LastCenterType)
            {
                case CenterType.MyLocation:
                    return GetUserLocation();
                case CenterType.Address:
                // TODO
                    throw new NotImplementedException();
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