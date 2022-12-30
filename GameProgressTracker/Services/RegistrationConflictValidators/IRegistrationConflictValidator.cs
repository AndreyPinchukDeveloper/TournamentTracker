using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.RegistrationConflictValidators
{
    public interface IRegistrationConflictValidator
    {
        Task<bool> DoesCauseConflict(Registration registration);
    }
}
