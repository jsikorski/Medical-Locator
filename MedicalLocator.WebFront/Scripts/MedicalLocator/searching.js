function SearchingManager() {
    
    var geoLocationProvider = new GeoLocationProvider();

    var onLocationFoundForFindNearby = function(location) {
        $.ajax({
            url: "Searching/FindNearby",
            data: { longitude: location.coords.longitude, latitude: location.coords.latitude },
            success: onSearchSuccess
        });
    };

    var onSearchSuccess = function (response) {
        if (response == "Failure") {
            busyIndicator.endBusy();
            return;
        }
        googleMapsManager.clearMarkers();
        var foundObjects = response.Results;
        placeMarkersOnGoogleMaps(foundObjects);
        busyIndicator.endBusy();        
    };

    var placeMarkersOnGoogleMaps = function(foundObjects) {
        for (var i = 0; i < foundObjects.length; i++) {
            var location = foundObjects[i].Location;
            var name = foundObjects[i].Name;
            googleMapsManager.addMarker(location, name);
        }
        googleMapsManager.fitMapBounds();
    };

    this.findNearby = function () {
        busyIndicator.beginBusy();
        geoLocationProvider.getLocation(onLocationFoundForFindNearby);
    };
}

