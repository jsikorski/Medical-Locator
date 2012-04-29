using System;

namespace MedicalLocator.Mobile.Services.Logging
{
    public class InvalidLoginException : Exception
    {
        public string Error;
        public InvalidLoginException(string error)
        {
            Error = error;
        }
    }
}