using BackOfficeManager.Entities;
using BackOfficeManagerModels.Core;
using System.Xml.Linq;

namespace BackOfficeManagerModels.Client
{
    public class ClientConfig : IClientConfig
    {
        public void SetConfig(ServerProperties props, User user)
        {
            string roamingpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = "";
            if (props.Edition == "chain")
            {
                path = roamingpath + @"\iiko\Chain\Default\config\backclient.config.xml";
            }
            else
            {
                path = roamingpath + @"\iiko\Rms\Default\config\backclient.config.xml";
            }


            XDocument backclientConfigXml = XDocument.Load(path);


            //root element
            XElement root = backclientConfigXml.Element("config");
            //if default edition save properties here
            XElement ServerProtocol = root.Element("ServerProtocol");
            XElement ServerAddr = root.Element("ServerAddr");
            XElement ServerPort = root.Element("ServerPort");
            XElement ServerSubUrl = root.Element("ServerSubUrl");
            // if chain edition, save properties here
            XElement ChainServerProtocol = root.Element("ChainServerProtocol");
            XElement ChainServerAddr = root.Element("ChainServerAddr");
            XElement ChainServerPort = root.Element("ChainServerPort");
            XElement ChainServerSubUrl = root.Element("ChainServerSubUrl");
            //method fo add new server in list of servers
            XElement ServersList = root.Element("ServersList");
            var serverProp = new XElement("ServersList",
                                        new XElement("ServerName", props.ServerName),
                                        new XElement("Version", props.Version),
                                        new XElement("ComputerName", props.ComputerName),
                                        new XElement("Protocol", props.Protocol),
                                        new XElement("ServerAddr", props.ServerAddr),
                                        new XElement("ServerSubUrl", props.ServerSubUrl),
                                        new XElement("Port", props.Port),
                                        new XElement("IsPresent", props.IsPresent.ToLower())
                                        );
            ChainServerSubUrl.AddAfterSelf(serverProp);

            if (props.Edition == "chain")
            {
                ChainServerProtocol.Value = props.Protocol;
                ChainServerAddr.Value = props.ServerAddr;
                ChainServerPort.Value = props.Port.ToString();
                ChainServerSubUrl.Value = props.ServerSubUrl;

            }

            else
            {
                ServerProtocol.Value = props.Protocol;
                ServerAddr.Value = props.ServerAddr;
                ServerPort.Value = props.Port.ToString();
                ServerSubUrl.Value = props.ServerSubUrl;
            }
            XElement serverChooserIsOpened = root.Element("serverChooserIsOpened");
            serverChooserIsOpened.Value = "true";
            XElement login = root.Element("Login");
            login.Value = user.Login;

            backclientConfigXml.Save(path);


        }
    }
}