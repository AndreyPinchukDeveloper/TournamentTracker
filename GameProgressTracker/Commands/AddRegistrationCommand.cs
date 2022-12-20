using GameProgressTracker.Commands.Base;
using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameProgressTracker.Commands
{
    public class AddRegistrationCommand : CommandBase
    {
        private readonly GamePlatform _platform;
        private readonly AddRegistrationViewModel _addRegistrationViewModel;

        public AddRegistrationCommand(AddRegistrationViewModel addRegistrationViewModel, GamePlatform platform)
        {
            _platform = platform;
            _addRegistrationViewModel = addRegistrationViewModel;

            _addRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)//if the field for current game is empty - the button submit is untouchable
        {
            return !string.IsNullOrEmpty(_addRegistrationViewModel.CurrentGame) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Registration registration = new Registration(
            new GameID("Dark Souls"),
            _addRegistrationViewModel.CurrentGame,
            _addRegistrationViewModel.StartTime,
            _addRegistrationViewModel.EndTime
            );

            try
            {
                _platform.MakeRegistration(registration);

                MessageBox.Show("The job has done, my lord.", "Succes",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (RegistrationConflictException)
            {
                MessageBox.Show("You have already added that game later, idiot.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// This method unlock the Submit button when user enter name of game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddRegistrationViewModel.CurrentGame))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
