namespace _09.PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new List<Trainer>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string trainerName = data[0];
                string pokemonName = data[1];
                string element = data[2];
                int pokemonHealth = int.Parse(data[3]);
                if (trainers.Any(x=>x.Name == trainerName))
                {
                    trainers.Find(n=>n.Name == trainerName).Pokemons.Add(new Pokemon(pokemonName,element,pokemonHealth));
                }
                else
                {
                    Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealth);
                    Trainer trainer = new Trainer(trainerName,pokemon);
                    trainers.Add(trainer);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                string searchElement = input;
                if (searchElement == "Fire" || searchElement == "Water" || searchElement == "Electricity")
                {
                    Process(trainers, searchElement);
                }
            }

            var sortedList = trainers.OrderByDescending(b => b.NumberOfBadges);
            foreach (var trainer in sortedList)
            {
                Console.WriteLine($"{trainer.ToString()}");
            }
        }

        public static void Process(List<Trainer> trainers, string command)
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                if (trainers[i].Pokemons.Any(e => e.Element == command))
                {
                    trainers[i].NumberOfBadges++;
                }
                else
                {
                    trainers[i].Pokemons.ForEach(h => h.Health -= 10);
                    trainers[i].Pokemons.RemoveAll(h => h.Health <= 0);
                }
            }
        }
    }
}

