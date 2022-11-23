using BackOfficeManager.CoreViewModel;
using System;

namespace BackOfficeManagerFull.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public NavigationViewModel NavigationViewModel { get; set; }

        public MainViewModel(NavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }
    }
}
