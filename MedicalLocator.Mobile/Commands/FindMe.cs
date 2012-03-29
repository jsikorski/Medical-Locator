using System.Device.Location;
using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Commands
{
    public class FindMe : ICommand
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
            _gpsManager.StartGps();

            GeoCoordinate geoCoordinate = _gpsManager.GetLocation();
            Map map = _bingMapHandler.BingMap;
            
            map.Children.Clear();
            map.Children.Add(new Pushpin { Location = geoCoordinate });
            map.SetView(LocationRect.CreateLocationRect(geoCoordinate));
        }
    }
}