using MedicalLocator.Mobile.Gps;
using MedicalLocator.Mobile.Infrastructure;

namespace MedicalLocator.Mobile.Commands
{
    public abstract class GpsCommand : ICommand, IHasErrorHandler<GpsDisabledException>, IHasErrorHandler<GpsUnavailableException>
    {
        public void HandleError(GpsDisabledException exception)
        {
            MessageBoxService.ShowError("Location services seems to be disabled.");
        }

        public void HandleError(GpsUnavailableException exception)
        {
            MessageBoxService.ShowError("Location services are unvailiable.");
        }

        public abstract void Execute();
    }
}