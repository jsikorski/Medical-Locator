busyIndicator = new BusyIndicator();

function BusyIndicator() {
    var getOverlay = function() {
        return $("#overlay");
    };

    this.beginBusy = function () {
        var overlay = getOverlay();
        overlay.show();
    };

    this.endBusy = function () {
        var overlay = getOverlay();
        overlay.hide();
    };
}