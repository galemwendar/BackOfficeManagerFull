using BackOfficeManagerModels.Client;
using System.Windows.Input;

namespace BackOfficeManager.CoreViewModel
{
    public class CloseAllCommand : CommandBase
    {
        private readonly IClientService _clientService;
        public CloseAllCommand(IClientService service)
        {
            _clientService = service;
        }
        public override void Execute(object? parameter)
        {
            _clientService.CloseAllClients();
        }
    }
}