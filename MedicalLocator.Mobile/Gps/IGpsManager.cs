using System.Device.Location;

namespace MedicalLocator.Mobile.Gps
{
    public interface IGpsManager
    {
        void StartGps();
        void StopGps();
        GeoCoordinate GetLocation();
    }
}