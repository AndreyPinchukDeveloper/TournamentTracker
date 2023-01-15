using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProgressTracker.Stores
{
    /// <summary>
    /// This class need us to load and show all registration(existing data) from db to UI
    /// </summary>
    public class GamesStore
    {
        private readonly Game _game;
        private readonly List<Registration> _registration; 
        private Lazy<Task> _initializeLazy;//Lazy class is our guarantee that class creates only once

        public IEnumerable<Registration> Registration => _registration;
        public event Action<Registration> MadeRegistration;

        public GamesStore(Game game)
        {
            _game = game;
            _registration = new List<Registration>();
            _initializeLazy = new Lazy<Task>(Initialize());
            

        }

        public async Task Load()//load all data from db
        {
            try
            {
                await _initializeLazy.Value;//value is our task
            }
            catch (Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize());
                throw;
            }            
        }

        public async Task MakeRegistration(Registration registration)
        {
            await _game.MakeRegistration(registration);
            _registration.Add(registration);
            OnRegistrationMade(registration);
        }

        public async Task DeleteRegistration(Registration registration)
        {
            await _game.DeleteRegistration(registration);
            _registration.Remove(registration);
            OnRegistrationMade(registration);
        }

        private void OnRegistrationMade(Registration registration)
        {
            MadeRegistration?.Invoke(registration);
        }

        public async Task Initialize()
        {
            IEnumerable<Registration> registrations = await _game.GetAllRegistrations();

            _registration.Clear();
            _registration.AddRange(registrations);
        }
    }
}
