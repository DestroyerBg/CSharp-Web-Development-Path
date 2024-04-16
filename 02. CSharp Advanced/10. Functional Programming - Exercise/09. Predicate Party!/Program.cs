var party = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string input = string.Empty;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] data = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string instruction = data[0];
    string condition = data[1];
    string criteria = data[2];
    if (instruction == "Remove")
    {
        party.RemoveAll(GetPredicate(condition, criteria));
    }
    else if (instruction == "Double")
    {
        var peopleToFind = party.FindAll(GetPredicate(condition, criteria)).ToList();
        foreach (var person in peopleToFind)
        {
            int index = party.FindIndex(p => p == person);
            party.Insert(index,person);
        }
    }
}

if (party.Count>0 )
{
    Console.WriteLine($"{string.Join(", ",party)} are going to the party!");
    return;
}

Console.WriteLine($"Nobody is going to the party!");

static Predicate<string> GetPredicate(string condition, string criteria)
{
    if (condition == "StartsWith")
    {
        return p => p.StartsWith(criteria);
    }
    else if (condition == "EndsWith")
    {
        return p => p.EndsWith(criteria);
    }
    else if (condition == "Length")
    {
        return p => p.Length == int.Parse(criteria);
    }

    return default;
}