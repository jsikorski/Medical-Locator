using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class StartGps : ICommand
    {
        private readonly IGpsManager _gpsManager;

        public StartGps(IGpsManager gpsManager)
        {
            _gpsManager = gpsManager;
        }

        public void Execute()
        {
            _gpsManager.StartGps();
        }
    }
}