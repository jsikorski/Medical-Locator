﻿using System.Collections.Generic;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services
{
    public interface IGoogleMapsInterfaceServiceProxy
    {
        GooglePlacesWcfResponse GetResponseFromGooglePlacesApi(
            Location centerLocation, IEnumerable<MedicalType> searchedObjects, int range);

        GoogleGeocodingWcfResponse GetResponseFromGoogleGeocodingApi(string address);
    }
}