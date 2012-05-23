var notificationsManager = new NotificationsManager();

function NotificationsManager() {
    var notificationTypeHeader = "X-Notification-Type";
    var notificationMessageHeader = "X-Notification-Message";

    var getNotifierFunction = function (notificationType) {
        switch (notificationType) {
            case "Success":
                return Notifier.success;
            case "Info":
                return Notifier.info;
            case "Warning":
                return Notifier.warning;
            case "Error":
                return Notifier.error;
        }

        throw "Invalid notification type.";
    };

    var showNotification = function (notificationType, notificationMessage) {
        var notifierFuntion = getNotifierFunction(notificationType);
        notifierFuntion(notificationMessage);
    };

    this.showSuccess = function (notificationMessage) {
        showNotification("Success", notificationMessage);
    }; 

    this.showInfo = function (notificationMessage) {
        showNotification("Info", notificationMessage);
    };

    this.showWarning = function (notificationMessage) {
        showNotification("Warning", notificationMessage);
    };

    this.showError = function (notificationMessage) {
        showNotification("Error", notificationMessage);
    };

    this.tryShowNotification = function () {
        $(document).ajaxSuccess(function (event, response) {
            var notificationType = response.getResponseHeader(notificationTypeHeader);
            if (notificationType) {
                var notificationMessage = response.getResponseHeader(notificationMessageHeader);
                showNotification(notificationType, notificationMessage);
            }
        });
    };
}