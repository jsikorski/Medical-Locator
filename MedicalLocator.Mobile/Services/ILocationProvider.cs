using MedicalLocator.Mobile.GoogleMapsInterfaceReference;

namespace MedicalLocator.Mobile.Services
{
    public interface ILocationProvider
    {
        Location GetUserLocation();
        Location GetCenterLocation();
    }
}