using System.Collections.Generic;
using MedicalLocator.Mobile.GoogleMapsInterfaceReference;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services
{
    public interface IGeocodingManager
    {
        Location ExecuteGeocoding(string address);
    }
}