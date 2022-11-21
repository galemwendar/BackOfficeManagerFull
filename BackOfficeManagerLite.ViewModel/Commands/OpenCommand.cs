using BackOfficeManager.Entities;
using BackOfficeManager.Settings;
using BackOfficeManagerLite.ViewModel;
using BackOfficeManagerModels.Client;
using BackOfficeManagerModels.Core;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BackOfficeManager.CoreViewModel
{
    public class OpenCommand : AsyncCommandBase
    {
        private readonly IServerPropertiesService _service;
        private readonly MainViewModel _viewModel;
        private readonly IClientService _clientService;
        private readonly IClientConfig _clientConfig;
        private readonly IAuthorization _authorization;
        private readonly ISettingsService _settingsService;

        public OpenCommand(IServerPropertiesService service,IClientService clientService, IClientConfig clientConfig, IAuthorization authorization,
            ISettingsService settingsService,  MainViewModel viewModel)
        {
            _service = service;
            _viewModel = viewModel;
            _clientService = clientService;
            _clientConfig = clientConfig;
            _authorization = authorization;
            _settingsService = settingsService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                var properties = await _service.GetServerProperties(_viewModel.ServerAdress);
                _viewModel.OutputLog = properties.ServerAddr + "\n";
                _viewModel.OutputLog += properties.Version + "\n";
                _viewModel.OutputLog += properties.Edition + "\n";
                _viewModel.OutputLog += properties.ServerState + "\n";

                var user = new User(_viewModel.Login, _viewModel.Password);

                _clientConfig.SetConfig(properties, user );
                _clientService.RunClient(_clientService.FindClientApplication(properties, _settingsService));
                _authorization.AuthorizationMetod(properties, user);
            }
            catch (Exception ex)
            {

                _viewModel.OutputLog = $"{DateTime.Now} ERROR: {ex.Message}";
            }


        }
    }
}