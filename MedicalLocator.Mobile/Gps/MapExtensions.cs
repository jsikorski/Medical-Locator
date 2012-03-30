using System.Device.Location;
using Caliburn.Micro;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Gps
{
    public static class MapExtensions
    {
        public static void SetUserLocation(this Map map, GeoCoordinate location)
        {
            Execute.OnUIThread(() =>
                                   {
                                       map.Children.Clear();
                                       map.Children.Add(new Pushpin { Location = location });
                                       map.SetView(LocationRect.CreateLocationRect(location));
                                   });
        }
    }
}