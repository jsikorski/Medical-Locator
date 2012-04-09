using System.ServiceModel;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.ServicesReferences;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public abstract class SearchingCommand :
        ICommand,
        IHasErrorHandler<LocationServicesDisabledException>,
        IHasErrorHandler<LocationServicesUnavailableException>,
        IHasErrorHandler<LocationServicesNotAllowedException>,
        IHasErrorHandler<WcfConnectionErrorException>,
        IHasErrorHandler<FaultException<ConnectionFault>>,
        IHasErrorHandler<FaultException<InvalidResponseFault>>,
        IHasErrorHandler<FaultException<RequestDeniedFault>>
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

        public void HandleError(WcfConnectionErrorException exception)
        {
            MessageBoxService.ShowConnectionError();
        }

        public void HandleError(FaultException<ConnectionFault> exception)
        {
            MessageBoxService.ShowError("Server cannot connect with external services. " +
                                        "Please contact with application support.");
        }

        public void HandleError(FaultException<InvalidResponseFault> exception)
        {
            MessageBoxService.ShowError("Server cannot get correct data from server." +
                                        "Please contact with application support.");
        }

        public void HandleError(FaultException<RequestDeniedFault> exception)
        {
            MessageBoxService.ShowError("Server does not have permission to connect ot external services." +
                                        "Please contact with application support.");
        }

        public abstract void Execute();
    }
}