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
        private const string PrizesFile = "PrizeModels.csv";
        private const string TeamMembersFile = "TeamMemberModels.csv";

        // TODO - wire up the createPrize for text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // load the text file convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModel();

            //find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            // new record ID
            prizes.Add(model);

            // convert the prizes to List<strings>
            // save it to the text file

            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public PersonModel CreateTeamMember(PersonModel model)
        {
            List<PersonModel> members = TeamMembersFile.FullFilePath().LoadFile().ConvertToPersonModel();
            
            int currentId = 1;

            if (members.Count > 0)
            {
                currentId = members.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            members.Add(model);
            members.SaveToPersonFile(TeamMembersFile);

            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            throw new NotImplementedException();
        }
    }
}
