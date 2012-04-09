using System.Device.Location;
using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    public static class LocationExtensions
    {
         public static GeoCoordinate ToGeoCoordinate(this Location location)
         {
             return new GeoCoordinate(location.Lat, location.Lng);
         }
    }
}