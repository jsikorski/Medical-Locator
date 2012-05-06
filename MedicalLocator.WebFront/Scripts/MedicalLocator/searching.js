function SearchingManager() {
    
    var geoLocationProvider = new GeoLocationProvider();

    var onLocationFoundForFindNearby = function (location) {
        var userLongitude = location.coords.longitude;
        var userLatitude = location.coords.latitude;
        
        $.ajax({
            url: "Searching/FindNearby",
            data: { longitude: userLongitude, latitude: userLatitude },
            success: function (response) { onSearchSuccess(response, userLongitude, userLatitude); }
        });
    };

    var onSearchSuccess = function (response, userLongitude, userLatitude) {
        if (response == "Failure") {
            busyIndicator.endBusy();
            return;
        }
        googleMapsManager.clearMarkers();
        placeUserMarkerOnGoogleMaps(userLongitude, userLatitude);
        var foundObjects = response.Results;
        placeResultsMarkersOnGoogleMaps(foundObjects);

        busyIndicator.endBusy();
    };

    var placeUserMarkerOnGoogleMaps = function (longitude, latitude) {
        var markerOptions = new MedicalMarkerOptions();
        markerOptions.name = "Me";
        markerOptions.vicinity = "Longitude: " + longitude + "<br>Latitude: " + latitude;
        markerOptions.location = { Lat: latitude, Lng: longitude };
        markerOptions.type = MedicalMarkerType.User;
        googleMapsManager.addMarker(markerOptions);
    };

    var placeResultsMarkersOnGoogleMaps = function (foundObjects) {
        for (var i = 0; i < foundObjects.length; i++) {
            var markerOptions = new MedicalMarkerOptions();
            markerOptions.name = foundObjects[i].Name;
            markerOptions.location = foundObjects[i].Location;
            markerOptions.vicinity = foundObjects[i].Vicinity;
            markerOptions.type = MedicalMarkerType.fromWcfNumber(foundObjects[i].Type);
            googleMapsManager.addMarker(markerOptions);
        }
        googleMapsManager.fitMapBounds();
    };

    this.findNearby = function () {
        busyIndicator.beginBusy();
        geoLocationProvider.getLocation(onLocationFoundForFindNearby);
    };
}

