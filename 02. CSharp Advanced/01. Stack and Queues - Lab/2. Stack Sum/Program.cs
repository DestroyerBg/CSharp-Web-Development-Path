using System.ComponentModel;
using System.ComponentModel.Design;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Stack<int> numStack = new Stack<int>
               (Console.ReadLine()
                   .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse));
           string input = string.Empty;
           while ((input = Console.ReadLine().ToLower()) != "end")
           {
                string[] dataInfo = input
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = dataInfo[0];
                if (instruction == "add")
                {
                    int n1 = int.Parse(dataInfo[1]);
                    int n2 = int.Parse(dataInfo[2]);
                    numStack = AddNumbers(numStack, n1, n2);
                }
                else if (instruction == "remove" )
                {
                    int numToRemove= int.Parse(dataInfo[1]);
                    numStack = RemoveNumber(numStack, numToRemove);
                }
           }
           Console.WriteLine($"Sum: {numStack.Sum()}");
        }


        private static Stack<int> AddNumbers(Stack<int> numStack, int n1, int n2)
        {
            numStack.Push(n1);
            numStack.Push(n2);
            return numStack;
        }
        private static Stack<int> RemoveNumber(Stack<int> numStack, int numToRemove)
        {
            if (numToRemove>numStack.Count)
            {
                return numStack;
            }

            for (int i = 0; i < numToRemove; i++)
            {
                numStack.Pop();
            }
            return numStack;
        }

    }
}