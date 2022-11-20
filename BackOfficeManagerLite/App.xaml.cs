using BackOfficeManager.Settings;
using BackOfficeManagerLite.ViewModel;
using BackOfficeManagerModels.Client;
using BackOfficeManagerModels.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BackOfficeManagerLite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider ServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<MainViewModel>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IServerPropertiesService, ServerPropertiesService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientConfig, ClientConfig>();
            services.AddScoped<IAuthorization, Authorization>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = ServiceProvider();
            ISettingsService settingsService = serviceProvider.GetService<ISettingsService>();
            IServerPropertiesService urlService = serviceProvider.GetService<IServerPropertiesService>();
            IClientService clientService = serviceProvider.GetService<IClientService>();
            IClientConfig clientConfig = serviceProvider.GetService<IClientConfig>();
            IAuthorization authorization = serviceProvider.GetService<IAuthorization>();


            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();

            window.Show();


            base.OnStartup(e);
        }
    }
}
