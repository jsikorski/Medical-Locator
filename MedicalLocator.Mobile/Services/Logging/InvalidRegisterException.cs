using System;

namespace MedicalLocator.Mobile.Services.Logging
{
    public class InvalidRegisterException : Exception
    {
        public string Error;
        public InvalidRegisterException(string error)
        {
            Error = error;
        }
    }
}