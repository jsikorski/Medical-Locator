geoLocationProvider = {
    lastLocation: null,

    getLocation: function () {
        navigator.geolocation.getCurrentPosition(this.onSuccess, this.onError);
        return lastLocation;
    },

    onSuccess: function (location) {
        lastLocation = location;
    },

    onError: function (errorMessage) {
        alert(errorMessage);
    }
};