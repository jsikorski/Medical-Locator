var loggingDialogManager = new LoggingDialogManager();

function LoggingDialogManager() {
    var loggingManager = new LoggingManager();

    var loginOptionsTabsSelector = "#login_options_tabs";

    var loginFormSelector = "#login_form";
    var loginButtonSelector = "#login_button";

    var onLoginButtonClick = function () {
        if (!$(loginFormSelector).valid()) {
            return;
        }

        loggingManager.login();
    };

    this.initialize = function () {
        $(loginOptionsTabsSelector).tabs();

        var loginButton = $(loginButtonSelector);
        loginButton.button();
        loginButton.click(onLoginButtonClick);
    };

    this.processLoginResponse = function (response) {
        loggingManager.processLoginResponse();

        if (responsesController.isResponseValid(response)) {
            $("#user_name_text").html("Hello, " + ($("#Login").val()));
            $("#login_block").hide();
            $("#logout_block").show();
            
            dialogsManager.closeDialog();
        }
    };
}

