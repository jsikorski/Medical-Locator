using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using Caliburn.Micro;
using MedicalLocator.Mobile.ServicesReferences;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    public static class MapExtensions
    {
        public static void SetUserLocation(this Map map, Location userLocation)
        {
            var userCoordinates = GetGeoCoordinateFromLocation(userLocation);
            SetUserPushpin(map, userLocation);
            Execute.OnUIThread(() => map.SetView(LocationRect.CreateLocationRect(userCoordinates)));
        }

        public static void SetUserPushpin(this Map map, Location userLocation)
        {
            var userCoordinates = GetGeoCoordinateFromLocation(userLocation);
            Execute.OnUIThread(() =>
                                   {
                                       map.Children.Clear();
                                       map.Children.Add(new Pushpin { Location = userCoordinates });
                                   });
        }

        public static void SetObjectsPushpinsAndView(this Map map, IEnumerable<Location> objectsLocations)
        {
            Execute.OnUIThread(() =>
                                   {
                                       var coordinatesList = objectsLocations.Select(
                                           location => new GeoCoordinate(location.Lat, location.Lng));
                                       var pushpins = coordinatesList.Select(
                                           coordinates => new Pushpin { Location = coordinates }).ToList();
                                       pushpins.ForEach(pushpin => map.Children.Add(pushpin));
                                       map.SetView(LocationRect.CreateLocationRect(coordinatesList));
                                   });
        }

        private static GeoCoordinate GetGeoCoordinateFromLocation(Location location)
        {
            return new GeoCoordinate(location.Lat, location.Lng);
        }
    }
}