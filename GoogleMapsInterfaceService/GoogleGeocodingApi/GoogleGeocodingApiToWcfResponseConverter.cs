using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleMapsInterfaceService.GoogleGeocodingApi
{
    public class GoogleGeocodingApiToWcfResponseConverter
    {
        public GoogleGeocodingWcfResponse Convert(GoogleGeocodingApiResponse googleGeocodingApiResponse)
        {
            var wcfResults = googleGeocodingApiResponse.Results.Select(GetGoogleGeocodingWcfFromApiResult).ToList();
            Status status = googleGeocodingApiResponse.Status;

            return new GoogleGeocodingWcfResponse { Results = wcfResults, Status = status };
        }

        private GoogleGeocodingWcfResult GetGoogleGeocodingWcfFromApiResult(GoogleGeocodingApiResult googleGeocodingApiResult)
        {
            Location location = googleGeocodingApiResult.Geometry.Location;
            return new GoogleGeocodingWcfResult { Location = location };
        }
    }
}