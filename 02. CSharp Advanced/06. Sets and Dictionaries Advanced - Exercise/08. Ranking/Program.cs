var allContests = new Dictionary<string, string>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "end of contests")
{
    string[] data = input
        .Split(":", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string contest = data[0];
    string password = data[1];
    allContests.Add(contest, password);
}
var allUsers = new Dictionary<string, Dictionary<string, int>>();
while ((input = Console.ReadLine()) != "end of submissions")
{
    string[] data = input
        .Split("=>", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string contest = data[0];
    string password = data[1];
    string userName = data[2];
    int points = int.Parse(data[3]);
    if (allContests.ContainsKey(contest))
    {
        if (allContests[contest] == password)
        {
            if (!allUsers.ContainsKey(userName))
            {
                allUsers.Add(userName, new Dictionary<string, int>());
            }
            if (allUsers[userName].ContainsKey(contest))
            {
                if (points > allUsers[userName][contest])
                {
                    allUsers[userName][contest] = points;
                }
            }
            else
            {
                allUsers[userName].Add(contest, points);
            }
        }

    }
}

string bestCandidateName = allUsers.MaxBy(x => x.Value.Values.Sum()).Key;
int candidatePoints = allUsers[bestCandidateName].Values.Sum();
var orderedUsers = allUsers.OrderBy(x => x.Key);
Console.WriteLine($"Best candidate is {bestCandidateName} with total {candidatePoints} points.");
Console.WriteLine($"Ranking:");
foreach (var user in orderedUsers)
{
    Console.WriteLine($"{user.Key}");
    foreach (var contest in user.Value.OrderByDescending(v=>v.Value))
    {
        Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
    }
}

