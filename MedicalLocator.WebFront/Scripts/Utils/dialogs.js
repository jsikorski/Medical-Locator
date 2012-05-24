var dialogsManager = new DialogsManager();

function DialogsManager() {
    var dialogDivId = "dialog";

    var getDialogDiv = function () {
        return $("#" + dialogDivId);
    };

    var closeDialog = function() {
        getDialogDiv().remove();        
    };

    var setDialogCloseHandler = function () {
        getDialogDiv().prev().children(".ui-dialog-titlebar-close").click(function () {
            closeDialog();
        });
    };

    this.addDialogDiv = function () {
        $("body").append("<div id='" + dialogDivId + "'></div>");
    };

    this.placeContentIntoDialogDiv = function (content) {
        $("#" + dialogDivId).html(content);  
    };

    this.initializeDialog = function (dialogTitle) {
        var dialogDiv = getDialogDiv();

        dialogDiv.dialog({
            modal: true,
            width: 500,
            title: dialogTitle,
            resizable: false
        });

        setDialogCloseHandler(dialogDiv);
    };

    this.closeDialog = closeDialog;
}
