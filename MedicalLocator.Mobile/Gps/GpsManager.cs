using System;
using System.Device.Location;
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
            _geoCoordinateWatcher.Start();
            _isStarted = true;
        }

        public void StopGps()
        {
            _isStarted = false;  
            _geoCoordinateWatcher.Stop();
        }

        public void StartTracking(IBingMapHandler bingMapHandler)
        {
            _bigBingMapHandler = bingMapHandler;
            _geoCoordinateWatcher.PositionChanged += PositionChangedHandler;
            _isTracking = true;
        }
        public void StopStracking()
        {
            _isTracking = false;
            _geoCoordinateWatcher.PositionChanged -= PositionChangedHandler;
            _bigBingMapHandler = null;
        }

        public GeoCoordinate GetLocation()
        {
            return _geoCoordinateWatcher.Position.Location;
        }

        private void PositionChangedHandler(object sender, GeoPositionChangedEventArgs<GeoCoordinate> geoPositionChangedEventArgs)
        {
            GeoCoordinate location = geoPositionChangedEventArgs.Position.Location;
            Map map = _bigBingMapHandler.BingMap;
            map.SetUserLocation(location);
        }
    }
}