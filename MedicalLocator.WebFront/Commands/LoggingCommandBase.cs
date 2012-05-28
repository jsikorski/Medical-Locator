using System.ServiceModel;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront.Commands
{
    public abstract class LoggingCommandBase :
        IHandleException<NoSearchResultsException>,
        IHandleException<NoGeocodingResultsException>,
        IHandleException<EndpointNotFoundException>,
        IHandleException<FaultException<ConnectionFault>>,
        IHandleException<FaultException<InvalidResponseFault>>,
        IHandleException<FaultException<RequestDeniedFault>>
    {
        public ExceptionModel HandleException(NoSearchResultsException exception)
        {
            return new ExceptionModel("No results were found.", NotificationType.Info);
        }

        public ExceptionModel HandleException(NoGeocodingResultsException exception)
        {
            return new ExceptionModel("Cannot find requested address.", NotificationType.Info);
        }

        public ExceptionModel HandleException(EndpointNotFoundException exception)
        {
            return new ExceptionModel("Cannot connect with server.", NotificationType.Error);
        }

        public ExceptionModel HandleException(FaultException<ConnectionFault> exception)
        {
            return new ExceptionModel("Server cannot connect with external services", NotificationType.Error);
        }

        public ExceptionModel HandleException(FaultException<InvalidResponseFault> exception)
        {
            return new ExceptionModel("Server cannot get correct data from server.", NotificationType.Error);
        }

        public ExceptionModel HandleException(FaultException<RequestDeniedFault> exception)
        {
            return new ExceptionModel("Server does not have permission to connect ot external services", NotificationType.Error);
        }
    }
}