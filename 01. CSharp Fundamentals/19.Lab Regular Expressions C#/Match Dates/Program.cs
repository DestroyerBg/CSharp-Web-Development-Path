using System.Text.RegularExpressions;

namespace Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dates= Console.ReadLine();
            string pattern = @"(?<day>\d{2})(?<captures>[-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})";
            foreach (Match date in Regex.Matches(dates,pattern))
            {
                Console.WriteLine($"Day: {date.Groups["day"].Value}, Month: {date.Groups["month"].Value}, Year: {date.Groups["year"].Value}");
            }
        }
    }
}