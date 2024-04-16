var invitations = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string input = string.Empty;
var filter = new Dictionary<string,Predicate<string>>();
while ((input = Console.ReadLine()) != "Print")
{
    
    string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string instruction = data[0];
    string condition = data[1];
    string criteria = data[2];

    if (instruction == "Add filter")
    {
        if (!filter.ContainsKey(condition + criteria))
        {
            filter.Add(condition + criteria,GetPredicate(condition,criteria));
        }
    }
    else if (instruction == "Remove filter")
    {
        filter.Remove(condition+ criteria);
    }
}

foreach (var kvp in filter)
{
    invitations.RemoveAll(kvp.Value);
}

Console.WriteLine(string.Join(" ",invitations));

static Predicate<string> GetPredicate(string condition, string criteria)
{
    if (condition == "Starts with")
    {
        return p => p.StartsWith(criteria);
    }
    else if (condition == "Ends with")
    {
        return p => p.EndsWith(criteria);
    }
    else if (condition == "Length")
    {
        return p => p.Length == int.Parse(criteria);
    }
    else if (condition == "Contains")
    {
        return p => p.Contains(criteria);
    }

    return default;
}