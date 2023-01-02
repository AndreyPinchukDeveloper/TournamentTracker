using GameProgressTracker.DbContexts;
using GameProgressTracker.DTOs;
using GameProgressTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly AppDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(AppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrations()
        {
            using(AppDbContext context = _dbContextFactory.CreateDbContext()) 
            {
                IEnumerable<RegistrationDTO> registrationDTOs = await context.Registrations.ToListAsync();
                return registrationDTOs.Select(r => ToRegistration(r));
            }
        }

        private static Registration ToRegistration(RegistrationDTO r)
        {
            return new Registration(
                    r.NameOfPlatform,
                    r.GameID,
                    r.NameOfGame,
                    r.StartTime,
                    r.EndTime);
        }
    }
}
