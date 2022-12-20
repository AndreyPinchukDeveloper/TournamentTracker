using GameProgressTracker.Models;
using GameProgressTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(GamePlatform platform)
        {
            //CurrentViewModel = new RegistrationListingViewModel(platform);
            CurrentViewModel = new RegistrationListingViewModel();
        }
    }
}
