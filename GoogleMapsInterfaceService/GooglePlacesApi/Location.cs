using System.Globalization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    public class Location
    {
        private readonly double _latitude;
        private readonly double _longitude;

        public Location(double latitude, double longitude)
        {
            _latitude = latitude;
            _longitude = longitude;
        }

        public string ToUrlFormat()
        {
            return string.Format("{0},{1}", _latitude.ToString("0.0", CultureInfo.InvariantCulture),
                                 _longitude.ToString("0.0", CultureInfo.InvariantCulture));
        }
    }
}