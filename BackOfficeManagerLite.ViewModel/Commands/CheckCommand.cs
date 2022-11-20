using System.Threading.Tasks;
using System;
using System.Windows.Input;
using BackOfficeManagerModels.Core;
using BackOfficeManagerLite.ViewModel;

namespace BackOfficeManager.CoreViewModel
{
    public  class CheckCommand : AsyncCommandBase
    {
        private readonly IServerPropertiesService _service;
        private readonly MainViewModel _viewModel;

        public CheckCommand(IServerPropertiesService service, MainViewModel viewModel)
        {
            _service = service;
            _viewModel = viewModel;
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
            }
            catch (Exception ex)
            {

                throw;
            }


        }

    }
}