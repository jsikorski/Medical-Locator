using System.Device.Location;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    public static class GeoCoordinateExtensions
    {
        public static Location ToLocation(this GeoCoordinate geoCoordinate)
        {
            return new Location { Lat = geoCoordinate.Latitude, Lng = geoCoordinate.Longitude };
        }
    }
}