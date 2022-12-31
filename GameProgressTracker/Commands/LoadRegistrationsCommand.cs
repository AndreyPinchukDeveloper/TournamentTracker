using GameProgressTracker.Commands.Base;
using GameProgressTracker.Models;
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
        private readonly GamePlatform _gamePlatform;

        public LoadRegistrationsCommand(RegistrationListingViewModel viewModel, GamePlatform gamePlatform)
        {
            _viewModel = viewModel;
            _gamePlatform = gamePlatform;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<Registration> registrations = await _gamePlatform.GetAllRegistrations();
                _viewModel.UpdateRegistrations(registrations);
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to load registration.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
