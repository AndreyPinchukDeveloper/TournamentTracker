using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Exceptions
{
    class RegistrationConflictException : Exception
    {
        public Registration ExistingRegistration { get; }
        public Registration IncomingRegistration { get; }

        public RegistrationConflictException(Registration existingRegistration, Registration incomingRegistration)
        {
            ExistingRegistration = existingRegistration;
            IncomingRegistration = incomingRegistration;
        }

        public RegistrationConflictException(Registration existingRegistration, Registration incomingRegistration, string? message) : base(message)
        {
            ExistingRegistration = existingRegistration;
            IncomingRegistration = incomingRegistration;
        }

        public RegistrationConflictException(string? message, Exception? innerException, Registration existingRegistration, Registration incomingRegistration) : base(message, innerException)
        {
            ExistingRegistration = existingRegistration;
            IncomingRegistration = incomingRegistration;
        }

        
    }
}
