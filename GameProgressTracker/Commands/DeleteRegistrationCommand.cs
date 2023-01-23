using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameProgressTracker.Commands
{
    class DeleteRegistrationCommand : AsyncCommandBase
    {
        private readonly RegistrationListingViewModel _viewModel;
        private readonly GamesStore _gameStore;
        private AddRegistrationViewModel _registrationViewModelToDelete;
        private ObservableCollection<RegistrationViewModel> _registration;//NULL

        public DeleteRegistrationCommand(ObservableCollection<RegistrationViewModel> registration, RegistrationListingViewModel viewModel, GamesStore gameStore)
        {
            _registration = registration;//NULL
            _viewModel = viewModel;
            _gameStore = gameStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            GetOneRegistration(_gameStore.Registration);

            Registration registration = new Registration(
                _registrationViewModelToDelete.NameOfPlatform,
                _registrationViewModelToDelete.GameID,
                _registrationViewModelToDelete.CurrentGame,
                _registrationViewModelToDelete.StartTime,
                _registrationViewModelToDelete.EndTime);

            _gameStore.DeleteRegistration(registration);-
            //_viewModel.UpdateRegistrations(_gameStore.Registration);
        }

        public void GetOneRegistration(IEnumerable<Registration> registrations)
        {
            //_registration.Clear();

            foreach (Registration registration in registrations)
            {
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                return;
            }
        }
    }
}
