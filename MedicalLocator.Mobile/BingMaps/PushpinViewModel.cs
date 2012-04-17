using System.Device.Location;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.BingMaps
{
    public class PushpinViewModel
    {
        public string Name { get; private set; }
        public string Vicinity { get; private set; }
        public GeoCoordinate Coordinates { get; private set; }
        public PushpinType PushpinType { get; private set; }

        public PushpinViewModel(string name, string vicinity, GeoCoordinate coordinates, PushpinType pushpinType)
        {
            Coordinates = coordinates;
            PushpinType = pushpinType;
            Name = name;
            Vicinity = vicinity;
        }
    }
}