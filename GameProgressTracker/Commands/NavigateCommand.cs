using GameProgressTracker.Commands.Base;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;

namespace GameProgressTracker.Commands
{
    /// <summary>
    /// The main class for navigate(switch) between windows
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
