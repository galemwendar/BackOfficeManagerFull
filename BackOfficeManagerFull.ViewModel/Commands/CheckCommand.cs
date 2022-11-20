using System.Threading.Tasks;
using System;
using System.Windows.Input;
using BackOfficeManagerModels.Core;

namespace BackOfficeManager.CoreViewModel
{
    public  class CheckCommand : AsyncCommandBase
    {
        private readonly IServerPropertiesService _service;
        private readonly ViewModelBase _viewModel;

        public CheckCommand(IServerPropertiesService service, ViewModelBase viewModel)
        {
            _service = service;
            _viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                //var properties = await _service.GetServerProperties(_service.NormalizeUrl(_viewModel.ServerAdress));
            }
            catch (Exception ex)
            {

                throw;
            }


        }

    }
}