using GameProgressTracker.Commands.Base;
using GameProgressTracker.Models;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Commands
{
    /// <summary>
    /// The main class for navigate(switch) between windows
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class NavigateCommand<TViewModel> : CommandBase 
        where TViewModel : ViewModelBase

    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
