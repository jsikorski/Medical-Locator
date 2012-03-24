﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using GoogleMapsInterfaceService.Faults;
using GoogleMapsInterfaceService.GooglePlacesApi;
using GoogleMapsInterfaceService.Requests;

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

        public GooglePlacesApiResponse SendGooglePlacesApiRequest(GooglePlacesApiRequest request)
        {
            string responseJson = GetJsonFromGooglePlacesApi(request);
            var response = GetDeserializedDataFromJson<GooglePlacesApiResponse>(responseJson);
            CheckGooglePlacesApiResponse(response);
            return response;
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
    }
}
