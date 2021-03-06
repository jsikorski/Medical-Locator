﻿using System.ServiceModel;
using MedicalLocator.Mobile.Exceptions;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Services.LocationServices;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Utils;

namespace MedicalLocator.Mobile.Commands
{
    public abstract class SearchingCommand :
        ICommand,
        IHasErrorHandler<LocationServicesDisabledException>,
        IHasErrorHandler<LocationServicesUnavailableException>,
        IHasErrorHandler<LocationServicesNotAllowedException>,
        IHasErrorHandler<EndpointNotFoundException>,
        IHasErrorHandler<FaultException<ConnectionFault>>,
        IHasErrorHandler<FaultException<InvalidResponseFault>>,
        IHasErrorHandler<FaultException<RequestDeniedFault>>,
        IHasErrorHandler<FaultException<IncorectCharsInAddressFault>>,
        IHasErrorHandler<NoSearchResultsException>,
        IHasErrorHandler<NoGeocodingResultsException>
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

        public void HandleError(EndpointNotFoundException exception)
        {
            MessageBoxService.ShowConnectionError();
        }

        public void HandleError(FaultException<ConnectionFault> exception)
        {
            MessageBoxService.ShowInternalError("Server cannot connect with external services.");
        }

        public void HandleError(FaultException<InvalidResponseFault> exception)
        {
            MessageBoxService.ShowInternalError("Server cannot get correct data from server.");
        }

        public void HandleError(FaultException<RequestDeniedFault> exception)
        {
            MessageBoxService.ShowInternalError("Server does not have permission to connect ot external services.");
        }

        public void HandleError(FaultException<IncorectCharsInAddressFault> exception)
        {
            MessageBoxService.ShowInternalError("Incorect characters in address.");
        }

        public void HandleError(NoSearchResultsException exception)
        {
            MessageBoxService.ShowInformation("No results was found.");
        }

        public void HandleError(NoGeocodingResultsException exception)
        {
            MessageBoxService.ShowInformation("Invalid address.");
        }

        public abstract void Execute();
    }
}