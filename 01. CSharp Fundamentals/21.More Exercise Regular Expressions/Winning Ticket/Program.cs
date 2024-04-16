using System.Text;
using System.Text.RegularExpressions;

namespace Winning_Ticket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            
            string pattern = @"([\@\$\#\^])\1{5,9}";
            for (int i = 0; i < input.Length; i++)
            {
                string currTicket = input[i].Trim();
                if (currTicket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                    continue;
                }

                string leftPart = string.Join("", currTicket.Take(10));
                string rightPart = string.Join("", currTicket.Skip(10));
                Match leftMatch = Regex.Match(leftPart, pattern);
                Match rightMatch = Regex.Match(rightPart, pattern);
                if (leftMatch.Success == false || rightMatch.Success == false
                                               || leftMatch.Value[0] != rightMatch.Value[0])
                {
                    Console.WriteLine($"ticket \"{currTicket}\" - no match");
                }
                else if (leftMatch.Value.Length < 10 || rightMatch.Value.Length < 10)
                {
                    char winSymbol = rightMatch.Value[0];
                    Console.WriteLine($"ticket \"{currTicket}\" - {Math.Min(leftMatch.Value.Length, rightMatch.Value.Length)}{winSymbol}");
                }
                else if (leftMatch.Value.Length==10 && rightMatch.Value.Length==10)
                {
                    char winSymbol = rightMatch.Value[0];
                    Console.WriteLine($"ticket \"{currTicket}\" - 10{winSymbol} Jackpot!");
                }

            }
            
        }
    }
}