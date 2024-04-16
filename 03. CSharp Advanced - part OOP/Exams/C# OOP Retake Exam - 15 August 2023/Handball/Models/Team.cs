using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private const int InitialPointsValue = 0;
        private const int PointsAfterWin = 3;
        private const int PointsAfterDraw = 1;
        private List<IPlayer> players;
        public Team(string name)
        {
            Name = name;
            PointsEarned = InitialPointsValue;
            players = new List<IPlayer>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                name = value;
            }
        }

        public int PointsEarned { get; private set; }


        public double OverallRating
        {
            get
            {
                if (players.Any())
                {
                    return Math.Round(players.Average(p => p.Rating), 2);
                }
                return 0;
            }

        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get => players.AsReadOnly();
        }
        public void SignContract(IPlayer player)
        {
            player.JoinTeam(Name);
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += PointsAfterWin;
            players.ForEach(p => p.IncreaseRating());
        }

        public void Lose()
        {
            players.ForEach(p => p.DecreaseRating());
        }

        public void Draw()
        {
            PointsEarned += PointsAfterDraw;
            players.FirstOrDefault(p => p.GetType().Name == "Goalkeeper").IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Team: {Name} Points: {PointsEarned}");
            result.AppendLine($"--Overall rating: {OverallRating}");
            result.Append($"--Players: ");
            if (players.Any())
            {
                result.Append($"{string.Join(", ", players.Select(p => p.Name))}");
            }
            else
            {
                result.Append("none");
            }
            return result.ToString().TrimEnd();
        }
    }
}
