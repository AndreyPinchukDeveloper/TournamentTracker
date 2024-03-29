﻿using GameProgressTracker.DbContexts;
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

        public async Task<Registration> GetConflictingRegistration(Registration registration)
        {
            using(AppDbContext context = _dbContextFactory.CreateDbContext()) 
            {
                RegistrationDTO registrationDTO = await context.Registrations
                    .Where(r => r.NameOfPlatform == registration.NameOfPlatform)
                    .Where(r => r.NameOfGame == registration.NameOfGame)
                    .Where(r => r.GameID == registration.GameID)
                    .Where(r => r.StartTime == registration.StartTime)
                    .Where(r => r.EndTime == registration.EndTime)
                    .FirstOrDefaultAsync();

                if (registrationDTO == null)
                {
                    return null;
                }

                return ToRegistration(registrationDTO);
            }
        }

        private static Registration ToRegistration(RegistrationDTO r)
        {
            return new Registration(r.NameOfPlatform, r.GameID,r.NameOfGame,r.StartTime,r.EndTime);
        }
    }
}
