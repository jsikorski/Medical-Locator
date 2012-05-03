using System.ServiceModel;
using GoogleMapsInterfaceService.Faults;
using GoogleMapsInterfaceService.GoogleGeocodingApi;
using GoogleMapsInterfaceService.GooglePlacesApi;

namespace GoogleMapsInterfaceService
{
    [ServiceContract]
    public interface IGoogleMapsInterfaceService
    {
        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(InvalidResponseFault))]
        [FaultContract(typeof(RequestDeniedFault))]
        GooglePlacesWcfResponse SendGooglePlacesApiRequest(GooglePlacesApiRequest request);

        [OperationContract]
        [FaultContract(typeof(ConnectionFault))]
        [FaultContract(typeof(InvalidResponseFault))]
        [FaultContract(typeof(RequestDeniedFault))]
        [FaultContract(typeof(IncorectCharsInAddressFault))]
        GoogleGeocodingWcfResponse SendGoogleGeocodingApiRequest(GoogleGeocodingApiRequest request);
    }
}
