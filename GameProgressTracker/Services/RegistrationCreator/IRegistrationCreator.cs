using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.RegistrationCreator
{
    public interface IRegistrationCreator
    {
        Task CreateRegistration(Registration registration);
    }
}
