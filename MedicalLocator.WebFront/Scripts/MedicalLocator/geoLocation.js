function GeoLocationProvider() {

    var lastOnLocationFound;

    var onGeoLocationSuccess = function (location) {
        lastOnLocationFound(location);
    };

    var onGeoLocationError = function (errorMessage) {
        alert(errorMessage);
    };

    this.getLocation = function (onLocationFound) {
        lastOnLocationFound = onLocationFound;
        navigator.geolocation.getCurrentPosition(onGeoLocationSuccess, onGeoLocationError);
    };
};