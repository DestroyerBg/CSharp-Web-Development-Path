using System.Text;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChildren = int.Parse(Console.ReadLine());
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                StringBuilder decryptedMessage = new StringBuilder();
                string pattern = @"\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\!(?<behaviour>[G|N])\!";
                for (int j = 0; j < input.Length; j++)
                {
                    char currChar = input[j];
                    int decryptedCharCode = currChar - numberOfChildren;
                    char decryptedChar = (char)decryptedCharCode;
                    decryptedMessage.Append(decryptedChar);
                }

                Match match = Regex.Match(decryptedMessage.ToString(), pattern);
                string name = match.Groups["name"].Value;
                string behaviour = match.Groups["behaviour"].Value;
                if (behaviour == "G")
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
