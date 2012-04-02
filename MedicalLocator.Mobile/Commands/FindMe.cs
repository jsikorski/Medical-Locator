using System.Device.Location;
using System.Windows;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.LocationServices;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Commands
{
    public class FindMe : LocationServicesCommand
    {
        private readonly ILocationServicesManager _locationServicesManager;
        private readonly IBingMapHandler _bingMapHandler;
        private readonly IBusyScope _busyScope;

        public FindMe(ILocationServicesManager locationServicesManager, MainPageViewModel mainPageViewModel)
        {
            _locationServicesManager = locationServicesManager;
            _bingMapHandler = mainPageViewModel;
            _busyScope = mainPageViewModel;
        }

        public override void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                _locationServicesManager.TryStart();
                _locationServicesManager.TryStartTracking(_bingMapHandler);

                GeoCoordinate userLocation = _locationServicesManager.GetLocation();
                Map map = _bingMapHandler.BingMap;
                map.SetUserLocation(userLocation);
            }
        }
    }
}