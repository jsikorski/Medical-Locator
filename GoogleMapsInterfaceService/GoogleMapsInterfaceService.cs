using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using GoogleMapsInterfaceService.Faults;
using GoogleMapsInterfaceService.GoogleGeocodingApi;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Model;
using GoogleMapsInterfaceService.Requests;
using Status = GoogleMapsInterfaceService.GooglePlacesApi.Status;

namespace GoogleMapsInterfaceService
{
    public class GoogleMapsInterfaceService : IGoogleMapsInterfaceService
    {
        private readonly IRequestsSender _requestsSender;

        public GoogleMapsInterfaceService()
        {
            _requestsSender = new RequestsSender();
        }

        // Constructor used for testing purposes
        public GoogleMapsInterfaceService(IRequestsSender requestsSender)
        {
            _requestsSender = requestsSender;
        }

        public GooglePlacesWcfResponse SendGooglePlacesApiRequest(GooglePlacesApiRequest request)
        {
            string responseJson = GetJsonFromGooglePlacesApi(request);
            var apiResponse = GetDeserializedDataFromJson<GooglePlacesApiResponse>(responseJson);
            CheckGooglePlacesApiResponse(apiResponse);
            GooglePlacesWcfResponse wcfResponse = ConvertGooglePlacesApiToGooglePlacesWcfResponse(apiResponse, request.MedicalTypes);
            return wcfResponse;
        }

        private string GetJsonFromGooglePlacesApi(GooglePlacesApiRequest request)
        {
            string responseJson;
            try
            {
                responseJson = _requestsSender.SendRequest(request);
            }
            catch (Exception)
            {
                var connectionFault = new ConnectionFault
                                          {
                                              RequestedAddress = request.ToRequestUrl(),
                                              Operation = "Sending request",
                                              Message = "Cannot connect to Google Places Api."
                                          };

                throw new FaultException<ConnectionFault>(connectionFault, "Connection error");
            }

            return responseJson;
        }

        private void CheckGooglePlacesApiResponse(GooglePlacesApiResponse response)
        {
            if (response.Status == Status.Request_Denied)
            {
                var requestDeniedFault = new RequestDeniedFault
                                             {
                                                 Message = "Invalid Google Places Api key."
                                             };

                throw new FaultException<RequestDeniedFault>(requestDeniedFault, "Request is denied");
            }
        }

        private GooglePlacesWcfResponse ConvertGooglePlacesApiToGooglePlacesWcfResponse(
            GooglePlacesApiResponse googlePlacesApiResponse, IEnumerable<MedicalTypeGoogleService> allowedMedicalTypes)
        {
            var converter = new GooglePlacesApiToWcfResponseConverter(allowedMedicalTypes);
            return converter.Convert(googlePlacesApiResponse);
        }

        static private readonly string[] IncorectCharsInAddress = { "=", "!", "@", "#", "$", "%", "^", "&", "*", "?", "|", "'", "\"", "\n", "\r", "\t" };
        public GoogleGeocodingWcfResponse SendGoogleGeocodingApiRequest(GoogleGeocodingApiRequest request)
        {
            if (IncorectCharsInAddress.Any(s => request.Address.Contains(s)))
            {
                var incorectCharsInAddressFault = new IncorectCharsInAddressFault
                {
                    Message = "Incorect characters in address."
                };

                throw new FaultException<IncorectCharsInAddressFault>(incorectCharsInAddressFault, "Invalid address");
            }

            string responseJson = GetJsonFromGoogleGeocodingApi(request);
            var apiResponse = GetDeserializedDataFromJson<GoogleGeocodingApiResponse>(responseJson);
            CheckGoogleGeocodingApiResponse(apiResponse);
            GoogleGeocodingWcfResponse wcfResponse = ConvertGoogleGeocodingApiToGoogleGeocodingWcfResponse(apiResponse);
            return wcfResponse;
        }

        private string GetJsonFromGoogleGeocodingApi(GoogleGeocodingApiRequest request)
        {
            string responseJson;
            try
            {
                responseJson = _requestsSender.SendRequest(request);
            }
            catch (Exception)
            {
                var connectionFault = new ConnectionFault
                {
                    RequestedAddress = request.ToRequestUrl(),
                    Operation = "Sending request",
                    Message = "Cannot connect to Google Geocoding Api."
                };

                throw new FaultException<ConnectionFault>(connectionFault, "Connection error");
            }

            return responseJson;
        }

        private void CheckGoogleGeocodingApiResponse(GoogleGeocodingApiResponse response)
        {
            if (response.Status == GoogleGeocodingApi.Status.Request_Denied)
            {
                var requestDeniedFault = new RequestDeniedFault
                {
                    Message = "Google Geocoding Request Denied."
                };

                throw new FaultException<RequestDeniedFault>(requestDeniedFault, "Request is denied");
            }
        }

        private GoogleGeocodingWcfResponse ConvertGoogleGeocodingApiToGoogleGeocodingWcfResponse(
            GoogleGeocodingApiResponse googleGeocodingApiResponse)
        {
            var converter = new GoogleGeocodingApiToWcfResponseConverter();
            return converter.Convert(googleGeocodingApiResponse);
        }

        private T GetDeserializedDataFromJson<T>(string jsonString)
        {
            var serializer = new JavaScriptSerializer();

            T deserializedData;
            try
            {
                deserializedData = serializer.Deserialize<T>(jsonString);
            }
            catch (Exception)
            {
                var invalidResponseFault = new InvalidResponseFault
                {
                    ResponseText = jsonString,
                    Message = "Received invalid response."
                };

                throw new FaultException<InvalidResponseFault>(invalidResponseFault, "Invalid response from server");
            }

            return deserializedData;
        }


    }
}
