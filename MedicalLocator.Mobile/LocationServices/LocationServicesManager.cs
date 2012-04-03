using System;
using System.Device.Location;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.LocationServices
{
    [SingleInstance]
    public class LocationServicesManager : ILocationServicesManager
    {
        private readonly TimeSpan _gpsTryStartTimeSpan = new TimeSpan(0, 0, 3);

        private IBingMapHandler _bigBingMapHandler;
        private readonly GeoCoordinateWatcher _geoCoordinateWatcher;
        private readonly CurrentContext _currentContext;

        public LocationServicesManager(GeoCoordinateWatcher geoCoordinateWatcher, CurrentContext currentContext)
        {
            _geoCoordinateWatcher = geoCoordinateWatcher;
            _currentContext = currentContext;
        }

        private bool _isStarted;
        public bool IsStarted
        {
            get { return _isStarted; }
        }

        private bool _isTracking;
        public bool IsTracking
        {
            get { return _isTracking; }
        }

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
            if (IsTracking)
            {
                StopTracking();
            }

            _isStarted = false;
            _geoCoordinateWatcher.Stop();
        }

        public void TryStartTracking(IBingMapHandler bingMapHandler)
        {
            if (!IsTracking)
            {
                StartTracking(bingMapHandler);
            }
        }

        public GeoCoordinate GetGeoCoordinate()
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

            _isStarted = true;
        }

        private void StartTracking(IBingMapHandler bingMapHandler)
        {
            _bigBingMapHandler = bingMapHandler;
            _geoCoordinateWatcher.PositionChanged += PositionChangedHandler;
            _isTracking = true;
        }

        private void StopTracking()
        {
            _isTracking = false;
            _geoCoordinateWatcher.PositionChanged -= PositionChangedHandler;
            _bigBingMapHandler = null;
        }

        private void PositionChangedHandler(object sender, GeoPositionChangedEventArgs<GeoCoordinate> args)
        {
            GeoCoordinate location = args.Position.Location;
            Map map = _bigBingMapHandler.BingMap;
            map.SetUserPushpin(location);
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