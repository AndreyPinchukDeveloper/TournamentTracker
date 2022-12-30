using GameProgressTracker.DbContexts;
using GameProgressTracker.DTOs;
using GameProgressTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.RegistrationConflictValidators
{
    public class DBRegistrationConflictValidator : IRegistrationConflictValidator
    {
        private readonly AppDbContextFactory _dbContextFactory;

        public DBRegistrationConflictValidator(AppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> DoesCauseConflict(Registration registration)
        {
            using(AppDbContext context = _dbContextFactory.CreateDbContext()) 
            {
                return await context.Registrations.Select(r => ToRegistration(r)).AnyAsync(r => r.Conflicts(registration));
            }
        }

        private object ToRegistration(RegistrationDTO r)
        {
            throw new NotImplementedException();
        }
    }
}
