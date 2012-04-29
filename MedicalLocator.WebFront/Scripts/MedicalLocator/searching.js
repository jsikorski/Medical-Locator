searchingManager = {
    findNearby: function () {
        var location = geoLocationProvider.getLocation();
        googleMapsManager.clearMarkers();
        googleMapsManager.addMarker(location);
    }
};
