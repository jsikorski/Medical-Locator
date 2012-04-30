using System;

namespace MedicalLocator.Mobile.Services.DatabaseServices
{
    public class InvalidSaveSettingsException : Exception
    {
        public string Error;
        public InvalidSaveSettingsException(string error)
        {
            Error = error;
        }
    }
}