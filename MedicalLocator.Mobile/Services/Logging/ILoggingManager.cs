using MedicalLocator.Mobile.DatabaseConnectionReference;
using MedicalLocator.Mobile.Infrastructure;
using MedicalLocator.Mobile.Model;

namespace MedicalLocator.Mobile.Services.Logging
{
    public interface ILoggingManager
    {
        void TryLogin(LoginData loginData);
        void TryRegister(RegisterData registerData);
    }
}