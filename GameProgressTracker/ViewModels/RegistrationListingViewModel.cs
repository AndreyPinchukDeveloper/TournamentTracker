﻿using GameProgressTracker.Commands;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameProgressTracker.ViewModels
{
    public class RegistrationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registration;//we don't use Registration class as observable because we nedd class which implement INotifyPropertyChanged
        private readonly GamesStore _gameStore;
        public IEnumerable<RegistrationViewModel> Registration => _registration;
        public AddRegistrationViewModel AddRegistrationViewModel { get; }

        #region Properties
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); OnPropertyChanged(nameof(HasErrorMessage)); }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        #endregion

        #region Commands
        public ICommand LoadRegistrationCommand { get; }
        public ICommand AddButtonCommand { get; }
        #endregion

        public RegistrationListingViewModel(
            GamesStore gameStore, 
            AddRegistrationViewModel addRegistrationViewModel, 
            NavigationService navigationService)
        {
            _gameStore = gameStore;
            _registration = new ObservableCollection<RegistrationViewModel>();
            AddRegistrationViewModel = addRegistrationViewModel;
            
            LoadRegistrationCommand = new LoadRegistrationsCommand(this, gameStore);
            AddButtonCommand = new NavigateCommand(navigationService);
            _gameStore.MadeRegistration += OnRegistrationMade;
        }

        public override void Dispose()
        {
            _gameStore.MadeRegistration -= OnRegistrationMade;
            base.Dispose();
        }

        private void OnRegistrationMade(Registration registration)
        {
            RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
            _registration.Add(registrationViewModel);
        }

        public static RegistrationListingViewModel LoadViewModel(
            GamesStore appStore, 
            NavigationService makeRegistrationNavigationService,
            AddRegistrationViewModel addRegistrationViewModel)
        {
            RegistrationListingViewModel viewModel = new RegistrationListingViewModel(appStore, addRegistrationViewModel, makeRegistrationNavigationService);

            viewModel.LoadRegistrationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateRegistrations(IEnumerable<Registration> registrations)
        {
            _registration.Clear();

            foreach (Registration registration in registrations) 
            { 
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                _registration.Add(registrationViewModel);
            }
        }
    }
}
