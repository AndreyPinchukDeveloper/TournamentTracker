using GameProgressTracker.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    class Progress
    {
        private readonly List<Registration> _gameToRegistration;

        public Progress()
        {
            _gameToRegistration = new List<Registration>();
        }

        public IEnumerable<Registration> GetRegistrationsForUser(string games)
        {
            return _gameToRegistration.Where(g => g.NameOfGame == games);
        }

        public void AddRegistration(Registration registration) 
        {
            foreach (Registration existingRegistration in _gameToRegistration)
            {
                if (existingRegistration.Conflicts(registration))
                {
                    throw new RegistrationConflictException(existingRegistration, registration);
                }
            }

            _gameToRegistration.Add(registration);
        }
    }
}
