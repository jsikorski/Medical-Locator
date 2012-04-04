using System.Device.Location;

namespace MedicalLocator.Mobile.Services.LocationServices
{
    public interface ILocationServicesManager
    {
        bool IsStarted { get; }
        bool IsTracking { get; }

        void TryStart();
        void Stop();

        GeoCoordinate GetCoordinates();
    }
}