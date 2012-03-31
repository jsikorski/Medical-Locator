using System.Device.Location;
using System.Windows;
using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Commands
{
    public class FindMe : GpsCommand
    {
        private readonly IGpsManager _gpsManager;
        private readonly IBingMapHandler _bingMapHandler;
        private readonly IBusyScope _busyScope;

        public FindMe(IGpsManager gpsManager, MainPageViewModel mainPageViewModel)
        {
            _gpsManager = gpsManager;
            _bingMapHandler = mainPageViewModel;
            _busyScope = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                _gpsManager.TryStartGps();
                _gpsManager.TryStartTracking(_bingMapHandler);

                GeoCoordinate userLocation = _gpsManager.GetLocation();
                Map map = _bingMapHandler.BingMap;
                map.SetUserLocation(userLocation);
            }
        }
    }
}