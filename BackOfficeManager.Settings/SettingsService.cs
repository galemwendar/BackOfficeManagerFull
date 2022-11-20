using BackOfficeManager.Entities;
using System.Xml.Linq;

namespace BackOfficeManager.Settings
{
    public class SettingsService : ISettingsService
    {
        public object GetSettingsByName(string name)
        {
            var path = "settings.xml";

            XDocument settingsXml = XDocument.Load(path);
            XElement root = settingsXml.Element("settings");
            var userElement = root.Element("User");

            var user = new User(userElement.Element("Login").Value, userElement.Element("Password").Value);
            var settings = new Settings(user, root.Element("PathToFolder").Value);

            var prop = typeof(Settings).GetProperty(name);
            return prop.GetValue(settings);

        }

        public void SetSettings(string pathToFolder, string login, string password)
        {
            var user = new User(login, password);
            var path = "settings.xml";
            XDocument settingsXml = XDocument.Load(path);
            XElement root = settingsXml.Element("settings");

            var userElement = root.Element("User");
            userElement.Element("Login").Value = user.Login;
            userElement.Element("Password").Value = user.Password;
            root.Element("PathToFolder").Value = pathToFolder;
            settingsXml.Save(path);

        }
    }
}