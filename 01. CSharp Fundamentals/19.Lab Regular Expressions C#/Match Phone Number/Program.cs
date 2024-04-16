using System.Text.RegularExpressions;

namespace Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string phones= Console.ReadLine();
            string pattern = @"\+359(\s|-)2\1(\d{3})\1(\d{4})";
            var phoneMatches= Regex.Matches(phones, pattern);
            var matchedPhones= phoneMatches
                .Cast<Match>()
                .Select(x=>x.Value.Trim())
                .ToList();
            Console.WriteLine(string.Join(", ",matchedPhones));
        }
    }
}