namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Stack<int> numStack = new Stack<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int numbersToPop = int.Parse(allIndexes[1]);
            int numberToSearch= int.Parse(allIndexes[2]);
            for (int i = 0; i < numbersToPop; i++)
            {
                numStack.Pop();
            }

            if (numStack.Contains(numberToSearch))
            {
                Console.WriteLine("true");
            }
            else if (numStack.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numStack.Min());
            }
        }
    }
}