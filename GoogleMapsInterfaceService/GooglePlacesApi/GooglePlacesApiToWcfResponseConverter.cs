using System;
using System.Collections.Generic;
using System.Linq;
using GoogleMapsInterfaceService.Model;

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
            string name = googlePlacesApiResult.Name;
            string vicinity = googlePlacesApiResult.Vicinity;
            Location location = googlePlacesApiResult.Geometry.Location;
            MedicalTypeGoogleService medicalType = GetMostSpecificMedicalType(googlePlacesApiResult);

            return new GooglePlacesWcfResult { Name = name, Vicinity = vicinity, Location = location, Type = medicalType };
        }

        private MedicalTypeGoogleService GetMostSpecificMedicalType(GooglePlacesApiResult googlePlacesApiResult)
        {
            MedicalTypeGoogleService medicalType;
            int index = 0;
            while (true)
            {
                string typeName = googlePlacesApiResult.Types.ElementAt(index);
                if (Enum.TryParse(typeName, true, out medicalType))
                {
                    break;
                }
                index++;
            }

            return medicalType;
        }
    }
}