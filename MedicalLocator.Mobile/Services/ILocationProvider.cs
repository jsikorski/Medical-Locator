using MedicalLocator.Mobile.ServicesReferences;

namespace MedicalLocator.Mobile.Services
{
    public interface ILocationProvider
    {
        Location GetUserLocation();
        Location GetCenterLocation();
    }
}