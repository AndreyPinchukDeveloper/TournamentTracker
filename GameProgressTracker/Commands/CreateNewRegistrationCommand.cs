﻿using GameProgressTracker.Commands.Base;
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
    public class CreateNewRegistrationCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Game _game;

        public CreateNewRegistrationCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            //_navigationStore.CurrentViewModel = new RegistrationListingViewModel(_navigationStore, _game);
        }
    }
}
