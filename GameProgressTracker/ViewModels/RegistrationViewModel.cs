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

        public string NumberInColumn { get; }
        public string NameOfGame { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }

        public RegistrationViewModel(Registration registration)
        {
            _registration = registration;
        }
    }
}
