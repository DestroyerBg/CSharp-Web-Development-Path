using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Teamwork_Projects
{
    class Team
    {
        public Team(string creator, string teamName)
        {
            Creator = creator;
            TeamName = teamName;
            Members = new List<string>();
            Members = Members.OrderBy(name => name).ToList();
        }

        public string Creator { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            return $"{TeamName}\n" +
                   $"- {Creator}\n" +
                   $"{GetMembersString()}";
        }

        private string GetMembersString()
        {
            Members = Members
                .OrderBy(name => name)
                .ToList();

            string result = "";
            for (int i = 0; i < Members.Count - 1; i++)
            {
                result += $"-- {Members[i]}\n";
            }

            result += $"-- {Members[Members.Count - 1]}";
            return result;
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            List<string> members = new List<string>();
            List<Team> teams = new List<Team>();
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] teamInfo = Console.ReadLine()
                    .Split("-")
                    .ToArray();
                string creator = teamInfo[0];
                string teamName = teamInfo[1];
                Team newTeam = new Team(creator, teamName);
                Team sameTeamNameFound = teams.Find(x => x.TeamName == teamName);
                Team sameOwnerNameFound = teams.Find(x => x.Creator == creator);

                if (sameTeamNameFound != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!"); //check if team was created already.
                    continue;
                }



                if (sameOwnerNameFound != null)
                {
                    Console.WriteLine(
                        $"{creator} cannot create another team!"); //check if creator tries to create another team.
                    continue;
                }

                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
                //Creating teams.
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] membersData = input
                    .Split("->")
                    .ToArray();
                string user = membersData[0];
                string teamName = membersData[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(x => x.Creator == user) || teams.Any(x => x.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                teams.Find(x => x.TeamName == teamName).Members.Add(user);
                //Filling teams with members.

            }

            List<Team> leftTeams = teams.FindAll(x => x.Members.Count > 0).ToList();
            List<Team> disbandTeams = teams.FindAll(x => x.Members.Count == 0).ToList();
            leftTeams = leftTeams
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();


            disbandTeams = disbandTeams
                .OrderBy(x => x.TeamName)
                .ToList();
            leftTeams.ForEach(x => Console.WriteLine(x));

            Console.WriteLine($"Teams to disband:");

            disbandTeams.ForEach(x => Console.WriteLine(x.TeamName));

        }





    }
}