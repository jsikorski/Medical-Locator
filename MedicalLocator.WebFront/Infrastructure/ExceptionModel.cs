namespace MedicalLocator.WebFront.Infrastructure
{
    public class ExceptionModel
    {
        public string NotificationMessage { get; private set; }
        public NotificationType NotificationType { get; private set; }

        public ExceptionModel(string notificationMessage, 
            NotificationType notificationType)
        {
            NotificationType = notificationType;
            NotificationMessage = notificationMessage;
        }
    }
}