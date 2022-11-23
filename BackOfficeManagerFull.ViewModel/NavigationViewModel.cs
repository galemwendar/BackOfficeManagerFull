using BackOfficeManager.CoreViewModel;
using BackOfficeManagerFull.ViewModel.Commands.NavigationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BackOfficeManagerFull.ViewModel
{
    public class NavigationViewModel:ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnPropertyChanged(); }
        }
        public ICommand ToHome { get; }
        public ICommand ToGroups { get; }
        public ICommand ToSettings { get; }

        public NavigationViewModel(HomeControlViewModel homeViewModel,GroupsControlViewModel groupsControlViewModel ,SettingsControlViewModel settingsViewModel)
        {
            CurrentViewModel = homeViewModel;
            ToHome = new NavigateToHomeControl(this, homeViewModel);
            ToGroups = new NavigateToGroupsControl(this, groupsControlViewModel);
            ToSettings = new NavigateToSettingsControl(this, settingsViewModel);
        }
    }
}
