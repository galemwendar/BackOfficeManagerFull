using BackOfficeManager.Settings;
using BackOfficeManagerModels.Core;

namespace BackOfficeManagerModels.Client
{
    public interface IClientService
    {
        void CloseAllClients();
        string FindClientApplication(ServerProperties props, ISettingsService settingsService);
        void RunClient(string filepath);
    }
}