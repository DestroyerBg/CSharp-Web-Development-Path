using System.Numerics;
using System.Text.RegularExpressions;

namespace Problem_2___Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string wordPattern = @"(\:\:|\*\*)(?<word>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"\d";
            MatchCollection matches = Regex.Matches(input, wordPattern);
            long coolThreshold = 1;
            List<string> coolEmojis = new List<string>();
            MatchCollection digits = Regex.Matches(input, digitsPattern);
            foreach (Match digit in digits)
            {
                coolThreshold *= long.Parse(digit.Value);
            }
            foreach (Match wordMatch in matches)
            {
                string currWord = wordMatch.Groups["word"].Value;
                int currWordSum = 0;
                for (int i = 0; i < currWord.Length; i++)
                {
                    char currChar = currWord[i];
                    currWordSum += (int)currChar;
                }

                if (currWordSum >= coolThreshold)
                {
                    coolEmojis.Add(wordMatch.ToString());
                }

                currWordSum = 0;
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
                              
            foreach (var emoji in coolEmojis)
            {
                Console.WriteLine($"{emoji}");
            }
        }
    }
}