using GameProgressTracker.Models;
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

        #region Commands
        public ICommand AddButtonCommands { get;}
        #endregion

        public RegistrationListingViewModel()
        {
            _registration= new ObservableCollection<RegistrationViewModel>();
        }
    }
}
