using BackOfficeManagerFull.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BackOfficeManagerFullView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            MainWindow window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<MainViewModel>();
            services.AddScoped<NavigationViewModel>();
            services.AddScoped<HomeControlViewModel>();
            services.AddScoped<GroupsControlViewModel>();
            services.AddScoped<SettingsControlViewModel>();
            return services.BuildServiceProvider();
        }
    }
}
