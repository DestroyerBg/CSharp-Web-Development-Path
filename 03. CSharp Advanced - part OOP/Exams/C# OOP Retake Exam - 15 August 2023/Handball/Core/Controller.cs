using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;

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
        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name) == false)
            {
                ITeam team = new Team(name);
                teams.AddModel(team);
                return string.Format(OutputMessages.TeamSuccessfullyAdded, name, teams.GetType().Name);
            }

            return string.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            string[] validClasses = new string[] { "Goalkeeper", "CenterBack", "ForwardWing" };
            if (!validClasses.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            IPlayer searchPlayer = players.GetModel(name);
            if (searchPlayer!=null)
            {
                return string.Format
                    (OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name, searchPlayer.GetType().Name);
            }

            IPlayer player = null;
            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                player = new ForwardWing(name);
            }
            players.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);
            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, players.GetType().Name);
            }
            ITeam team = teams.GetModel(teamName);
            if (team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting,teamName,teams.GetType().Name);
            }

            if (player.Team!=null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }
            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);
            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            }
            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }
            firstTeam.Draw();
            secondTeam.Draw();
            return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
        }

        public string PlayerStatistics(string teamName)
        {
           StringBuilder result = new StringBuilder();
           ITeam team = teams.GetModel(teamName);
           IReadOnlyCollection<IPlayer> players = team.Players;
           result.AppendLine($"***{teamName}***");
           foreach (IPlayer player in players.OrderByDescending(p=>p.Rating).ThenBy(p=>p.Name))
           {
               result.AppendLine(player.ToString());
           }
           return result.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            IReadOnlyCollection<ITeam> league = teams.Models;
            StringBuilder result = new StringBuilder();
            result.AppendLine($"***League Standings***");
            foreach (var team in 
                     league.OrderByDescending(t=>t.PointsEarned).ThenByDescending(t=>t.OverallRating).ThenBy(t=>t.Name))
            {
                result.AppendLine(team.ToString());
            }
            return result.ToString().TrimEnd();
        }
    }
}
