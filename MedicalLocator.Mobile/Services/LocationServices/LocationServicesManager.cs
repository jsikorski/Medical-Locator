using System;
using System.Device.Location;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    [SingleInstance]
    public class LocationServicesManager : ILocationServicesManager
    {
        private readonly TimeSpan _gpsTryStartTimeSpan = new TimeSpan(0, 0, 3);

        private readonly GeoCoordinateWatcher _geoCoordinateWatcher;
        private readonly CurrentContext _currentContext;

        public LocationServicesManager(GeoCoordinateWatcher geoCoordinateWatcher, CurrentContext currentContext)
        {
            _geoCoordinateWatcher = geoCoordinateWatcher;
            _currentContext = currentContext;
        }

        public bool IsStarted { get; private set; }

        public void TryStart()
        {
            if (!_currentContext.AreLocationServicesAllowed)
            {
                throw new LocationServicesNotAllowedException();
            }

            if (!IsStarted)
            {
                Start();
            }
        }

        public void Stop()
        {
            IsStarted = false;
            _geoCoordinateWatcher.Stop();
        }

        public GeoCoordinate GetCoordinates()
        {
            return _geoCoordinateWatcher.Position.Location;
        }

        private void Start()
        {
            bool started = _geoCoordinateWatcher.TryStart(false, _gpsTryStartTimeSpan);
            if (!started)
            {
                HandleGpsStartError();
            }

            IsStarted = true;
        }

        private void HandleGpsStartError()
        {
            if (IsGpsDisabled())
            {
                throw new LocationServicesDisabledException();
            }

            throw new LocationServicesUnavailableException();
        }

        private bool IsGpsDisabled()
        {
            return _geoCoordinateWatcher.Permission == GeoPositionPermission.Denied;
        }
    }
}