using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    public class Game
    {
        private readonly Progress _progress;
        public Game(Progress progress)
        {
            _progress = progress;
        }

        /// <summary>
        /// Get the registration for user
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Registration>> GetAllRegistrations() 
        {
            return await _progress.GetAllRegistrations();
        }

        /// <summary>
        /// Make a registration for new game
        /// </summary>
        /// <param name="registration"></param>
        public async Task MakeRegistration(Registration registration) 
        {
            await _progress.AddRegistration(registration);
        }
    }
}
