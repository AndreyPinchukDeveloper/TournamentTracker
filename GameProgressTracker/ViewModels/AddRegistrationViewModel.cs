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

        private DateTime _startTime = new DateTime(2023, 1, 1);
		public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime _endTime = new DateTime(2023, 1, 1);
  
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _proretyNameToErrorsDictionary.Remove(nameof(EndTime));

                if (EndTime<StartTime)
                {
                    List<string> endDataErrors = new List<string>()
                    {
                        "The end date can't be before start date."
                    };
                    _proretyNameToErrorsDictionary.Add(nameof(EndTime), endDataErrors);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(nameof(EndTime)));
                }

                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }
        #endregion

        public ICommand SubmitButtonCommand { get; }
        public ICommand CancelButtonCommand { get; }

        private readonly Dictionary<string, List<string>> _proretyNameToErrorsDictionary;

        public bool HasErrors => _proretyNameToErrorsDictionary.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;//when we add error we call this event

        public AddRegistrationViewModel(GamesStore gameStore, NavigationService navigationService)
        {
            SubmitButtonCommand = new AddRegistrationCommand(this, gameStore, navigationService);
            CancelButtonCommand = new NavigateCommand(navigationService);
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _proretyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<string>());
        }
    }
}
