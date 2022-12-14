using BackOfficeManager.Settings;
using BackOfficeManagerLite.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace BackOfficeManager.CoreViewModel
{
    public class SettingsCommand : CommandBase
    {
        private readonly ISettingsService _settings;
        private readonly MainViewModel _viewModel;

        public SettingsCommand(ISettingsService settings, MainViewModel viewModel)
        {
            _settings = settings;
            _viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            try
            {
                _settings.SetSettings(_viewModel.PathToFolder, _viewModel.Login, _viewModel.Password);
                _viewModel.OutputLog = "????????? ?????????!";
            }
            catch (System.Exception ex)
            {

                _viewModel.OutputLog = ex.Message;
            }
        }
    }
}