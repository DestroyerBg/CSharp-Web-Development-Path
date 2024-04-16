using System.Security.Cryptography.X509Certificates;

namespace MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;
            var season = new Dictionary<string, Dictionary<string, int>>();
            while ((input = Console.ReadLine()) != "Season end")
            {
                string[] arguments = input
                    .Split(new string[] { " -> ", " vs " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (input.Contains("->"))
                {
                    string player = arguments[0];
                    string position = arguments[1];
                    int skull = int.Parse(arguments[2]);
                    if (!season.ContainsKey(player))
                    {
                        season.Add(player, new Dictionary<string, int>());


                    }

                    if (!season[player].ContainsKey(position))
                    {
                        season[player].Add(position, skull);


                    }

                    if (season[player].ContainsKey(position))
                    {
                        if (skull > season[player][position])
                        {
                            season[player][position] = skull;

                        }
                    }

                }

                if (input.Contains("vs"))
                {
                    string playerOne = arguments[0];
                    string playerTwo = arguments[1];
                    string playerToRemove=string.Empty;
                    if (!season.ContainsKey(playerOne) || !season.ContainsKey(playerTwo))
                    {
                        continue;
                    }
                    foreach (var player in season[playerOne])
                    {
                        if (season[playerTwo].ContainsKey(player.Key))
                        {
                            if (season[playerOne].Values.Sum() > season[playerTwo].Values.Sum())
                            {
                                playerToRemove = playerTwo;
                                continue;

                            }
                            else if (season[playerOne].Values.Sum() < season[playerTwo].Values.Sum())
                            {
                                playerToRemove=playerOne;
                                continue;
                            }
                            else if (season[playerOne].Values.Sum() == season[playerTwo].Values.Sum())
                            {
                                break;
                            }
                        }
                    }

                    season.Remove(playerToRemove);
                }



            }
            foreach (var pair in season.OrderByDescending(x => x.Value.Values
                             .Sum())
                         .ThenBy(y => y.Key))
            {

                Console.WriteLine($"{pair.Key}: {pair.Value.Values.Sum()} skill");
                foreach (var kvp in pair.Value.OrderByDescending(z => z.Value).ThenBy(a => a.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }
    }
}