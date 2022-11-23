using BackOfficeManager.CoreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeManagerFull.ViewModel.Commands.NavigationCommands
{
    internal class NavigateToSettingsControl:CommandBase
    {
        private readonly SettingsControlViewModel _settingsViewModel;
        private readonly NavigationViewModel _navigationViewModel;

        public NavigateToSettingsControl(NavigationViewModel navigationViewModel, SettingsControlViewModel settingsViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _settingsViewModel = settingsViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationViewModel.CurrentViewModel = _settingsViewModel;
        }
    }
}
