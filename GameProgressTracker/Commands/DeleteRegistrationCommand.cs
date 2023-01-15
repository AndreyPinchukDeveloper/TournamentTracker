using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
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
    class DeleteRegistrationCommand : AsyncCommandBase
    {
        private readonly GamesStore _gameStore;
        private readonly AddRegistrationViewModel _addRegistrationViewModel;

        public DeleteRegistrationCommand(AddRegistrationViewModel addRegistrationViewModel, GamesStore gameStore)
        {
            _gameStore = gameStore;
            _addRegistrationViewModel = addRegistrationViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Registration registration = new Registration(
            _addRegistrationViewModel.NameOfPlatform,
            _addRegistrationViewModel.GameID,
            _addRegistrationViewModel.CurrentGame,
            _addRegistrationViewModel.StartTime,
            _addRegistrationViewModel.EndTime
            );

            try
            {
                await _gameStore.DeleteRegistration(registration);

                MessageBox.Show("The job has done, my lord.", "Succes",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to delete registration.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
