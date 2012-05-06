googleMapsManager = new GoogleMapsManager();

function GoogleMapsManager() {
    var googleMapsApi = window.google.maps;
    var map;
    var markers = [];

    this.initializeMap = function (googleMapDomElement) {
        var mapOptions = {
            zoom: 1,
            center: new googleMapsApi.LatLng(0, 0),
            mapTypeId: googleMapsApi.MapTypeId.ROADMAP
        };

        map = new googleMapsApi.Map(googleMapDomElement, mapOptions);
    };

    this.addMarker = function (markerLocation, markerName) {
        var position = new googleMapsApi.LatLng(markerLocation.Lat, markerLocation.Lng);
        var newMarker = new googleMapsApi.Marker({
            position: position,
            map: map,
            title: markerName
        });

        var contentString = "<div class='info_window_content'><h1>" + markerName + "</h1></div>";

        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });

        google.maps.event.addListener(infowindow, 'domready', function () {
            $('.info_window_content').parent().parent().css('margin-top', '15px');
            var height = $('.info_window_content').parent().parent().height();
            height = height - 15;
            $('info_window_content').parent().parent().height(height);
        });

        googleMapsApi.event.addListener(newMarker, 'click', function () {
            infowindow.open(map, newMarker);
        });

        markers.push(newMarker);
    };

    this.clearMarkers = function () {
        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }
        markers.length = 0;
    };

    this.fitMapBounds = function () {
        var firstMarkerPosition = markers[0].getPosition();
        var markersBounds = new googleMapsApi.LatLngBounds(firstMarkerPosition, firstMarkerPosition);
        for (var i = 1; i < markers.length; i++) {
            markersBounds.extend(markers[i].getPosition());
        }
        map.fitBounds(markersBounds);
    };
}