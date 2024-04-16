namespace Plant_Discovery
{
    class Plant
    {
        public Plant(string name, int rarity, List<int> rating)
        {
            Name = name;
            Rarity = rarity;
            Rating = rating;
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Rating { get; set; }
        public override string ToString()
        {
            if (Rating.Count > 0)
            {
                return $"- {Name}; Rarity: {Rarity}; Rating: {Rating.Average():f2}";

            }

            return $"- {Name}; Rarity: {Rarity}; Rating: 0.00";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < numberOfLines; i++)
            {
                string[] arguments = Console
                    .ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string plantName = arguments[0];
                int rarity = int.Parse(arguments[1]);
                if (!plants.Any(x => x.Name == plantName))
                {
                    Plant plant = new Plant(plantName, rarity, new List<int>());
                    plants.Add(plant);
                    continue;
                }

                if (plants.Any(x => x.Name == plantName))
                {
                    plants.FirstOrDefault(x => x.Name == plantName).Rarity = rarity;
                }

            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = input
                    .Split(new string[] { ": ", " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = arguments[0];
                if (instruction == "Rate")
                {
                    string plantName = arguments[1];
                    int rating = int.Parse(arguments[2]);
                    if (!plants.Any(x => x.Name == plantName))
                    {
                        Console.WriteLine($"error");
                        continue;
                    }
                    plants.FirstOrDefault(x => x.Name == plantName).Rating.Add(rating);
                }
                else if (instruction == "Update")
                {
                    string plantName = arguments[1];
                    int rarity = int.Parse(arguments[2]);
                    if (!plants.Any(x => x.Name == plantName))
                    {
                        Console.WriteLine($"error");
                        continue;
                    }
                    plants.FirstOrDefault(x => x.Name == plantName).Rarity = rarity;
                }
                else if (instruction == "Reset")
                {
                    string plantName = arguments[1];
                    if (!plants.Any(x => x.Name == plantName))
                    {
                        Console.WriteLine($"error");
                        continue;
                    }
                    plants.FirstOrDefault(x => x.Name == plantName).Rating.Clear();
                }
            }

            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in plants)
            {
                Console.WriteLine($"{plant.ToString()}");
            }
        }
    }
}