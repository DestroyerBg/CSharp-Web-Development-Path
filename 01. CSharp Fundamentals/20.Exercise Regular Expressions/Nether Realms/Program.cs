using System.Text;
using System.Text.RegularExpressions;

namespace Nether_Realms
{
    class Demon
    {
        public Demon(string demonName, decimal healthPoints, decimal damagePoints)
        {
            Name = demonName;
            HealthPoints = healthPoints;
            DamagePoints = damagePoints;
        }

        public string Name { get; set; }
        public decimal HealthPoints { get; set; }
        public decimal DamagePoints { get; set; }

        public override string ToString()
        {
            return $"{Name} - {HealthPoints} health, {DamagePoints:f2} damage";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] demonsNames = Console
                .ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string letterPattern = @"[^0-9\*\+\-\/\.]";
            string digitsPattern = @"(?:(?:[-+]*)(?:\d+\.\d+|\d+))";
            string multiplayerPattern = @"[\*\/]";
            List<Demon> demons = new List<Demon>();
            for (int i = 0; i < demonsNames.Length; i++)
            {
                string currDemon = demonsNames[i];
                if (currDemon.Contains(',')|| currDemon.Contains(' '))
                {
                    continue;
                }

                string demonName = currDemon;
                decimal healthPoints = 0m;
                decimal damagePoints = 0m;
                MatchCollection wordMatch = Regex.Matches(currDemon, letterPattern);
                StringBuilder sb = new StringBuilder();
                foreach (Match match in wordMatch)
                {
                    sb.Append(match.Value[0]);
                }

                string word = sb.ToString();
                for (int k = 0; k < word.Length; k++)
                {
                    healthPoints += (decimal)word[k];
                }

                sb.Clear();
                MatchCollection digitMatch = Regex.Matches(currDemon, digitsPattern);
                foreach (Match match in digitMatch)
                {
                    decimal currNumber = 0m;
                    decimal.TryParse(match.Value, out currNumber);
                    damagePoints += currNumber;
                }

                MatchCollection multiplayerMatch = Regex.Matches(currDemon, multiplayerPattern);
                foreach (Match match in multiplayerMatch)
                {
                    sb.Append(match.Value);
                }
                string multiplayerDamage= sb.ToString();
                for (int k = 0; k < multiplayerDamage.Length; k++)
                {
                    if (multiplayerDamage[k]=='*')
                    {
                        damagePoints *= 2;
                    }
                    else if (multiplayerDamage[k]=='/')
                    {
                        damagePoints /= 2;
                    }
                }
                Demon demon = new Demon(demonName, healthPoints, damagePoints);
                demons.Add(demon);
            }

            demons = demons.OrderBy(n => n.Name).ToList();
            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.ToString()}");
            }
        }
    }
}