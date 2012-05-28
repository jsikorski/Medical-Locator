using System.Collections.Generic;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public interface IDatabaseManager
    {
        void TryRegister(RegisterData registerData);
        void TrySaveSettings(char saveSettingsData);
        void TryLogin(LoginData loginData);
    }
}