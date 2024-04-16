using System.Text.RegularExpressions;
using System.Text;

namespace Problem_2___Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfBarcodes = int.Parse(Console.ReadLine());
            string pattern = @"\@\#+[A-Z]([A-Za-z0-9]{4,})[A-Z]\@\#+";
            for (int i = 0; i < countOfBarcodes; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string product = match.Groups[1].Value;
                    StringBuilder sb = new StringBuilder();
                    for (int k = 0; k < product.Length; k++)
                    {
                        char currChar = product[k];
                        if (char.IsDigit(currChar))
                        {
                            sb.Append(currChar);
                        }
                    }

                    string productGroup = string.Empty;
                    if (sb.Length == 0)
                    {
                        productGroup = "00";
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        productGroup = sb.ToString();
                        Console.WriteLine($"Product group: {productGroup}");
                    }

                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}