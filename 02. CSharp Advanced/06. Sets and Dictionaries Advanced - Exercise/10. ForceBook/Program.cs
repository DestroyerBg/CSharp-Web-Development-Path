string input = string.Empty;
var allSides = new Dictionary<string, HashSet<string>>();
while ((input = Console.ReadLine()) != "Lumpawaroo")
{
    if (input.Contains("|"))
    {
        string[] data = input
            .Split(" | ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string side = data[0];
        string user = data[1];
        AddUserToSide(side, user, allSides);
    }
    else if (input.Contains("->"))
    {
        string[] data = input
            .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string user = data[0];
        string side = data[1];
        MoveUserToSide(user, side, allSides);
    }
}
var orderedSides = allSides
    .OrderByDescending(x => x.Value.Count)
    .ThenBy(x => x.Key)
    .ToList();
foreach (var side in orderedSides)
{
    if (side.Value.Count > 0)
    {
        Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
        foreach (var member in side.Value.OrderBy(x => x))
        {
            Console.WriteLine($"! {member}");
        }
    }
}
Dictionary<string, HashSet<string>> AddUserToSide(string side, string user, Dictionary<string, HashSet<string>> allSides)
{
    if (!allSides.ContainsKey(side))
    {
        allSides.Add(side, new HashSet<string>());
    }

    if (!allSides.Any(x => x.Value.Contains(user)))
    {
        allSides[side].Add(user);
    }
    return allSides;
}

Dictionary<string, HashSet<string>> MoveUserToSide(string user, string side, Dictionary<string, HashSet<string>> allSides)
{
    foreach (var entry in allSides)
    {
        if (entry.Value.Contains(user))
        {
            entry.Value.Remove(user);
            break;
        }
    }
    if (!allSides.ContainsKey(side))
    {
        allSides.Add(side, new HashSet<string>());
    }

    allSides[side].Add(user);
    Console.WriteLine($"{user} joins the {side} side!");
    return allSides;
}