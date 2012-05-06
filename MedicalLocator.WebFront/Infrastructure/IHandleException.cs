using System;

namespace MedicalLocator.WebFront.Infrastructure
{
    public interface IHandleException<in T> where T : Exception
    {
        ExceptionModel HandleException(T exception);
    }
}