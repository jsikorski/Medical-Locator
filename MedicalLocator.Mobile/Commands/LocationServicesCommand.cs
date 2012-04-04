using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public abstract class LocationServicesCommand :
        ICommand,
        IHasErrorHandler<LocationServicesDisabledException>,
        IHasErrorHandler<LocationServicesUnavailableException>,
        IHasErrorHandler<LocationServicesNotAllowedException>
    {
        public void HandleError(LocationServicesDisabledException exception)
        {
            MessageBoxService.ShowError("Location services seems to be disabled.");
        }

        public void HandleError(LocationServicesUnavailableException exception)
        {
            MessageBoxService.ShowError("Location services are unvailiable.");
        }

        public void HandleError(LocationServicesNotAllowedException exception)
        {
            MessageBoxService.ShowError("Location services are not allowed. Check if " +
                                        "location services are enabled in settings menu.");
        }

        public abstract void Execute();
    }
}