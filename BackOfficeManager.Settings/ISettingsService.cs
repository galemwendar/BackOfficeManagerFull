namespace BackOfficeManager.Settings
{
    public interface ISettingsService
    {
        object GetSettingsByName(string name);
        void SetSettings(string pathToFolder, string login, string password);
    }
}