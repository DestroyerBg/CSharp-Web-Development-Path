using System.Text.RegularExpressions;

namespace Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";
            MatchCollection matches = Regex.Matches(names, pattern);
            foreach (Match name in matches)
            {
                Console.Write($"{name.Value} ");
            }
            

        }
    }
}