using System.Device.Location;

namespace MedicalLocator.Mobile.Gps
{
    public interface IGpsManager
    {
        bool IsStarted { get; }
        bool IsTracking { get; }

        void TryStartGps();
        void TryStartTracking(IBingMapHandler bingMapHandler);
        void StopGps();

        GeoCoordinate GetLocation();
    }
}