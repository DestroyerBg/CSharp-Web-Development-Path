using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int drible;
        private int passing;
        private int shooting;
        private const string ExceptionMessage = "{0} should be between 0 and 100.";

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Drible = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception($"A name should not be empty.");
                }
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(string.Format(ExceptionMessage, nameof(Endurance)));
                }
                endurance = value; 
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(string.Format(ExceptionMessage, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        public int Drible
        {
            get => drible;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(string.Format(ExceptionMessage, nameof(Drible)));
                }
                drible = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(string.Format(ExceptionMessage, nameof(Passing)));
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception(string.Format(ExceptionMessage, nameof(Shooting)));
                }
                shooting = value;
            }
        }

        public double OverallSkill
        { 
            get => (Endurance + Sprint + Drible + Passing + Shooting) / 5.0; 
        }

    }
}
