using GameProgressTracker.DbContexts;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
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

        public App()
        {
            _platform = new GamePlatform("PC");//emit the memory for this object(always when we create new object)
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;//1
            using(AppDbContext dbContext = new AppDbContext(options))//2
            {
                dbContext.Database.Migrate();//3 these 3 strings of code need us to create our first database and keep the information there
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
            return new RegistrationListingViewModel(_platform, new NavigationService(_navigationStore, CreateAddRegistrationViewModel));
        }
    }
}
