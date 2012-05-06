using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using GoogleMapsInterfaceService.Extensions;
using GoogleMapsInterfaceService.Keys;
using GoogleMapsInterfaceService.Model;
using GoogleMapsInterfaceService.Properties;
using GoogleMapsInterfaceService.Requests;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesApiRequest : IRequest
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public Location Location { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public int Radius { get; set; }
        [DataMember(IsRequired = true)]
        public bool IsGpsUsed { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public IEnumerable<MedicalTypeGoogleService> MedicalTypes { get; set; }

        public string ToRequestUrl()
        {
            return string.Format(
                Settings.Default.GooglePlacesApiRequestFormat, 
                Settings.Default.GooglePlacesApiBaseAddress, 
                KeysProvider.GooglePlacesApiKey, 
                Location.ToUrlFormat(), 
                Radius,
                MedicalTypes.Select(type => type.ToString()).ToUrlFormat(), 
                IsGpsUsed.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }
    }
}