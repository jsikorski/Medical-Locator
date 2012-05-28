function RegisteringManager() {

    var registerFormSelector = "#register_form";

    var onRegisterSuccess = function (response) {
        busyIndicator.endBusy();
    };

    this.register = function () {
        busyIndicator.beginBusy();
        $(registerFormSelector).submit();
    };

    this.processRegisterResponse = onRegisterSuccess;
}

