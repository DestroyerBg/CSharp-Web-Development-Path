string[] command = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
var numDictionary = new Dictionary<string, int>();
for (int i = 0; i < command.Length; i++)
{
    if (!numDictionary.ContainsKey(command[i]))
    {
        numDictionary.Add(command[i], 0);
    }
    numDictionary[command[i]]++;
}

foreach (var kvp in numDictionary)
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
}
