using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.LocationServices
{
    public interface IBingMapHandler
    {
        Map BingMap { get; }
    }
}