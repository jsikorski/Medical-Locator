using System.Collections.Generic;
using System.Globalization;
using GoogleMapsInterfaceService.Properties;
using GoogleMapsInterfaceService.Requests;
using GoogleMapsInterfaceService.Extensions;
using System.Linq;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    public class GooglePlacesApiRequest : IRequest
    {
        public static readonly string GooglePlacesApiBaseAddress = Settings.Default.GooglePlacesApiBaseAddress;

        private readonly string _key;
        private readonly Location _location;
        private readonly int _radius;
        private readonly bool _isGpsUsed;
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

        public string ToRequestString()
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