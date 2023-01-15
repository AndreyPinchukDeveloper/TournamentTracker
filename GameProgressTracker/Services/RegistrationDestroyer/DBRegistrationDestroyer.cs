using GameProgressTracker.DbContexts;
using GameProgressTracker.DTOs;
using GameProgressTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.RegistrationDestroyer
{
    class DBRegistrationDestroyer : IRegistrationDestroyer
    {
        private readonly AppDbContextFactory _dbContextFactory;

        public DBRegistrationDestroyer(AppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task DeleteRegistration(Registration registration)
        {
            using (AppDbContext context = _dbContextFactory.CreateDbContext())
            {
                RegistrationDTO registrationDTO = ToRegistrationDTO(registration);
                context.Registrations.ExecuteDelete();
                await context.SaveChangesAsync();
            }
        }

        private static RegistrationDTO ToRegistrationDTO(Registration r)
        {
            return new RegistrationDTO()
            {
                NameOfPlatform = r.NameOfPlatform,
                GameID = r.GameID,
                NameOfGame = r.NameOfGame,
                StartTime = r.StartTime,
                EndTime = r.EndTime
            };
        }
    }
}
