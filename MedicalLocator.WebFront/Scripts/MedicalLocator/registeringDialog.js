var registeringDialogManager = new RegisteringDialogManager();


function RegisteringDialogManager() {
    var registeringManager = new RegisteringManager();

    var registerFormSelector = "#register_form";
    var registerButtonSelector = "#register_button";

    var onRegisterButtonClick = function () {
        if (!$(registerFormSelector).valid()) {
            return;
        }

        registeringManager.register();
    };
    
    this.initialize = function () {
        var registerButton = $(registerButtonSelector);
        registerButton.button();
        registerButton.click(onRegisterButtonClick);
    };

    this.processRegisterResponse = function (response) {
        registeringManager.processRegisterResponse();

        if (responsesController.isResponseValid(response)) {
            dialogsManager.closeDialog();
        }
    };
}

