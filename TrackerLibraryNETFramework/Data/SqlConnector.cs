using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrackerLibraryNETFramework.Models;

namespace TrackerLibraryNETFramework.Data
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "Tournaments";

        public PersonModel CreateTeamMember(PersonModel model)
        {
            using(IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var member = new DynamicParameters();

                member.Add("@FirstName", model.FirstName);
                member.Add("@LastName", model.LastName);
                member.Add("@Email", model.EmailAddress);
                member.Add("@PhoneNumber", model.CellphoneNumber);
                member.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeamMember_Insert", member, commandType: CommandType.StoredProcedure);
                //"test".FullFilePath();
                model.Id = member.Get<int>("@id");
                return model;
            }
        }

        /// <summary>
        /// Save a new prize to the database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information incliding the unique identifier</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using(IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction:ParameterDirection.Output);

                connection.Execute("dbo.spPrizes", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");
                return model;
            }
        }

        /// <summary>
        /// This method shows all members into listBox from db
        /// </summary>
        /// <returns></returns>
        public List<PersonModel> GetPerson_All()
        {
            List<PersonModel> output;

            using(IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                output = connection.Query<PersonModel>("dbo.spTeamMember_GetAll").ToList();
            }

            return output;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.ConnectionString(db)))
            {
                var p = new DynamicParameters();

                p.Add("@TeamName", model.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeam_Insert", p, commandType: CommandType.StoredProcedure);
                model.Id = p.Get<int>("@id");


                return model;
            }
        }
    }
}
