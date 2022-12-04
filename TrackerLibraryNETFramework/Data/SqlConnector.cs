using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibraryNETFramework.Models;

namespace TrackerLibraryNETFramework.Data
{
    public class SqlConnector : IDataConnection
    {
        // TODO - Male the createPrize method actually save to the database

        

        /// <summary>
        /// Save a new prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information incliding the unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;
            return model;
        }
    }
}
