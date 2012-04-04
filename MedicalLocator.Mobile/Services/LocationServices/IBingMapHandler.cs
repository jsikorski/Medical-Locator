using Microsoft.Phone.Controls.Maps;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    public interface IBingMapHandler
    {
        Map BingMap { get; }
    }
}