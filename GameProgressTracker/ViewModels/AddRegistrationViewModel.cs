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
		private string _currentPlatform;//use list of latforms instead
		public string CurrentPlatform
		{
			get { return _currentPlatform; }
			set 
			{
				_currentPlatform = value;
               OnPropertyChanged(nameof(CurrentPlatform)); //nameof return not value but only name of object
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

        public AddRegistrationViewModel()
        {

        }
    }
}
