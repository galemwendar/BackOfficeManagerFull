using BackOfficeManager.Entities;
using System.Reflection.Metadata;

namespace BackOfficeManager.Settings
{

    public class Settings
    {
        public Settings(User user, string pathToFolder)
        {
            User= user;
            PathToFolder= pathToFolder;
        }
        public User User { get; set; }
        public string PathToFolder { get; set; }

    }
}