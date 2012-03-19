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
        [DataMember]
        private readonly string _key;
        [DataMember]
        private readonly Location _location;
        [DataMember]
        private readonly int _radius;
        [DataMember]
        private readonly bool _isGpsUsed;
        [DataMember]
        private readonly IEnumerable<MedicalType> _medicalTypes;

        public GooglePlacesApiRequest(
            string key, Location location, int radius, 
            bool isGpsUsed, IEnumerable<MedicalType> medicalTypes)
        {
            _key = key;
            _location = location;
            _radius = radius;
            _isGpsUsed = isGpsUsed;
            _medicalTypes = medicalTypes;
        }

        public string ToRequestUrl()
        {
            return string.Format(
                Settings.Default.GooglePlacesApiRequestFormat, 
                Settings.Default.GooglePlacesApiBaseAddress, 
                _key, 
                _location.ToUrlFormat(), 
                _radius,
                _medicalTypes.Select(type => type.ToString()).ToUrlFormat(), 
                _isGpsUsed.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());
        }
    }
}