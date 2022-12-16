using GameProgressTracker.Exceptions;
using GameProgressTracker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GameProgressTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            GamePlatform platform = new GamePlatform("SEGA");

            try
            {
                platform.MakeRegistration(new Registration(
                                new GameID("PhantasyStar"),
                                "Phantasy Star",
                                new DateTime(2022, 12, 12),
                                new DateTime(2022, 12, 13)));
            }
            catch (RegistrationConflictException exception)
            {

            }

            

            IEnumerable<Registration> registrations = platform.GetRegistrationForUser("Andre");

            base.OnStartup(e);
        }
    }
}
