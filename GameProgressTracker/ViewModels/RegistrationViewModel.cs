using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.ViewModels
{
    public class RegistrationViewModel:ViewModelBase
    {
        private readonly Registration _registration;

        public string NumberInColumn => _registration.GameId?.ToString();
        public string NameOfGame => _registration.NameOfGame;
        public string StartTime => _registration.StartTime.ToString("d");
        public string EndTime => _registration.EndTime.ToString("d");

        public RegistrationViewModel(Registration registration)
        {
            _registration = registration;
        }
    }
}
