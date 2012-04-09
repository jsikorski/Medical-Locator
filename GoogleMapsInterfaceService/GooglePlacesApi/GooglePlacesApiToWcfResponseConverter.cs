using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMapsInterfaceService.GooglePlacesApi
{
    public class GooglePlacesApiToWcfResponseConverter
    {
        public GooglePlacesWcfResponse Convert(GooglePlacesApiResponse googlePlacesApiResponse)
        {
            var wcfResults = googlePlacesApiResponse.Results.Select(GetGooglePlacesWcfFromApiResult).ToList();
            Status status = googlePlacesApiResponse.Status;

            return new GooglePlacesWcfResponse { Results = wcfResults, Status = status };
        }

        private GooglePlacesWcfResult GetGooglePlacesWcfFromApiResult(GooglePlacesApiResult googlePlacesApiResult)
        {
            Location location = googlePlacesApiResult.Geometry.Location;
            MedicalType medicalType = GetMostSpecificMedicalType(googlePlacesApiResult);

            return new GooglePlacesWcfResult { Location = location, Type = medicalType };
        }

        private MedicalType GetMostSpecificMedicalType(GooglePlacesApiResult googlePlacesApiResult)
        {
            object result = null;
            int index = 0;
            while (result == null)
            {
                string typeName = googlePlacesApiResult.Types.ElementAt(index);
                result = Enum.Parse(typeof(MedicalType), typeName, true);
                index++;
            }

            return (MedicalType)result;
        }
    }
}