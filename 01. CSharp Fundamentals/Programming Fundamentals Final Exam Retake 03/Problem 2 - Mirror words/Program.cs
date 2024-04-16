using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Problem_2___Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(\@|\#)(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";
            var wordsList = new List<string>();
            MatchCollection wordMatch= Regex.Matches(input, pattern);
            int pairs = 0;
            foreach (Match match in wordMatch)
            {
                pairs++;
                string firstWord= match.Groups["firstWord"].Value;
                string secondWord= match.Groups["secondWord"].Value;
                StringBuilder sb= new StringBuilder();
                for (int i = secondWord.Length-1; i >= 0; i--)
                {
                    sb.Append(secondWord[i]);
                }
                string mirroredWord= sb.ToString();
                if (firstWord==mirroredWord)
                {
                    wordsList.Add($"{firstWord} <=> {secondWord}");
                }
            }

            if (pairs==0)
            {
                Console.WriteLine($"No word pairs found!");
                Console.WriteLine($"No mirror words!");
                return;
            }
            else
            {
                if (wordsList.Count==0)
                {
                    Console.WriteLine($"{pairs} word pairs found!");
                    Console.WriteLine($"No mirror words!");
                }
                else
                {
                    Console.WriteLine($"{pairs} word pairs found!");
                    Console.WriteLine($"The mirror words are:");
                    Console.WriteLine(string.Join(", ", wordsList));
                }
            }
        }
    }
}