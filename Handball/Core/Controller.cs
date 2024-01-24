using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players;
        private TeamRepository teams;
        public Controller()
        {

            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            throw new NotImplementedException();
        }

        public string NewContract(string playerName, string teamName)
        {
            throw new NotImplementedException();
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            throw new NotImplementedException();
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName == "Goalkeeper" || typeName == "CenterBack" || typeName == "ForwardWing")
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition,typeName);
            }

            if (players.ExistsModel(name))
            {
                IPlayer existingPlayer = players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded,name, name.GetType().Name, existingPlayer.GetType().Name);
            }

            IPlayer player; 

            return string.Format(OutputMessages.PlayerAddedSuccessfully,name);
        }


        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists,name,name.GetType().Name);
            }

            teams.AddModel(new Team(name));
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, name.GetType().Name);

        }


        public string PlayerStatistics(string teamName)
        {
           
                List<ITeam> sortedTeams = teams.Models.OrderByDescending(team => team.PointsEarned)
                                                    .ThenByDescending(team => team.OverallRating)
                                                    .ThenBy(team => team.Name)
                                                    .ToList();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("***League Standings***");

                foreach (var team in sortedTeams)
                {
                    stringBuilder.AppendLine(team.ToString());
                }

                return stringBuilder.ToString().TrimEnd();
            
        }
    }
}
    

