googleMapsManager = new GoogleMapsManager();

function MedicalMarkerOptions() {
    this.location = null;
    this.name = null;
    this.vicinity = null;
    this.type = null;
}

MedicalMarkerType = {
    User: 0,
    Doctor: 1,
    Dentist: 2,
    Health: 3,
    Hospital: 4,
    Pharmacy: 5,
    Physotherapist: 6,

    fromWcfNumber: function (number) {
        switch (number) {
            case 0:
                return this.Doctor;
            case 1:
                return this.Dentist;
            case 2:
                return this.Health;
            case 3:
                return this.Hospital;
            case 4:
                return this.Pharmacy;
            case 5:
                return this.Physotherapist;
        }
    }
};

function MarkerTypeToIconUrlConverter() {
    this.convert = function (markerType) {
        var urlBase = "/Content/Graphics/Icons/";
        var iconFileName;

        switch (markerType) {
            case MedicalMarkerType.User:
                iconFileName = "user.png";
                break;
            case MedicalMarkerType.Doctor:
                iconFileName = "doctor.png";
                break;
            case MedicalMarkerType.Dentist:
                iconFileName = "dentist.png";
                break;
            case MedicalMarkerType.Health:
                iconFileName = "health.png";
                break;
            case MedicalMarkerType.Hospital:
                iconFileName = "hospital.png";
                break;
            case MedicalMarkerType.Pharmacy:
                iconFileName = "pharmacy.png";
                break;
            case MedicalMarkerType.Physotherapist:
                iconFileName = "physotherapist.png";
                break;
            default:
                throw "Invalid marker type";
        }

        return urlBase + iconFileName;
    };
}

function GoogleMapsManager() {
    var googleMapsApi = window.google.maps;
    var map;
    var markers = [];
    var medicalTypeToMarkerUrlConverter = new MarkerTypeToIconUrlConverter();

    var addInfoWindowForMarker = function (marker, markerName, vicinity) {
        var contentString = "<div class='info_window_content'><h2>" + markerName + "</h2><p>" + vicinity + "</p></div>";
        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });
        googleMapsApi.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
    };

    this.initializeMap = function (googleMapDomElement) {
        var mapOptions = {
            zoom: 1,
            center: new googleMapsApi.LatLng(0, 0),
            mapTypeId: googleMapsApi.MapTypeId.ROADMAP
        };

        map = new googleMapsApi.Map(googleMapDomElement, mapOptions);
    };

    this.addMarker = function (medicalMarkerOptions) {
        var markerLocation = medicalMarkerOptions.location;
        var markerName = medicalMarkerOptions.name;
        var vicinity = medicalMarkerOptions.vicinity;
        var markerType = medicalMarkerOptions.type;

        var position = new googleMapsApi.LatLng(markerLocation.Lat, markerLocation.Lng);
        var markerIconUrl = medicalTypeToMarkerUrlConverter.convert(markerType);

        var newMarker = new googleMapsApi.Marker({
            position: position,
            map: map,
            title: markerName,
            icon: markerIconUrl
        });

        addInfoWindowForMarker(newMarker, markerName, vicinity);
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



