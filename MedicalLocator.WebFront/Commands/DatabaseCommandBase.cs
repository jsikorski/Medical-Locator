using System.ServiceModel;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.Infrastructure;

namespace MedicalLocator.WebFront.Commands
{
    public abstract class DatabaseCommandBase :
        IHandleException<InvalidLoginException>,
        IHandleException<InvalidRegisterException>,
        IHandleException<InvalidSaveSettingsException>,
        IHandleException<FaultException<ExceptionDetail>>
    {
        public ExceptionModel HandleException(InvalidLoginException exception)
        {
            return new ExceptionModel(exception.Error, NotificationType.Info);
        }

        public ExceptionModel HandleException(InvalidRegisterException exception)
        {
            return new ExceptionModel(exception.Error, NotificationType.Info);
        }

        public ExceptionModel HandleException(InvalidSaveSettingsException exception)
        {
            return new ExceptionModel(exception.Error, NotificationType.Info);
        }

        public ExceptionModel HandleException(FaultException<ExceptionDetail> exception)
        {
            return new ExceptionModel(exception.Message, NotificationType.Error);
        }
    }
}