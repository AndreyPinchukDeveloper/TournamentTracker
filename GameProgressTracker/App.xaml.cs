using GameProgressTracker.DbContexts;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Services.RegistrationConflictValidators;
using GameProgressTracker.Services.RegistrationCreator;
using GameProgressTracker.Services.ReservationProviders;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private const string CONNECTION_STRING = "Data Source = GameTracker.db";
        private readonly GamePlatform _platform;
        private readonly NavigationStore _navigationStore;
        private readonly AppDbContextFactory _appDbContextFactory;

        public App()
        {
            _appDbContextFactory = new AppDbContextFactory(CONNECTION_STRING);
            IReservationProvider reservationProvider = new DatabaseReservationProvider(_appDbContextFactory);
            IRegistrationCreator registrationCreator = new DBRegistrationCreator(_appDbContextFactory);
            IRegistrationConflictValidator registrationConflictValidator = new DBRegistrationConflictValidator(_appDbContextFactory);

            Progress progress = new Progress(reservationProvider, registrationCreator, registrationConflictValidator);

            _platform = new GamePlatform("PC", progress);//emit the memory for this object(always when we create new object)
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using(AppDbContext dbContext = _appDbContextFactory.CreateDbContext())//2
            {
                dbContext.Database.Migrate();// this string of code need us to create our first database and keep the information there
            }

            _navigationStore.CurrentViewModel = CreateRegistrationViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        ////
        private AddRegistrationViewModel CreateAddRegistrationViewModel()
        {
            return new AddRegistrationViewModel(_platform, new NavigationService(_navigationStore, CreateRegistrationViewModel));
        }

        private RegistrationListingViewModel CreateRegistrationViewModel()
        {
            return RegistrationListingViewModel.LoadViewModel(_platform, new NavigationService(_navigationStore, CreateAddRegistrationViewModel));
        }
    }
}
