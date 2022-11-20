using BackOfficeManager.Entities;
using BackOfficeManagerModels.Core;
using System.Reflection.Metadata;

namespace BackOfficeManagerModels.Client
{
    public interface IAuthorization
    {
        void AuthorizationMetod(ServerProperties serverprop, User user);
    }
}