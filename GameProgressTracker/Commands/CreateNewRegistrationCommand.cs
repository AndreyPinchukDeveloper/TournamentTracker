using GameProgressTracker.Commands.Base;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Commands
{
    internal class CreateNewRegistrationCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public CreateNewRegistrationCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new RegistrationListingViewModel(_navigationStore);
        }
    }
}
