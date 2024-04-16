using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Problem_1___The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] operations = input
                    .Split("|")
                    .ToArray();
                string argument = operations[0];
                if (argument == "Move")
                {
                    StringBuilder sb= new StringBuilder();
                    int numberOfLetters = int.Parse(operations[1]);
                    string firstNLetters = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    sb.Append(encryptedMessage);
                    sb.Append(firstNLetters);
                    encryptedMessage=sb.ToString();
                }
                else if (argument == "Insert")
                {
                    int index = int.Parse(operations[1]);
                    
                    string value= operations[2];
                    encryptedMessage= encryptedMessage.Insert(index, value);
                }
                else if (argument == "ChangeAll")
                {
                    string substring= operations[1];
                    string replacement= operations[2];
                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}