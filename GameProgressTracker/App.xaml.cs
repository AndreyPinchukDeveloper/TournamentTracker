using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
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
        public App()
        {
            _platform = new GamePlatform("PC");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_platform)
            };
            MainWindow.Show();

            base.OnStartup(e);

        }
    }
}
