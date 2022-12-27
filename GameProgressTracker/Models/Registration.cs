﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    public class Registration
    {
        public string GameId { get;}
        public string NameOfGame { get;} 
        public DateTime StartTime { get;}
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Registration(string gameID, string nameOfGame, DateTime startTime, DateTime endTime)
        {
            GameId = gameID;
            NameOfGame = nameOfGame;
            StartTime = startTime;  
            EndTime = endTime;
        }

        internal bool Conflicts(Registration registration)
        {
            if (registration.GameId != GameId)
            {
                return false;
            }

            return registration.StartTime < EndTime && registration.EndTime > StartTime;
        }
    }
}
