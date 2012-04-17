using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.BingMaps
{
    public static class BingMapExtensions
    {
        public static void UpdateView(this Map map, IEnumerable<PushpinViewModel> pushpins)
        {
            Execute.OnUIThread(() =>
                                   {
                                       IEnumerable<GeoCoordinate> pushpinsCoordinates =
                                           pushpins.Select(pushpin => pushpin.Coordinates);
                                       map.SetView(LocationRect.CreateLocationRect(pushpinsCoordinates));
                                   });
        }
    }
}