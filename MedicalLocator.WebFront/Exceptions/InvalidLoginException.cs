using System;

namespace MedicalLocator.WebFront.Exceptions
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