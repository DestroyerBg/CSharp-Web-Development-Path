using System.Security.Cryptography.X509Certificates;

namespace Ranking
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            var contestDatabase = new Dictionary<string, string>();
            var userData = new SortedDictionary<string, SortedDictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input
                    .Split(":")
                    .ToArray();
                string contestName = tokens[0];
                string password = tokens[1];
                contestDatabase.Add(contestName, password);
            }


            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = input
                    .Split("=>")
                    .ToArray();
                string contestName = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int contestPoints = int.Parse(tokens[3]);
                if (!contestDatabase.ContainsKey(contestName))
                {
                    continue;
                }
                string CurrContestPass = contestDatabase[contestName];
                if (password != CurrContestPass)
                {
                    continue;
                }

                if (!userData.ContainsKey(username))
                {
                    userData.Add(username, new SortedDictionary<string, int>());
                    userData[username].Add(contestName, contestPoints);
                    continue;
                }

                if (!userData[username].ContainsKey(contestName))
                {
                    userData[username].Add(contestName, contestPoints);
                    continue;
                }

                if (contestPoints > userData[username][contestName])
                {
                    userData[username][contestName] = contestPoints;
                    continue;
                }




            }
            int maxPoints = 0;
            string userWithBiggestScore = string.Empty;

            foreach (var user in userData)
            {
                int currPoints = 0;
                currPoints = user.Value.Values.Sum();
                if (currPoints > maxPoints)
                {
                    maxPoints = currPoints;
                    userWithBiggestScore = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {userWithBiggestScore} with total {maxPoints} points.");

            Console.WriteLine($"Ranking: ");
            foreach (var pair in userData)
            {
                Console.WriteLine($"{pair.Key}");
                Console.WriteLine(String.Join("\n", pair.Value
                    .OrderByDescending(x => x.Value)
                    .Select(y => $"#  {y.Key} -> {y.Value}")));


            }






        }


    }
}