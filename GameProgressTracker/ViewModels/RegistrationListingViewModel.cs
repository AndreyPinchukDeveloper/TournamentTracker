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
        private readonly ObservableCollection<RegistrationViewModel> _registration;//we don't use Registration class as observable
        private readonly GamePlatform _gamePlatform;                                                                           //because we nedd class which implement INotifyPropertyChanged

        public IEnumerable<RegistrationViewModel> Registration => _registration;

        #region Commands
        public ICommand AddButtonCommand { get;}
        #endregion

        public RegistrationListingViewModel(GamePlatform gamePlatform, NavigationService navigationService)
        {
            _gamePlatform = gamePlatform;
            _registration = new ObservableCollection<RegistrationViewModel>();

            AddButtonCommand = new NavigateCommand(navigationService);

            UpdateRegistrations();
        }

        private void UpdateRegistrations()
        {
            _registration.Clear();

            foreach (Registration registration in _gamePlatform.GetAllRegistrations()) 
            { 
                RegistrationViewModel registrationViewModel = new RegistrationViewModel(registration);
                _registration.Add(registrationViewModel);
            }
        }
    }
}
