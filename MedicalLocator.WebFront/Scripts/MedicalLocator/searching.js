function SearchingManager() {
    var geoLocationProvider = new GeoLocationProvider();
    var searchFormSelector = "#search_form";
    var userLatitudeFieldSelector = "#SearchData_UserLatitude";
    var userLongitudeFieldSelector = "#SearchData_UserLongitude";

    var onLocationFoundForFindNearby = function (location) {
        var userLongitude = location.coords.longitude;
        var userLatitude = location.coords.latitude;

        $.ajax({
            url: "Searching/FindNearby",
            data: { longitude: userLongitude, latitude: userLatitude },
            success: onSearchSuccess
        });
    };

    var onLocationFoundForSearchUsingUserLocation = function (location) {
        setUserCoordinatesOnForm(location);
        submitSearchForm();        
    };

    var setUserCoordinatesOnForm = function (userLocation) {
        var userLongitude = userLocation.coords.longitude;
        var userLatitude = userLocation.coords.latitude;
        $(userLatitudeFieldSelector).val(userLatitude);
        $(userLongitudeFieldSelector).val(userLongitude);
    };

    var onSearchSuccess = function (response) {
        if (!responsesController.isResponseValid(response)) {
            busyIndicator.endBusy();
            return;
        }

        googleMapsManager.clearMarkers();
        var centerLocation = response.CenterLocation;
        placeCenterMarkerOnGoogleMaps(centerLocation.Lat, centerLocation.Lng);
        var foundObjects = response.GooglePlacesApiResponse.Results;
        placeResultsMarkersOnGoogleMaps(foundObjects);

        busyIndicator.endBusy();
    };

    var placeCenterMarkerOnGoogleMaps = function (latitude, longitude) {
        var markerOptions = new MedicalMarkerOptions();
        markerOptions.name = "Center";
        markerOptions.vicinity = "Latitude: " + latitude + "<br>Longitude: " + longitude;
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

    var submitSearchForm = function() {
        $(searchFormSelector).submit();
    };

    this.findNearby = function () {
        busyIndicator.beginBusy();
        geoLocationProvider.getLocation(onLocationFoundForFindNearby);
    };

    this.searchUsingUserLocation = function () {
        busyIndicator.beginBusy();
        geoLocationProvider.getLocation(onLocationFoundForSearchUsingUserLocation);
    };

    this.searchNotUsingUserLocation = function () {
        busyIndicator.beginBusy();
        submitSearchForm();
    };

    this.processSearchResponse = onSearchSuccess;
}

