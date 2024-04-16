using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private double rating;
        private string team;

        public Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }

        }

        public double Rating
        {
            get => rating;
            protected set
            {
                rating = value;
            }
        }

        public string Team
        {
            get => team;
            private set
            {
                team = value;
            }
        }
        public void JoinTeam(string name)
        {
            Team = name;
        }

        public abstract void IncreaseRating();


        public abstract void DecreaseRating();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{GetType().Name}: {Name}");
            result.AppendLine($"--Rating: {Rating}");
            return result.ToString().TrimEnd();
        }
    }
}
