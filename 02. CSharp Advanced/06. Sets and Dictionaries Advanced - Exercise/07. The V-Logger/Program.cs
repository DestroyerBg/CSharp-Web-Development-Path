using System.Text;

string input = string.Empty;
var allVloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
while ((input = Console.ReadLine()) != "Statistics")
{
    string[] data = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string instruction = data[1];
    if (instruction == "joined")
    {
        string username = data[0];
        if (!allVloggers.ContainsKey(username))
        {
            allVloggers.Add(username, new Dictionary<string, HashSet<string>>());
            allVloggers[username].Add("Followers", new HashSet<string>());
            allVloggers[username].Add("Following", new HashSet<string>());
        }

    }
    else if (instruction == "followed")
    {
        string usernameToFollow = data[0];
        string vLogger = data[2];
        if (allVloggers.ContainsKey(vLogger) && usernameToFollow != vLogger && allVloggers.ContainsKey(usernameToFollow))
        {
            allVloggers[vLogger]["Followers"].Add(usernameToFollow);
            allVloggers[usernameToFollow]["Following"].Add(vLogger);
        }
    }

}

var orderedVLoggers = allVloggers
    .OrderByDescending(x => x.Value["Followers"].Count)
    .ThenBy(x => x.Value["Following"].Count)
    .ToList();

int count = 0;
Console.WriteLine($"The V-Logger has a total of {allVloggers.Count} vloggers in its logs.");
foreach (var user in orderedVLoggers)
{
    count++;
    Console.WriteLine($"{count}. {user.Key} : {user.Value["Followers"].Count} followers, {user.Value["Following"].Count} following");
    if (count == 1)
    {
        if (user.Value["Followers"].Count > 0)
        {
            foreach (var follower in user.Value["Followers"].OrderBy(n=>n))
            {
                Console.WriteLine($"*  {follower}");
            }
        }
    }
}


