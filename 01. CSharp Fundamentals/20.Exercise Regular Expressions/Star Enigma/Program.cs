using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Star_Enigma
{
    class Planets
    {
        public Planets(string planetName, int population, string attackType, int soldierCount )
        {
            AttackType = attackType;
            Name = planetName;
            Population = population;
            SoldierCount= soldierCount;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<Planets> planetsList = new List<Planets>();
            int numberOfMessages = int.Parse(Console.ReadLine());
            string decrypt = @"[sSTtaArR]";
            string pattern= @"\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<population>\d+)[^\@\-\!\:\>]*\!(?<attackType>A|D)![^\@\-\!\:\>]*\-\>(?<soldiersCount>\d+)[^\@\-\!\:\>]*";
            
            for (int i = 0; i < numberOfMessages; i++)
            {
                string input = Console.ReadLine();
                int decryptKey= Regex.Matches(input,decrypt).Count();
                StringBuilder sb= new StringBuilder();
                for (int k = 0; k < input.Length; k++)
                {
                    sb.Append((char)(input[k] - decryptKey));
                }
                string encryptedMessage= sb.ToString();
              
                var match = Regex.Match(encryptedMessage, pattern);
                if (Regex.IsMatch(encryptedMessage,pattern) == false) 
                {
                    continue;
                }
                string planetName= match.Groups["name"].Value;
                int population = int.Parse(match.Groups["population"].Value);
                string attackType= match.Groups["attackType"].Value;
                int soldierCount = int.Parse(match.Groups["soldiersCount"].Value);
                Planets planet = new Planets(planetName,population,attackType,soldierCount);
                planetsList.Add(planet);
            }

            var attackedPlanets = planetsList
                .Where(p => p.AttackType == "A")
                .OrderBy(n => n.Name)
                .ToList();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            attackedPlanets.ForEach(x=> Console.WriteLine($"-> {x.Name}"));
            var destroyerPlanets= planetsList
                .Where(p => p.AttackType == "D")
                .OrderBy(n => n.Name)
                .ToList();
            Console.WriteLine($"Destroyed planets: {destroyerPlanets.Count}");
            destroyerPlanets.ForEach(x => Console.WriteLine($"-> {x.Name}"));
        }
    }
}