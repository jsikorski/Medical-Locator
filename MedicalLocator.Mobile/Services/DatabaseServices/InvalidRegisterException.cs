using System;

namespace MedicalLocator.Mobile.Services.DatabaseServices
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