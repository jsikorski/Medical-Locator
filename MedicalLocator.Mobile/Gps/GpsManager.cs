using System;
using System.Device.Location;
using System.Windows;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Gps
{
    public class GpsManager : IGpsManager
    {
        private readonly TimeSpan _gpsTryStartTimeSpan = new TimeSpan(0, 0, 3);

        private IBingMapHandler _bigBingMapHandler;
        private readonly GeoCoordinateWatcher _geoCoordinateWatcher;

        public GpsManager(GeoCoordinateWatcher geoCoordinateWatcher)
        {
            _geoCoordinateWatcher = geoCoordinateWatcher;
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

        public void TryStartGps()
        {
            if (!IsStarted)
            {
                StartGps();
            }
        }

        public void StopGps()
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

        public GeoCoordinate GetLocation()
        {
            return _geoCoordinateWatcher.Position.Location;
        }

        private void StartGps()
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
                throw new GpsDisabledException();
            }

            throw new GpsUnavailableException();
        }

        private bool IsGpsDisabled()
        {
            return _geoCoordinateWatcher.Permission == GeoPositionPermission.Denied;
        }
    }
}