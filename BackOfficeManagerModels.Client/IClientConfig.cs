using BackOfficeManager.Entities;
using BackOfficeManagerModels.Core;

namespace BackOfficeManagerModels.Client
{
    public interface IClientConfig
    {
        void SetConfig(ServerProperties props, User user);
    }
}