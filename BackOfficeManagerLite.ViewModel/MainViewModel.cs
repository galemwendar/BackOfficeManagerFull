using BackOfficeManager.CoreViewModel;
using BackOfficeManager.Entities;
using BackOfficeManager.Settings;
using BackOfficeManagerModels.Client;
using BackOfficeManagerModels.Core;
using System;
using System.Windows.Input;

namespace BackOfficeManagerLite.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private string _serverAdress;
        private string _login;
        private string _password;
        private string _PathToFolder;
        private string _outputLog;

        #region Public Strings
        public string ServerAdress
        {
            get { return _serverAdress; }
            set { _serverAdress = value; OnPropertyChanged(); }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public string PathToFolder
        {
            get { return _PathToFolder; }
            set { _PathToFolder = value; OnPropertyChanged(); }
        }

        public string OutputLog
        {
            get { return _outputLog; }
            set { _outputLog = value; OnPropertyChanged(); }
        }
        #endregion


        public ICommand CheckProperties { get; }
        public ICommand OpenBackOffice { get; }
        public ICommand CloseAll { get; }
        public ICommand SetPathToFolder { get; }
        public ICommand SaveSettings { get; }


        public MainViewModel(IClientService clientService, IClientConfig clientConfig,
                            IServerPropertiesService serverPropertiesService, ISettingsService settingsService,
                            IAuthorization authorization)
        {
            CloseAll = new CloseAllCommand(clientService);
            CheckProperties = new CheckCommand(serverPropertiesService, this);
            SaveSettings = new SettingsCommand(settingsService, this);
            LoadSettings(settingsService);
            PathToFolder = settingsService.GetSettingsByName("PathToFolder").ToString();
            SetPathToFolder = new PathToFolderCommand(settingsService, this);
            OpenBackOffice = new OpenCommand(serverPropertiesService, clientService, clientConfig, authorization, settingsService, this);
        }

        private void LoadSettings(ISettingsService settingsService)
        {
            try
            {
                User user = (User)settingsService.GetSettingsByName("User");
                Login = user.Login;
                Password = user.Password;
            }
            catch (Exception ex)
            {

                OutputLog = ex.Message;
            }
        }
    }
}
