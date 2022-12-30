using GameProgressTracker.Exceptions;
using GameProgressTracker.Services.RegistrationCreator;
using GameProgressTracker.Services.ReservationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    public class Progress
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IRegistrationCreator _registrationCreator;

        public Progress(IReservationProvider reservationProvider, IRegistrationCreator registrationCreator)
        {
            _reservationProvider = reservationProvider;
            _registrationCreator = registrationCreator;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrations()
        {
            return await _reservationProvider.GetAllRegistrations();
        }

        public async Task AddRegistration(Registration registration) 
        {
            foreach (Registration existingRegistration in _gameToRegistration)
            {
                if (existingRegistration.Conflicts(registration))
                {
                    throw new RegistrationConflictException(existingRegistration, registration);
                }
            }

            await _registrationCreator.CreateRegistration(registration);
        }
    }
}
