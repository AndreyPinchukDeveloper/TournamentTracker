using GameProgressTracker.Commands;
using GameProgressTracker.Commands.Base;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 

namespace GameProgressTracker.ViewModels
{
    public class AddRegistrationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        #region Fields
        private string _gameID;

        public string GameID
        {
            get => _gameID;
            set => Set(ref _gameID, value);
        }

        private string _nameOfPlatform;
		public string NameOfPlatform
		{
			get => _nameOfPlatform;
			set => Set(ref _nameOfPlatform, value);
		}

        private string _currentGame;
        public string CurrentGame
        {
            get => _currentGame;
            set => Set(ref _currentGame, value);
        }

        private DateTime _startTime;
		public DateTime StartTime
        {
            get => _startTime;
            set
            {
                Set(ref _startTime, value);
                ClearErrors(nameof(StartTime));
                ClearErrors(nameof(EndTime));

                if (EndTime < StartTime)
                {
                    AddError("The start date can't be after end date.", nameof(StartTime));
                }
            }
        }

        private DateTime _endTime;
  
        public DateTime EndTime
        {
            get => _endTime;
            set
            {
                Set(ref _endTime, value);
                ClearErrors(nameof(StartTime));
                ClearErrors(nameof(EndTime));               

                if (EndTime < StartTime)
                {
                    AddError("The end date can't be before start date.", nameof(EndTime));            
                }
            }
        }

        #endregion

        public ICommand SubmitButtonCommand { get; }
        public ICommand CancelButtonCommand { get; }

        private readonly Dictionary<string, List<string>> _propetyNameToErrorsDictionary = new Dictionary<string, List<string>>();

        public bool HasErrors => _propetyNameToErrorsDictionary.Any();// The Any() method is cheking if there are existing alements

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;//when we add error we call this event

        public AddRegistrationViewModel(GamesStore gameStore, NavigationService<RegistrationListingViewModel> navigationService)
        {
            SubmitButtonCommand = new AddGameAndNavigateCommand<RegistrationListingViewModel>(navigationService, gameStore, this);
            CancelButtonCommand = new NavigateCommand<RegistrationListingViewModel>(navigationService);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propetyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propetyNameToErrorsDictionary.ContainsKey(propertyName))
            {
                _propetyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }
            _propetyNameToErrorsDictionary[propertyName].Add(errorMessage);

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propetyNameToErrorsDictionary.Remove(propertyName);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
             ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(propertyName)));
        }
    }
}
