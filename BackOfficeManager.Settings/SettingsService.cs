using BackOfficeManager.Entities;
using System.Reflection;
using System.Xml.Linq;

namespace BackOfficeManager.Settings
{
    public class SettingsService : ISettingsService
    {
        public object GetSettingsByName(string name)
        {
            //var pathToFile = ;

            string roamingpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(roamingpath, "BackOfficeManagerLite\\settings.xml");
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.Combine(roamingpath, "BackOfficeManagerLite"));
                new XDocument(
                    new XElement("settings",
                        new XElement("User",
                            new XElement("Login"), new XElement("Password")),
                        new XElement("PathToFolder"))).Save(path);
            }

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
            string roamingpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(roamingpath, "BackOfficeManagerLite\\settings.xml");
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