string input = string.Empty;
var allUsers = new Dictionary<string, int>();
var submissions = new Dictionary<string, int>();
while ((input = Console.ReadLine()) != "exam finished")
{
    if (!input.Contains("banned"))
    {
        string[] data = input
            .Split("-", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string name = data[0];
        string contest = data[1];
        int points = int.Parse(data[2]);
        if (!allUsers.ContainsKey(name))
        {
            allUsers.Add(name, points);
        }
        else
        {
            if (points > allUsers[name])
            {
                allUsers[name] = points;
            }
        }

        if (!submissions.ContainsKey(contest))
        {
            submissions.Add(contest, 0);
        }
        submissions[contest]++;
    }
    else
    {
        string[] data = input
            .Split("-", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string name = data[0];
        if (allUsers.ContainsKey(name))
        {
            allUsers.Remove(name);
        }
    }
}

Console.WriteLine($"Results:");
foreach (var user in allUsers.OrderByDescending(x=>x.Value)
             .ThenBy(x=>x.Key))
{
    Console.WriteLine($"{user.Key} | {user.Value}");
}

Console.WriteLine($"Submissions:");
foreach (var submission in submissions.OrderByDescending(x=>x.Value)
             .ThenBy(x=>x.Key))
{
    Console.WriteLine($"{submission.Key} - {submission.Value}");
}
