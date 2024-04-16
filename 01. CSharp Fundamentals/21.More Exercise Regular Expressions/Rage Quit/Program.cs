using System.Text;
using System.Text.RegularExpressions;

namespace Rage_Quit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<string>[A-Za-z\D]+)(?<numberOfTimes>\d+)";
            MatchCollection match = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();
            foreach (Match currMatch in match)
            {
                string charactersToRepeat = currMatch.Groups["string"].Value;
                int numberToRepeat = int.Parse(currMatch.Groups["numberOfTimes"].Value);
                string converterCharacter = string.Empty;
                for (int i = 0; i < charactersToRepeat.Length; i++)
                {
                    char currChar = charactersToRepeat[i];
                    if (char.IsLetter(currChar))
                    {
                        currChar = char.ToUpper(charactersToRepeat[i]);
                    }

                    converterCharacter = converterCharacter + currChar;
                }
                for (int i = 0; i < numberToRepeat; i++)
                {
                    sb.Append(converterCharacter);
                }
            }

            List<char> uniqueSymbols = new List<char>();
            string result = sb.ToString();
            for (int i = 0; i < result.Length; i++)
            {
                if (i + 1 < result.Length - 1)
                {
                    if ((result[i] != result[i + 1]) && !uniqueSymbols.Contains(result[i]))
                    {
                        uniqueSymbols.Add(result[i]);
                    }
                }

            }
            if (!uniqueSymbols.Contains(result[result.Length - 1]))
            {
                uniqueSymbols.Add(result[result.Length - 1]);
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine($"{result}");
        }
    }
}