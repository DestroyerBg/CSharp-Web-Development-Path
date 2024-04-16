using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"A name should not be empty.");
                }
                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Any())
                {
                    return players.Average(p=>p.OverallSkill);
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!players.Any(p=>p.Name == playerName))
            {
               throw new Exception($"Player {playerName} is not in {Name} team.");
            }
            players.Remove(players.Find(p=>p.Name == playerName));
            
        }
    }
}
