function GeoLocationProvider() {
}

GeoLocationProvider.prototype.getLocation = function (a) {
    var resultLocation;

    function onSuccess(location) {
        resultLocation = location;
        a(location);
    }

    function onError(errorMessage) {
        alert(errorMessage);
    }

    navigator.geolocation.getCurrentPosition(onSuccess, onError);
};