using BackOfficeManager.CoreViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOfficeManagerFull.ViewModel.Commands.NavigationCommands
{
    internal class NavigateToGroupsControl:CommandBase
    {
        private readonly GroupsControlViewModel _groupsViewModel;
        private readonly NavigationViewModel _navigationViewModel;

        public NavigateToGroupsControl(NavigationViewModel navigationViewModel, GroupsControlViewModel groupsViewModel)
        {
            _navigationViewModel = navigationViewModel;
            _groupsViewModel = groupsViewModel;
        }
        public override void Execute(object? parameter)
        {
            _navigationViewModel.CurrentViewModel = _groupsViewModel;
        }
    }
}
