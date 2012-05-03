using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using GoogleMapsInterfaceService.Extensions;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Keys;
using GoogleMapsInterfaceService.Model;
using GoogleMapsInterfaceService.Properties;
using GoogleMapsInterfaceService.Requests;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    [DataContract]
    public class GoogleGeocodingApiRequest : IRequest
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string Address { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public bool IsGpsUsed { get; set; }

        public string ToRequestUrl()
        {
            return string.Format(
                Settings.Default.GoogleGeocodingApiRequestFormat,
                Settings.Default.GoogleGeocodingApiBaseAddress,
                Address,
                IsGpsUsed.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }
    }
}