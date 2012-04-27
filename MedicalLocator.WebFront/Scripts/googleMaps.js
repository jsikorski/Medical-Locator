googleMapsManager = {
    map: null,
    initializeMap: function (googleMapDivId) {
        var googleMaps = window.google.maps;
        var mapOptions = {
            zoom: 1,
            center: new googleMaps.LatLng(0, 0),
            mapTypeId: googleMaps.MapTypeId.ROADMAP
        };

        var mapElement = $('#' + googleMapDivId)[0];
        this.map = new googleMaps.Map(mapElement, mapOptions);
    }
};