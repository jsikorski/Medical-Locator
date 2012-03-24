using System;

namespace MedicalLocator.Mobile.Infrastructure
{
    public interface IHasErrorHandler<T>
    {
        void HandleError(T exception);
    }
}