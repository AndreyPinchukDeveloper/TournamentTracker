﻿using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace GameProgressTracker.Commands
{
    public class AddRegistrationCommand : AsyncCommandBase
    {
        private readonly GamesStore _gameStore;
        private readonly NavigationService<RegistrationListingViewModel> _navigationService;
        private readonly AddRegistrationViewModel _addRegistrationViewModel;

        public AddRegistrationCommand(
            AddRegistrationViewModel addRegistrationViewModel, 
            GamesStore gameStore, 
            NavigationService<RegistrationListingViewModel> navigationService)
        {
            _gameStore = gameStore;
            _navigationService = navigationService;
            _addRegistrationViewModel = addRegistrationViewModel;

            _addRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)//if the field for current game is empty - the button submit is untouchable
        {
            return !string.IsNullOrEmpty(_addRegistrationViewModel.CurrentGame) && base.CanExecute(parameter);
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
                await _gameStore.MakeRegistration(registration);

                MessageBox.Show("The job has done, my lord.", "Succes",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (RegistrationConflictException)
            {
                MessageBox.Show("You have already added that game later, idiot.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to make registration.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// This method unlock the Submit button when user enter name of game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddRegistrationViewModel.CurrentGame))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
