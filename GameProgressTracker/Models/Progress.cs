using GameProgressTracker.Exceptions;
using GameProgressTracker.Services.RegistrationConflictValidators;
using GameProgressTracker.Services.RegistrationCreator;
using GameProgressTracker.Services.RegistrationDestroyer;
using GameProgressTracker.Services.ReservationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    /// <summary>
    /// Hold all registrations
    /// </summary>
    public class Progress
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IRegistrationCreator _registrationCreator;
        private readonly IRegistrationDestroyer _registrationDestroyer;
        private readonly IRegistrationConflictValidator _registrationConflictValidator;

        public Progress(IReservationProvider reservationProvider, IRegistrationCreator registrationCreator, IRegistrationConflictValidator registrationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _registrationCreator = registrationCreator;
            _registrationConflictValidator = registrationConflictValidator;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrations()
        {
            return await _reservationProvider.GetAllRegistrations();
        }

        public async Task AddRegistration(Registration registration) 
        {
            Registration conflictRegistration = await _registrationConflictValidator.GetConflictingRegistration(registration);

            if (conflictRegistration != null)
            {
                throw new RegistrationConflictException(conflictRegistration, registration);
            }

            await _registrationCreator.CreateRegistration(registration);
        }

        public async Task DeleteRegistration(Registration registration)
        {

            await _registrationDestroyer.DeleteRegistration(registration);
        }
    }
}
