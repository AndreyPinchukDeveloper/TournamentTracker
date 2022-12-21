using GameProgressTracker.Commands;
using GameProgressTracker.Models;
using GameProgressTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameProgressTracker.ViewModels
{
    public class RegistrationListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<RegistrationViewModel> _registration;//we don't use Registration class as observable
                                                                                   //because we nedd class which implement INotifyPropertyChanged

        public IEnumerable<RegistrationViewModel> Registration => _registration;

        #region Commands
        public ICommand AddNewGameButtonCommand { get;}
        #endregion

        public RegistrationListingViewModel(NavigationStore navigationStore)
        {
            _registration = new ObservableCollection<RegistrationViewModel>();

            AddNewGameButtonCommand = new NavigateCommand(navigationStore);

            _registration.Add(new RegistrationViewModel(new Registration(new GameID("SEGA"), "Phantasy Star", DateTime.Now, DateTime.Now)));
            _registration.Add(new RegistrationViewModel(new Registration(new GameID("SEGA"), "Phantasy Star", DateTime.Now, DateTime.Now)));
            _registration.Add(new RegistrationViewModel(new Registration(new GameID("SEGA"), "Phantasy Star", DateTime.Now, DateTime.Now)));

            AddNewGameButtonCommand = new CreateNewRigistrationViewModel();
        }
    }
}
