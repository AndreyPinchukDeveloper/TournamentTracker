using GameProgressTracker.Commands;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; 

namespace GameProgressTracker.ViewModels
{
    public class AddRegistrationViewModel : ViewModelBase
    {
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
            }
        }

        #region Commands
        public ICommand SubmitButtonCommand { get; }
        public ICommand CancelButtonCommand { get; }
        #endregion

        public AddRegistrationViewModel(GamesStore gameStore, NavigationService navigationService)
        {
            SubmitButtonCommand = new AddRegistrationCommand(this, gameStore, navigationService);
            CancelButtonCommand = new NavigateCommand(navigationService);
        }
    }
}
