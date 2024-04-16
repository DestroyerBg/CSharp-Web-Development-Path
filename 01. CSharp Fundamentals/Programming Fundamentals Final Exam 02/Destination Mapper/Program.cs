using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)(?<destination>[A-Z][A-Za-z]{2,})\1";
            string input= Console.ReadLine();
            MatchCollection matchDestinations = Regex.Matches(input, pattern);
            List<string> destinations = new List<string>();
            int travelPoints = 0;
            foreach (Match match in matchDestinations)
            {
                string currDestination= match.Groups["destination"].Value;
                destinations.Add(currDestination);
                travelPoints += currDestination.Length;
            }

            string result = string.Join(", ", destinations);
            Console.WriteLine($"Destinations: {result}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}