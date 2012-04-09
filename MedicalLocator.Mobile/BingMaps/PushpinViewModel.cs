using System.Device.Location;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.BingMaps
{
    public class PushpinViewModel
    {
        public PushpinType PushpinType { get; private set; }
        public GeoCoordinate Coordinates { get; private set; }

        public PushpinViewModel(GeoCoordinate coordinates, PushpinType pushpinType)
        {
            Coordinates = coordinates;
            PushpinType = pushpinType;
        }
    }
}