using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Stores
{
    /// <summary>
    /// This class need us to load and show all registration from db to UI 
    /// </summary>
    public class GamesStore
    {
        private readonly Game _game;
        private readonly List<Registration> _registration; 
        private readonly Lazy<Task> _initializeLazy;//Lazy class is our guarantee that class creates only once

        public IEnumerable<Registration> Registration => _registration;

        public GamesStore(Game game)
        {
            _game = game;
            _initializeLazy = new Lazy<Task>(Initialize());

            _registration = new List<Registration>();
        }

        public async Task Load()
        {
            await _initializeLazy.Value;//value is our task
        }

        public async Task MakeRegistration(Registration registration)
        {
            await _game.MakeRegistration(registration);
            _registration.Add(registration);
        }

        public async Task Initialize()
        {
            IEnumerable<Registration> registrations = await _game.GetAllRegistrations();

            _registration.Clear();
            _registration.AddRange(registrations);
        }
    }
}
