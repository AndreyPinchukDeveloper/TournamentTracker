using GameProgressTracker.Commands;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GameProgressTracker.ViewModels
{
    public class RegistrationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registration;//we don't use Registration class as observable because we nedd class which implement INotifyPropertyChanged
        private readonly GamesStore _gameStore;
        private readonly RegistrationViewModel registrationView;
        public IEnumerable<RegistrationViewModel> Registration => _registration;//all registrations
        public AddRegistrationViewModel AddRegistrationViewModel { get; }

        #region Properties
        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set { Set(ref _errorMessage, value); OnPropertyChanged(nameof(HasErrorMessage)); }
        }
        
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        #endregion

        #region Commands
        public ICommand LoadRegistrationCommand { get; }
        public ICommand AddButtonCommand { get; }

        public ICommand DeleteRowCommand { get; }
        #endregion

        public RegistrationListingViewModel(GamesStore gameStore, NavigationService<AddRegistrationViewModel> navigationService)
        {
            _gameStore = gameStore;
            _registration = new ObservableCollection<RegistrationViewModel>();

            LoadRegistrationCommand = new LoadRegistrationsCommand(this, gameStore);
            AddButtonCommand = new NavigateCommand<AddRegistrationViewModel>(navigationService);
            DeleteRowCommand = new DeleteRegistrationCommand(_registration, this, gameStore);
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

        public static RegistrationListingViewModel LoadViewModel(GamesStore appStore, NavigationService<AddRegistrationViewModel> makeRegistrationNavigationService)
        {
            RegistrationListingViewModel viewModel = new RegistrationListingViewModel(appStore, makeRegistrationNavigationService);

            viewModel.LoadRegistrationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateRegistrations(IEnumerable<Registration> registrations)
        {
            _registration.Clear();

            try
            {
                foreach (Registration registration in registrations)
                {
                    RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                    _registration.Add(registrationViewModel);
                }
            }

            catch (Exception)
            {

                MessageBox.Show("null");
            }
        }    
    }
}
