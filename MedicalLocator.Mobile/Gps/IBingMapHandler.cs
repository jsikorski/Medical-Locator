using System.Collections.Generic;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Gps
{
    public interface IBingMapHandler
    {
        Map BingMap { get; }
    }
}