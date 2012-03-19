using System.Globalization;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public double Lat { get; set; }
        [DataMember]
        public double Lng { get; set; }

        public Location()
        {
            
        }

        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        // Method virtual for mocking purposes
        public virtual string ToUrlFormat()
        {
            return string.Format(
                "{0},{1}", 
                Lat.ToString(CultureInfo.InvariantCulture), 
                Lng.ToString(CultureInfo.InvariantCulture));
        }
    }
}