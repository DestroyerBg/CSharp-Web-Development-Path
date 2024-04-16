using System.Security;

var world = new Dictionary<string, Dictionary<string, List<string>>>();
int numberOfEntries = int.Parse(Console.ReadLine());
for (int i = 0; i < numberOfEntries; i++)
{
    string[] data = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string continent = data[0];
    string country = data[1];
    string city = data[2];
    if (!world.ContainsKey(continent))
    {
        world.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!world[continent].ContainsKey(country))
    {
        world[continent].Add(country,new List<string>());
    }
    world[continent][country].Add(city);
}

foreach (var continent in world)
{
    Console.WriteLine($"{continent.Key}:");
    foreach (var country in continent.Value)
    {
        Console.WriteLine($"  {country.Key} -> {string.Join(", ",country.Value)}");
    }
}