using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _09._Simple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            var undoneOperations = new Stack<string>();
            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                string instruction = input[0];
                if (instruction == "1")
                {
                    string textToAppend = input[1];
                    undoneOperations.Push(result.ToString());
                    result.Append(textToAppend);
                }

                else if (instruction == "2")
                {
                    int count = int.Parse(input[1]);
                    undoneOperations.Push(result.ToString());
                    string currText = result.ToString();
                    currText = currText.Substring(0, currText.Length - count);
                    result = new StringBuilder();
                    result.Append(currText);
                }
                else if (instruction == "3")
                {
                    int index = int.Parse(input[1]);
                    char elementToSearch = result.ToString()[index - 1];
                    Console.WriteLine(elementToSearch);
                }
                else if (instruction == "4")
                {
                    string oldText = undoneOperations.Pop();
                    result = new StringBuilder();
                    result.Append(oldText);
                }
            }

        }
    }
}
