using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = new List<Player>();
        }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return $"Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return $"There are no more open positions.";

            }

            if (player.Rating < 80)
            {
                return $"Invalid player's rating.";
            }

            OpenPositions--;
            Players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            if (Players.Any(p => p.Name == name))
            {
                Players.Remove(Players.FirstOrDefault(p => p.Name == name));
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = Players.RemoveAll(p => p.Position == position);
            OpenPositions += count;
            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (Players.Any(p => p.Name == name))
            {
                Players.Find(p => p.Name == name).Retired = true;
                return Players.Find(p => p.Name == name);
            }

            return null;
        }

        public List<Player> AwardPlayers(int games) => Players.Where(g => g.Games >= games).ToList();
        

        public string Report() =>
            $"Active players competing for Team {Name} from Group {Group}:{Environment.NewLine}{string.Join(Environment.NewLine, this.Players.Where(p => !p.Retired))}";
    }
}
