using GameProgressTracker.Commands;
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
            get { return _gameID; }
            set { _gameID = value; OnPropertyChanged(nameof(GameID)); }
        }


        private string _nameOfPlatform;
		public string NameOfPlatform
		{
			get { return _nameOfPlatform; }
			set 
			{
				_nameOfPlatform = value;
               OnPropertyChanged(nameof(NameOfPlatform)); //nameof return not value but only name of object
			}
		}

        private string _currentGame;
        public string CurrentGame
        {
            get { return _currentGame; }
            set
            {
                _currentGame = value;
                OnPropertyChanged(nameof(CurrentGame));
            }
        }

        private DateTime _startTime;
		public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
                ClearErrors(nameof(StartTime));
                ClearErrors(nameof(EndTime));

                if (EndTime < StartTime)
                {
                    AddError("The start date can't be after end date.", nameof(StartTime));
                    OnErrorsChanged(nameof(StartTime));
                }
            }
        }

        private DateTime _endTime;
  
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
                ClearErrors(nameof(StartTime));
                ClearErrors(nameof(EndTime));               

                if (EndTime < StartTime)
                {
                    AddError("The end date can't be before start date.", nameof(EndTime));                    
                    OnErrorsChanged(nameof(EndTime));                   
                }
            }
        }

        #endregion

        public ICommand SubmitButtonCommand { get; }
        public ICommand CancelButtonCommand { get; }

        private readonly Dictionary<string, List<string>> _propetyNameToErrorsDictionary = new Dictionary<string, List<string>>();

        public bool HasErrors => _propetyNameToErrorsDictionary.Any();// The Any() method is cheking if there are existing alements

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;//when we add error we call this event

        public AddRegistrationViewModel(GamesStore gameStore, NavigationService navigationService)
        {
            SubmitButtonCommand = new AddRegistrationCommand(this, gameStore, navigationService);
            CancelButtonCommand = new NavigateCommand(navigationService);
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
