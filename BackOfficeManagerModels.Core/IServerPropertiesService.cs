namespace BackOfficeManagerModels.Core
{
    public interface IServerPropertiesService
    {
        Task<ServerProperties> GetServerProperties(string adress);
    }
}