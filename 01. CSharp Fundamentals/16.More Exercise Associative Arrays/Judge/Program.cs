using System.Runtime.CompilerServices;

namespace Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contestStatistics = new Dictionary<string, Dictionary<string, int>>();
            var individualStatistics = new Dictionary<string, int>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "no more time")
            {
                string[] judgeData = input
                    .Split(" -> ")
                    .ToArray();
                string username = judgeData[0];
                string contest = judgeData[1];
                int points = int.Parse(judgeData[2]);
                if (!contestStatistics.ContainsKey(contest))
                {
                    contestStatistics.Add(contest, new Dictionary<string, int>());
                    contestStatistics[contest].Add(username, points);
                    if (!individualStatistics.ContainsKey(username))
                    {
                        individualStatistics.Add(username, 0);
                        individualStatistics[username] += points;
                        continue;
                    }
                    individualStatistics[username] += points;
                    continue;
                }

                if (!contestStatistics[contest].ContainsKey(username))
                {
                    contestStatistics[contest].Add(username, points);
                    if (!individualStatistics.ContainsKey(username))
                    {
                        individualStatistics.Add(username, 0);
                        individualStatistics[username] += points;
                        continue;
                    }
                    individualStatistics[username] += points;
                    continue;
                }
                int userScore = contestStatistics[contest][username];
                if (points > userScore)
                {
                    contestStatistics[contest][username] = points;
                    individualStatistics[username] = points;
                }

            }

            foreach (var contest in contestStatistics)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count} participants");
                int position = 1;
                Console.WriteLine(string.Join("\n",contest.Value.OrderByDescending(x=>x.Value)
                    .ThenBy(y=>y.Key).Select(z=> $"{position++}. {z.Key} <::> {z.Value}")));
                
            }

            int userPosition = 1;
            Console.WriteLine($"Individual standings:");
            Console.WriteLine(string.Join("\n", individualStatistics.OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key).Select(z => $"{userPosition++}. {z.Key} -> {z.Value}")));

        }
    }
}