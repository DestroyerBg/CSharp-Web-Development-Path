using System.Diagnostics.CodeAnalysis;
using _05.FootballTeamGenerator;
using System.Numerics;


string input = string.Empty;
var teams = new List<Team>();
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input.Split(";");
    string instruction = data[0];
    try
    {
        if (instruction == "Team")
        {
            string teamName = data[1];
            CreateTeam(teamName, teams);
        }
        else if (instruction == "Add")
        {
            string teamName = data[1];
            string playerName = data[2];
            int endurance = int.Parse(data[3]);
            int sprint = int.Parse(data[4]);
            int drible = int.Parse(data[5]);
            int passing = int.Parse(data[6]);
            int shooting = int.Parse(data[7]);
            AddPlayerToTeam(teams,teamName,playerName, endurance,sprint,drible,passing,shooting);
        }
        else if (instruction == "Remove")
        {
            string teamName = data[1];
            string playerName = data[2];
            RemovePlayer(teamName, playerName, teams);
        }
        else if (instruction == "Rating")
        {
            string teamName = data[1];
            GetRating(teamName, teams);
        }
    }
    catch (Exception error)
    {
        Console.WriteLine(error.Message);
    }
}


void AddPlayerToTeam(List<Team> teams, string teamName, string playerName, int endurance, int sprint, int drible, int passing,
    int shooting)
{
    if (!teams.Any(t=>t.Name == teamName))
    {
        throw new Exception($"Team {teamName} does not exist.");
    }

    var player = new Player(playerName, endurance, sprint, drible, passing, shooting);
    teams.FirstOrDefault(t=>t.Name == teamName).AddPlayer(player);
}
void CreateTeam(string teamName, List<Team> teams)
{
    var team = new Team(teamName);
    teams.Add(team);
}

void RemovePlayer(string teamName, string playerName, List<Team> teams)
{
    if (!teams.Any(t => t.Name == teamName))
    {
        throw new Exception($"Team {teamName} does not exist.");
    }
    teams.FirstOrDefault(t=>t.Name == teamName).RemovePlayer(playerName);
}
void GetRating(string teamName, List<Team> teams)
{
    if (!teams.Any(t => t.Name == teamName))
    {
        throw new Exception($"Team {teamName} does not exist.");
    }

    double rating = teams.FirstOrDefault(t => t.Name == teamName).Rating;
    Console.WriteLine($"{teamName} - {rating:F0}");
}
