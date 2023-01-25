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
        private RegistrationViewModel _registrationViewModelToDelete;
        private ObservableCollection<RegistrationViewModel> _registration;//NULL
        private readonly RegistrationListingViewModel _registrationListingViewModel;

        public DeleteRegistrationCommand(ObservableCollection<RegistrationViewModel> registration, RegistrationListingViewModel viewModel, GamesStore gameStore)
        {
            _registration = registration;
            _viewModel = viewModel;
            _gameStore = gameStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            GetOneRegistration(_gameStore.Registration);

            Registration registration = new Registration(
                _registrationViewModelToDelete.NameOfPlatform,
                _registrationViewModelToDelete.NumberInColumn,
                _registrationViewModelToDelete.NameOfGame,
                _registrationViewModelToDelete.StartTime,
                _registrationViewModelToDelete.EndTime);

            _gameStore.DeleteRegistration(registration);
            //_registrationListingViewModel.UpdateRegistrations(_gameStore.Registration);
        }

        public void GetOneRegistration(IEnumerable<Registration> registrations)
        {

            foreach (Registration registration in registrations)
            {
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                _registrationViewModelToDelete = registrationViewModel;
                return;
            }

            
        }
    }
}
