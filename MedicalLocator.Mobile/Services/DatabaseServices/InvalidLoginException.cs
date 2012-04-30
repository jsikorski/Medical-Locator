using System;

namespace MedicalLocator.Mobile.Services.DatabaseServices
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