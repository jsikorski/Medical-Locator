namespace MedicalLocator.Mobile.Services.DatabaseServices
{
    public interface IDatabaseManager
    {
        void TryLogin(LoginData loginData);
        void TryRegister(RegisterData registerData);
        void TrySaveSettings(SaveSettingsData saveSettingsData);
    }
}