using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace Race
{
    class Racer
    {
        public string Name { get; set; }
        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";
            string input = string.Empty;
            var racers = new Dictionary<string, Racer>();
            for (int i = 0; i < participants.Count; i++)
            {
                racers.Add(participants[i], new Racer());
            }
            
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder getName = new StringBuilder();
                int total = 0;
                foreach (Match letter in Regex.Matches(input, lettersPattern))
                {
                    getName.Append(letter.Value);
                }
                string name = getName.ToString();
                foreach (Match digits in Regex.Matches(input, digitsPattern))
                {
                    total += int.Parse(digits.Value);
                }

                if (participants.Contains(name))
                {
                    racers[name].Name = name;
                    racers[name].Distance += total;
                }

            }

            var sortedPlayerList = racers
                .OrderByDescending(x => x.Value.Distance)
                .Take(3)
                .ToList();
            Console.WriteLine($"1st place: {sortedPlayerList[0].Value.Name}\n" +
                              $"2nd place: {sortedPlayerList[1].Value.Name}\n" +
                              $"3rd place: {sortedPlayerList[2].Value.Name}");




        }
    }
}