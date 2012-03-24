using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Common.Extensions;
using GoogleMapsInterfaceService.Properties;
using GoogleMapsInterfaceService.Requests;
using System.Linq;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    [DataContract]
    public class GooglePlacesApiRequest : IRequest
    {
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public string Key { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public Location Location { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public int Radius { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public bool IsGpsUsed { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue = false)]
        public IEnumerable<MedicalType> MedicalTypes { get; set; }

        public string ToRequestUrl()
        {
            return string.Format(
                Settings.Default.GooglePlacesApiRequestFormat, 
                Settings.Default.GooglePlacesApiBaseAddress, 
                Key, 
                Location.ToUrlFormat(), 
                Radius,
                MedicalTypes.Select(type => type.ToString()).ToUrlFormat(), 
                IsGpsUsed.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }
    }
}