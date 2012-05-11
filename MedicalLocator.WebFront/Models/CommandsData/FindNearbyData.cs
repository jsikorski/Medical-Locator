using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront.Models.CommandsData
{
    public class FindNearbyData : ICommandData
    {
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public FindNearbyData(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}