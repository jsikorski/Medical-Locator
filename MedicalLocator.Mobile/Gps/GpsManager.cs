using System.Device.Location;

namespace MedicalLocator.Mobile.Gps
{
    public class GpsManager : IGpsManager
    {
        private readonly GeoCoordinateWatcher _geoCoordinateWatcher;

        public GpsManager(GeoCoordinateWatcher geoCoordinateWatcher)
        {
            _geoCoordinateWatcher = geoCoordinateWatcher;
        }

        public void StartGps()
        {
            _geoCoordinateWatcher.Start();
        }

        public void StopGps()
        {
            _geoCoordinateWatcher.Stop();
        }

        public GeoCoordinate GetLocation()
        {
            return _geoCoordinateWatcher.Position.Location;
        }
    }
}