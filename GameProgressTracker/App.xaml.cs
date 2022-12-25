using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
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
        private readonly GamePlatform _platform;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _platform = new GamePlatform("PC");//emit the memory for this object(always when we create new object)
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
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
            return new AddRegistrationViewModel(_navigationStore, _platform, CreateRegistrationViewModel);
        }

        private RegistrationListingViewModel CreateRegistrationViewModel()
        {
            return new RegistrationListingViewModel(_navigationStore, _platform, CreateAddRegistrationViewModel);
        }
    }
}
