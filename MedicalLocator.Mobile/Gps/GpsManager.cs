using System;
using System.Device.Location;
using System.Windows;
using MedicalLocator.Mobile.ServicesReferences;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Gps
{
    public class GpsManager : IGpsManager
    {
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

        public void StartGps()
        {
            _geoCoordinateWatcher.StatusChanged += StatusChangedHandler;
            bool startResult = _geoCoordinateWatcher.TryStart(false, new TimeSpan(0, 0, 3));
            if (!startResult)
            {
                HandleGpsStartError();
            }

            _isStarted = true;
        }

        public void StopGps()
        {
            _isStarted = false;
            _geoCoordinateWatcher.StatusChanged -= StatusChangedHandler;
            _geoCoordinateWatcher.Stop();
        }

        public void StartTracking(IBingMapHandler bingMapHandler)
        {
            _bigBingMapHandler = bingMapHandler;
            _geoCoordinateWatcher.PositionChanged += PositionChangedHandler;
            _isTracking = true;
        }

        public void StopTracking()
        {
            _isTracking = false;
            _geoCoordinateWatcher.PositionChanged -= PositionChangedHandler;
            _bigBingMapHandler = null;
        }

        public GeoCoordinate GetLocation()
        {
            return _geoCoordinateWatcher.Position.Location;
        }

        private void StatusChangedHandler(object sender, GeoPositionStatusChangedEventArgs args)
        {
            GeoPositionStatus status = args.Status;
            if (status == GeoPositionStatus.Disabled)
            {
                if (IsGpsDisabled())
                {
                    MessageBox.Show("Gps disabled.");
                    _isStarted = false;
                }
                else
                {
                    MessageBox.Show("Gps unavailable.");
                }
            }
        }

        private void PositionChangedHandler(object sender, GeoPositionChangedEventArgs<GeoCoordinate> args)
        {
            GeoCoordinate location = args.Position.Location;
            Map map = _bigBingMapHandler.BingMap;
            map.SetUserLocation(location);
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