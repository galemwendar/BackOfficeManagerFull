namespace BackOfficeManagerModels.Core
{
    public class ServerProperties
    {

        public ServerProperties(string serverName, string edition, string version,
                                string computerName, string serverState, string protocol, string serverAddr,
                                string serverSubUrl, string port, string isPresent)
        {
            ServerName = serverName;
            Edition = edition;
            Version = version;
            ComputerName = computerName;
            ServerState = serverState;
            Protocol = protocol;
            ServerAddr = serverAddr;
            ServerSubUrl = serverSubUrl;
            Port = port;
            IsPresent = isPresent;
        }

        public string ServerName { get; set; }
        public string Edition { get; set; }
        public string Version { get; set; }
        public string ComputerName { get; set; }
        public string ServerState { get; set; }

        public string Protocol { get; set; }
        public string ServerAddr { get; set; }
        public string ServerSubUrl { get; set; }
        public string Port { get; set; }
        public string IsPresent { get; set; }

        //public DateTime LastExchange { get; set; }
    }
}