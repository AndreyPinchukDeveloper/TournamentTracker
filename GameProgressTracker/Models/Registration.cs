using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    public class Registration
    {
        public string GameId { get;}
        public string NameOfPlatform { get; }
        public string NameOfGame { get;} 
        public DateTime StartTime { get;}
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Registration(string nameOfPlatform, string gameID, string nameOfGame, DateTime startTime, DateTime endTime)
        {
            NameOfPlatform = nameOfPlatform;
            GameId = gameID;
            NameOfGame = nameOfGame;
            StartTime = startTime;  
            EndTime = endTime;
        }
    }
}
