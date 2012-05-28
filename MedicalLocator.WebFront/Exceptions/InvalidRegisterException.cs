using System;

namespace MedicalLocator.WebFront.Exceptions
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