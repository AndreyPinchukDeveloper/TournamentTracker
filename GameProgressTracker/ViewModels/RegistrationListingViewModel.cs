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
using System.Windows.Input;

namespace GameProgressTracker.ViewModels
{
    public class RegistrationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registration;//we don't use Registration class as observable                                                                          //because we nedd class which implement INotifyPropertyChanged

        public IEnumerable<RegistrationViewModel> Registration => _registration;
        public AddRegistrationViewModel AddRegistrationViewModel;

        #region Commands
        public ICommand LoadRegistrationCommand { get; }
        public ICommand AddButtonCommand { get; }
        #endregion

        public RegistrationListingViewModel(GamesStore appStore, NavigationService navigationService)
        {
            _registration = new ObservableCollection<RegistrationViewModel>();

            LoadRegistrationCommand = new LoadRegistrationsCommand(this, appStore);
            AddButtonCommand = new NavigateCommand(navigationService);
        }

        public static RegistrationListingViewModel LoadViewModel(GamesStore appStore, NavigationService makeRegistrationNavigationService)
        {
            RegistrationListingViewModel viewModel = new RegistrationListingViewModel(appStore, makeRegistrationNavigationService);

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
