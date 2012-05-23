using MedicalLocator.WebFront.GoogleMapsInterfaceReference;

namespace MedicalLocator.WebFront.Services
{
    public interface IGeocodingManager
    {
        Location ExecuteGeocoding(string address);
    }
}