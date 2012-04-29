googleMapsManager = {
    map: null,
    markers: [],

    initializeMap: function (googleMapDivId) {
        var googleMaps = window.google.maps;
        var mapOptions = {
            zoom: 1,
            center: new googleMaps.LatLng(0, 0),
            mapTypeId: googleMaps.MapTypeId.ROADMAP
        };

        var mapElement = $('#' + googleMapDivId)[0];
        this.map = new googleMaps.Map(mapElement, mapOptions);
    },

    clearMarkers: function () {
        for (var i = 0; i < this.markers.length; i++) {
            this.markers[i].setMap(null);
        }

        this.markers.length = 0;
    },

    addMarker: function (location) {
        var googleMaps = window.google.maps;        
        
        var position = new googleMaps.LatLng(location.coords.latitude, location.coords.longitude);
        var newMarker = new google.maps.Marker({
            position: position,
            map: this.map,
            title: "Hello World!"
        });

        this.markers.push(newMarker);

        var markersBounds = new googleMaps.LatLngBounds(position, position);
        for (var i = 0; i < this.markers.length; i++) {
            markersBounds.extend(this.markers[0].getPosition());
        }
        this.map.fitBounds(markersBounds);
    }
};