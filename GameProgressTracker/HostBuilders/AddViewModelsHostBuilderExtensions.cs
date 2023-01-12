using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.HostBuilders
{
    /// <summary>
    /// 
    /// </summary>
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder) 
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient((s) => CreateRegistrationListingViewModel(s));
                services.AddSingleton<Func<RegistrationListingViewModel>>((s) => () => s.GetRequiredService<RegistrationListingViewModel>());
                services.AddSingleton<NavigationService<RegistrationListingViewModel>>();

                services.AddTransient<AddRegistrationViewModel>();
                services.AddSingleton<Func<AddRegistrationViewModel>>((s) => () => s.GetRequiredService<AddRegistrationViewModel>());
                services.AddSingleton<NavigationService<AddRegistrationViewModel>>();
            });

            return hostBuilder;
        }

        private static RegistrationListingViewModel CreateRegistrationListingViewModel(IServiceProvider services)
        {
            return RegistrationListingViewModel.LoadViewModel(
                services.GetRequiredService<GamesStore>(),
                services.GetRequiredService<NavigationService<AddRegistrationViewModel>>());
        }
    }
}
