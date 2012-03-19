using System.Collections.Generic;
using GoogleMapsInterfaceService.Properties;
using GoogleMapsInterfaceService.Requests;

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
            const string requestFormat = "{0}key={1}&location={2}&types={3}";
            
            return string.Format(
                requestFormat, 
                Settings.Default.GooglePlacesApiBaseAddress, 
                _key, 
                _location, 
                _radius, 
                _isGpsUsed, 
                _medicalTypes);
        }
    }
}