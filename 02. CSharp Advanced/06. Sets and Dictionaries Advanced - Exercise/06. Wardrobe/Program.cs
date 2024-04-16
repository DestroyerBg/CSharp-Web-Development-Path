using System;

int numberOfLines = int.Parse(Console.ReadLine());
var wardrobe = new Dictionary<string, Dictionary<string, int>>();
for (int i = 0; i < numberOfLines; i++)
{
    string[] data = Console.ReadLine()
        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string[] clothesInfo = data[1]
        .Split(",", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string color = data[0];
    for (int j = 0; j < clothesInfo.Length; j++)
    {
        if (!wardrobe.ContainsKey(color))
        {
            wardrobe.Add(color, new Dictionary<string, int>());
        }
        string currWear = clothesInfo[j];
        if (!wardrobe[color].ContainsKey(currWear))
        {
            wardrobe[color].Add(currWear, 0);
        }
        wardrobe[color][currWear]++;
    }
}

string[] searchingWear = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
string colorToSearch = searchingWear[0];
string wearToSearch = searchingWear[1];
foreach (var entry in wardrobe)
{
    Console.WriteLine($"{entry.Key} clothes:");
    foreach (var wear in entry.Value)
    {
        if (entry.Key == colorToSearch && wear.Key == wearToSearch)
        {
            Console.WriteLine($"* {wear.Key} - {wear.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {wear.Key} - {wear.Value}");
        }
    }
}