using System.Device.Location;

namespace MedicalLocator.Mobile.Gps
{
    public interface IGpsManager
    {
        bool IsStarted { get; }
        bool IsTracking { get; }

        void StartGps();
        void StopGps();

        void StartTracking(IBingMapHandler bingMapHandler);
        void StopTracking();

        GeoCoordinate GetLocation();
    }
}