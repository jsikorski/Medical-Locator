using MedicalLocator.Mobile.Features;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services.LocationServices;

namespace MedicalLocator.Mobile.Commands
{
    public class StopLocationServices : ICommand
    {
        private readonly ILocationServicesManager _locationServicesManager;
        private readonly IBusyScope _busyScope;

        public StopLocationServices(ILocationServicesManager locationServicesManager, MainPageViewModel busyScope)
        {
            _locationServicesManager = locationServicesManager;
            _busyScope = busyScope;
        }

        public void Execute()
        {
            using (new BusyArea(_busyScope))
            {
                _locationServicesManager.Stop();                
            }
        }
    }
}