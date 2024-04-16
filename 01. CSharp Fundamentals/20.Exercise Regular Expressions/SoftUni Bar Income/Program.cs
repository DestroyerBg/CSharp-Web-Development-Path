using System.Text.RegularExpressions;

namespace SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<name>[A-Z][a-z]+)%[^|$%\.]*?<(?<product>\w+)>[^|$%\.]*?\w*\|(?<quantity>\d+)\|[^|$%\.]*?(?<price>\d+(\.\d*)?)\$";
            string input = string.Empty;
            decimal total = 0m;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(input, pattern) == false)
                {
                    continue;
                }

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    total += price * quantity;
                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {price*quantity:f2}");
                }

            }

            Console.WriteLine($"Total income: {total:f2}");
        }
    }
}