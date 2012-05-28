function LoggingManager() {

    var loginFormSelector = "#login_form";

    var onLoginSuccess = function (response) {
        busyIndicator.endBusy();
    };

    this.login = function () {
        busyIndicator.beginBusy();
        $(loginFormSelector).submit();
    };

    this.processLoginResponse = onLoginSuccess;
}

