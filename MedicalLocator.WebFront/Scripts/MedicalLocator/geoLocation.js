function GeoLocationProvider() {

    var lastOnLocationFound;

    var onGeoLocationSuccess = function (location) {
        lastOnLocationFound(location);
    };

    var onGeoLocationError = function (errorMessage) {
        busyIndicator.endBusy();
        notificationsManager.showError("Cannot get localization.");
    };

    this.getLocation = function (onLocationFound) {
        lastOnLocationFound = onLocationFound;
        navigator.geolocation.getCurrentPosition(onGeoLocationSuccess, onGeoLocationError);
    };
};