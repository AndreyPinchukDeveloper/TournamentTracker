using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameProgressTracker.Commands
{
    class DeleteRegistrationCommand : AsyncCommandBase
    {
        private readonly GamesStore _gameStore;
        private readonly AddRegistrationViewModel _addRegistrationViewModel;
        private readonly Registration _registration;
        private readonly RegistrationViewModel _registrationViewModel;
        

        public DeleteRegistrationCommand(Registration registration, AddRegistrationViewModel addRegistrationViewModel, GamesStore gameStore)
        {
            _registration = registration;
            _gameStore = gameStore;
            _addRegistrationViewModel = addRegistrationViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var selectedItem = myDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                myDataGrid.Items.Remove(selectedItem);
            }
        }
    }
}
