function SearchingManager() {
    this.geoLocationProvider = new GeoLocationProvider();
}

SearchingManager.prototype.findNearby = function () {
    function onLocationFound(location) {
        $.ajax({
            url: "Searching/FindNearby",
            data: { longitude: location.coords.longitude, latitude: location.coords.latitude },
            success: this.onSearchSuccess
        });
    }
    
    this.geoLocationProvider.getLocation(onLocationFound);
};

SearchingManager.prototype.onSearchSuccess = function() {
    googleMapsManager.clearMarkers();
    googleMapsManager.addMarker(location);
};
