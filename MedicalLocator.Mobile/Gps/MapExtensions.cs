using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Gps
{
    public static class MapExtensions
    {
         public static void SetUserLocation(this Map map, GeoCoordinate location)
         {
             map.Children.Clear();
             map.Children.Add(new Pushpin { Location = location });
             map.SetView(LocationRect.CreateLocationRect(location));
         }
    }
}