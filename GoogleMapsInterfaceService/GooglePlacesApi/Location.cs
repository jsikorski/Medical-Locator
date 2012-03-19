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

        public override string ToString()
        {
            return string.Format("{0},{1}", _latitude, _longitude);
        }
    }
}