var dialogsManager = new DialogsManager();

function DialogsManager() {
    var dialogDivId = "dialog";

    var setDialogCloseHandler = function (dialogDiv) {
        dialogDiv.prev().children(".ui-dialog-titlebar-close").click(function () {
            dialogDiv.remove();
        });
    };

    this.addDialogDiv = function () {
        $("body").append("<div id='" + dialogDivId + "'></div>");
    };

    this.placeContentIntoDialogDiv = function (content) {
        $("#" + dialogDivId).html(content);
    };

    this.initializeDialog = function (dialogTitle) {
        var dialogDiv = $("#" + dialogDivId);

        dialogDiv.dialog({
            modal: true,
            width: 500,
            title: dialogTitle
        });

        setDialogCloseHandler(dialogDiv);
    };
}
