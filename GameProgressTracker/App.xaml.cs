using GameProgressTracker.DbContexts;
using GameProgressTracker.Exceptions;
using GameProgressTracker.HostBuilders;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Services.RegistrationConflictValidators;
using GameProgressTracker.Services.RegistrationCreator;
using GameProgressTracker.Services.RegistrationDestroyer;
using GameProgressTracker.Services.ReservationProviders;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameProgressTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*private readonly Game _game;
        private readonly GamesStore _gameStore;
        private readonly NavigationStore _navigationStore;
        private readonly AppDbContextFactory _appDbContextFactory;*/
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddViewModels()
                .ConfigureServices((hostContext, services) =>
            {
                string connectionString = hostContext.Configuration.GetConnectionString("Default");

                services.AddSingleton(new AppDbContextFactory(connectionString));
                services.AddSingleton<IReservationProvider, DatabaseReservationProvider>();
                services.AddSingleton<IRegistrationCreator, DBRegistrationCreator>();
                services.AddSingleton<IRegistrationDestroyer, DBRegistrationDestroyer>();
                services.AddSingleton<IRegistrationConflictValidator, DBRegistrationConflictValidator>();

                services.AddTransient<Progress>();
                services.AddSingleton((s) => new Game(s.GetRequiredService<Progress>()));

                services.AddSingleton<GamesStore>();
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<GamesStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            AppDbContextFactory appDbContextFactory = _host.Services.GetRequiredService<AppDbContextFactory>();
            using(AppDbContext dbContext = appDbContextFactory.CreateDbContext())//2
            {
                dbContext.Database.Migrate();// this string of code need us to create our first database and keep the information there
            }

            NavigationService<RegistrationListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<RegistrationListingViewModel>>();
            navigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
