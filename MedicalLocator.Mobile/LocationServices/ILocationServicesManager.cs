using System.Device.Location;

namespace MedicalLocator.Mobile.LocationServices
{
    public interface ILocationServicesManager
    {
        bool IsStarted { get; }
        bool IsTracking { get; }

        void TryStart();
        void TryStartTracking(IBingMapHandler bingMapHandler);
        void Stop();

        GeoCoordinate GetLocation();
    }
}