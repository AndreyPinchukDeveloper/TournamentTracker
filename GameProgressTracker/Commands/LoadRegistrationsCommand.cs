using GameProgressTracker.Commands.Base;
using GameProgressTracker.Models;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameProgressTracker.Commands
{
    public class LoadRegistrationsCommand : AsyncCommandBase
    {
        private readonly RegistrationListingViewModel _viewModel;
        private readonly GamesStore _appStore;

        public LoadRegistrationsCommand(RegistrationListingViewModel viewModel, GamesStore appStore)
        {
            _viewModel = viewModel;
            _appStore = appStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _appStore.Load();
                _viewModel.UpdateRegistrations(_appStore.Registration);
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to load registration.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
