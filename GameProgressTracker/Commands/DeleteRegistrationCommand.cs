using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameProgressTracker.Commands
{
    class DeleteRegistrationCommand : AsyncCommandBase
    {
        private readonly RegistrationViewModel _registrationViewModel;//NULL
        private ObservableCollection<RegistrationViewModel> _registration;//NULL

        public DeleteRegistrationCommand(ObservableCollection<RegistrationViewModel> registration)
        {
            _registration = registration;//NULL
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _registration.Remove(_registrationViewModel);
        }
    }
}
