using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Stores
{
    /// <summary>
    /// This class is store current view model for application
    /// </summary>
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set 
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                OnCurrentViewModelChanged(); 
            } 
        }

        /// <summary>
        /// This method invoke method given from another class by using delegate 
        /// </summary>
        private void OnCurrentViewModelChanged() 
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
