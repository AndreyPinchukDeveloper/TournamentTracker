using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Models
{
    class GamePlatform
    {
        private readonly Progress _progress;
        public string Name { get; set; }
        public GamePlatform(string name)
        {
            Name = name;
            _progress = new Progress();
        }

        /// <summary>
        /// Get the registration for user
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Registration> GetRegistrationForUser(string name) 
        {
            return _progress.GetRegistrationsForUser(name);
        }

        /// <summary>
        /// Make a registration for new game
        /// </summary>
        /// <param name="registration"></param>
        public void MakeRegistration(Registration registration) 
        {
            _progress.AddRegistration(registration);
        }
    }
}
