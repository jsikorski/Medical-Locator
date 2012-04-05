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
            var userCoordinates = new GeoCoordinate(userLocation.Lat, userLocation.Lng);
            SetUserPushpin(map, userCoordinates);
            Execute.OnUIThread(() => map.SetView(LocationRect.CreateLocationRect(userCoordinates)));
        }

        public static void SetUserPushpin(this Map map, GeoCoordinate location)
        {
            Execute.OnUIThread(() =>
                                   {
                                       map.Children.Clear();
                                       map.Children.Add(new Pushpin { Location = location });
                                   });
        }

        public static void SetObjectsPushpinsAndView(this Map map, IEnumerable<GeoCoordinate> objectsCoordinates)
        {
            Execute.OnUIThread(() =>
                                   {
                                       var coordinatesList = objectsCoordinates.ToList();

                                       var pushpins = coordinatesList.Select(coordinate => new Pushpin { Location = coordinate }).ToList();
                                       pushpins.ForEach(pushpin => map.Children.Add(pushpin));
                                       map.SetView(LocationRect.CreateLocationRect(coordinatesList));
                                   });
        }
    }
}