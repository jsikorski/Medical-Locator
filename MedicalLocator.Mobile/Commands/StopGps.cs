using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public class StopGps : ICommand
    {
        private readonly IGpsManager _gpsManager;
        private readonly IBusyScope _busyScope;

        public StopGps(IGpsManager gpsManager, MainPageViewModel busyScope)
        {
            _gpsManager = gpsManager;
            _busyScope = busyScope;
        }

        public void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                _gpsManager.StopGps();                
            }
        }
    }
}