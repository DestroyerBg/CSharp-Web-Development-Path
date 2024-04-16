using System.Security;

namespace Problem_3___P_rates
{
    class City
    {
        public City(string cityName, int population, int gold)
        {
            Name = cityName;
            Population = population;
            Gold= gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var cities = new Dictionary<string, City>();
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] data = input
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cityName = data[0];
                int population = int.Parse(data[1]);
                int gold = int.Parse(data[2]);
                City city = new City(cityName, population, gold);
                if (!cities.ContainsKey(cityName))
                {
                    cities.Add(cityName, city);
                    continue;
                }
                cities[cityName].Population += population;
                cities[cityName].Gold += gold;
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction= data[0];
                if (instruction== "Plunder")
                {
                    string name= data[1];
                    int people= int.Parse(data[2]);
                    int gold= int.Parse(data[3]);
                    cities= Plunder(name, people, gold, cities);
                }
                else if (instruction=="Prosper")
                {
                    string name= data[1];
                    int gold= int.Parse(data[2]);
                    cities = Prosper(name, gold, cities);
                }
            }

            if (cities.Count==0)
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else if(cities.Count>0) 
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var city in cities)
                {
                    Console.WriteLine($"{city.Value.ToString()}");
                }
            }
            
        }

        private static Dictionary<string, City> Prosper(string name, int gold, Dictionary<string, City> cities)
        {
            if (gold<0)
            {
                Console.WriteLine($"Gold added cannot be a negative number!");
                return cities;
            }

            cities[name].Gold += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {cities[name].Gold} gold.");
            return cities;
        }

        private static Dictionary<string,City> Plunder(string name, int people, int gold, Dictionary<string, City> cities)
        {
            cities[name].Population-=people;
            cities[name].Gold-=gold;
            Console.WriteLine($"{name} plundered! {gold} gold stolen, {people} citizens killed.");
            if (cities[name].Population==0 || cities[name].Gold == 0)
            {
                cities.Remove(name);
                Console.WriteLine($"{name} has been wiped off the map!");
            }
            return cities;
        }
    }
}