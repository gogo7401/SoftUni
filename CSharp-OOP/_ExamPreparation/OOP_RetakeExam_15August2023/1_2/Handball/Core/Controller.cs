using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }


        public string NewTeam(string name)
        {
            ITeam team = new Team(name);

            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            teams.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository)); //teams.GetType().Name
        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = null;

            if (typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (players.ExistsModel(name))
            {
                string typeOfCurrentNamePlayer = players.GetModel(name).GetType().Name;
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository), typeOfCurrentNamePlayer);
            }

            players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);

        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            if (player.Team != default)  // default
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            
            team.SignContract(player);
            player.JoinTeam(teamName);

            return string.Format(OutputMessages.SignContract, playerName, teamName);


        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam teameOne = teams.GetModel(firstTeamName);
            ITeam teamTwo = teams.GetModel(secondTeamName);

            if (teameOne.OverallRating == teamTwo.OverallRating)
            {
                teameOne.Draw();
                teamTwo.Draw();

                return string.Format(OutputMessages.GameIsDraw, teameOne.Name, teamTwo.Name);
            }

            if (teameOne.OverallRating > teamTwo.OverallRating)
            {
                teameOne.Win();
                teamTwo.Lose();

                return string.Format(OutputMessages.GameHasWinner, teameOne.Name, teamTwo.Name);
            }
            else
            {
                teamTwo.Win();
                teameOne.Lose();

                return string.Format(OutputMessages.GameHasWinner, teamTwo.Name, teameOne.Name);
            }
        }
        public string PlayerStatistics(string teamName)
        {
            ITeam targetTeam = teams.GetModel(teamName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");

            var list = targetTeam.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name);

            foreach ( var player in list)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***League Standings***");
            foreach (var team in teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }


            return sb.ToString().Trim();
        }
       
    }
}
