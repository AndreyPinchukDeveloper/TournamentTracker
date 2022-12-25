using GameProgressTracker.Commands.Base;
using GameProgressTracker.Models;
using GameProgressTracker.Services;
using GameProgressTracker.Stores;
using GameProgressTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Commands
{
    public class CancelAddRegistrationCommand : CommandBase
    {
        /*private readonly NavigationStore _navigationStore;
        private readonly GamePlatform _platform;

        public CancelAddRegistrationCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new RegistrationListingViewModel(_navigationStore, _platform);
        }*/

        private readonly NavigationService<AddRegistrationViewModel> _navigationService;
        public CancelAddRegistrationCommand(NavigationService<AddRegistrationViewModel> navigationServices)
        {
            _navigationService = navigationServices;
        }
        new NavigateCommand<RegistrationListingViewModel>(navigationStore, () => new RegistrationListingViewModel(navigationStore, platform));
    }
}
