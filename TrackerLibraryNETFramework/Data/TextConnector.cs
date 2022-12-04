using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibraryNETFramework.Models;

namespace TrackerLibraryNETFramework.Data
{
    public class TextConnector : IDataConnection
    {
        // TODO - wire up the createPrize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.Id = 1;

            return model;
        }
    }
}
