using System;
using System.Collections.Generic;
using System.Linq;
using MedicalLocator.WebFront.Exceptions;
using MedicalLocator.WebFront.GoogleMapsInterfaceReference;
using MedicalLocator.WebFront.Infrastructure;
using MedicalLocator.WebFront.Models;
using MedicalLocator.WebFront.Models.CommandsData;

namespace MedicalLocator.WebFront.Services
{
    public class DatabaseManager : IDatabaseManager
    {
        public DatabaseManager()
        {
        }

        public void TrySaveSettings(char saveSettingsData)
        {
        }

        public void TryRegister(RegisterData registerData)
        {
            if (registerData.Login == "marek")
                throw new NoSearchResultsException();
        }

        public void TryLogin(LoginData loginData)
        {
            if (loginData.Login == "marek")
                throw new NoSearchResultsException();
        }
    }
}