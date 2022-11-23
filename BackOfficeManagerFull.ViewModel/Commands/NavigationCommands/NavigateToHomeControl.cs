using BackOfficeManager.CoreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeManagerFull.ViewModel.Commands.NavigationCommands
{
    internal class NavigateToHomeControl:CommandBase
    {
        private readonly HomeControlViewModel _homeviewmodel;
        private readonly NavigationViewModel _navigationViewModel;

        public NavigateToHomeControl(NavigationViewModel navigationViewModel, HomeControlViewModel homeViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _homeviewmodel = homeViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationViewModel.CurrentViewModel = _homeviewmodel;
        }
    }
}
