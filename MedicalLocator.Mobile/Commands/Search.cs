using MedicalLocator.Mobile.Services;

namespace MedicalLocator.Mobile.Commands
{
    public class Search : LocationServicesCommand
    {
        private readonly ILocationProvider _locationProvider;

        public Search(ILocationProvider locationProvider)
        {
            _locationProvider = locationProvider;
        }

        public override void Execute()
        {
        }
    }
}