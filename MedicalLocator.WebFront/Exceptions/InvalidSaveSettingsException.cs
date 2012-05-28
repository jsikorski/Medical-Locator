using System;

namespace MedicalLocator.WebFront.Exceptions
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