﻿using GameProgressTracker.DbContexts;
using GameProgressTracker.DTOs;
using GameProgressTracker.Models;
using System.Threading.Tasks;

namespace GameProgressTracker.Services.RegistrationCreator
{
    public class DBRegistrationCreator : IRegistrationCreator
    {
        private readonly AppDbContextFactory _dbContextFactory;

        public DBRegistrationCreator(AppDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateRegistration(Registration registration)
        {
            using(AppDbContext context = _dbContextFactory.CreateDbContext()) 
            {
                RegistrationDTO registrationDTO = ToRegistrationDTO(registration);
                context.Registrations.Add(registrationDTO);
                await context.SaveChangesAsync();
            }
        }

        private static RegistrationDTO ToRegistrationDTO(Registration r)
        {
            return new RegistrationDTO()
            {
                NameOfPlatform= r.NameOfPlatform,
                GameID= r.GameID,
                NameOfGame = r.NameOfGame,
                StartTime= r.StartTime,
                EndTime= r.EndTime
            };
        }
    }
}
