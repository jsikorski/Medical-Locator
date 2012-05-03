using System.Globalization;
using System.Runtime.Serialization;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class Location
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public double Lat { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public double Lng { get; set; }

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