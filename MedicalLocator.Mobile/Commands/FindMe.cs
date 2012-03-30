using System.Device.Location;
using System.Windows;
using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Commands
{
    public class FindMe : ICommand, IHasErrorHandler<GpsDisabledException>, IHasErrorHandler<GpsUnavailableException>
    {
        private readonly IGpsManager _gpsManager;
        private readonly IBingMapHandler _bingMapHandler;

        public FindMe(IGpsManager gpsManager, IBingMapHandler bingMapHandler)
        {
            _gpsManager = gpsManager;
            _bingMapHandler = bingMapHandler;
        }

        public void Execute()
        {
            if (!_gpsManager.IsStarted)
            {
                _gpsManager.StartGps();                                
            }

            if (!_gpsManager.IsTracking)
            {
                _gpsManager.StartTracking(_bingMapHandler);
            }

            GeoCoordinate userLocation = _gpsManager.GetLocation();
            Map map = _bingMapHandler.BingMap;
            map.SetUserLocation(userLocation);
        }

        public void HandleError(GpsDisabledException exception)
        {
            MessageBox.Show("Location services seems to be disabled.");
        }

        public void HandleError(GpsUnavailableException exception)
        {
            MessageBox.Show("Location services are unavailable.");
        }
    }
}