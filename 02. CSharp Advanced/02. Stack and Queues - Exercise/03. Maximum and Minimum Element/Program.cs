namespace _03._Maximum_and
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries= int.Parse(Console.ReadLine());
            var numStack= new Stack<int>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int instruction = int.Parse(input[0].ToString());
                if (instruction == 1)
                {
                    int numberToAdd= int.Parse(input[1].ToString());
                    numStack.Push(numberToAdd);
                }
                else if (instruction == 2)
                {
                    numStack.Pop();
                }
                else if (instruction == 3)
                {
                    if (numStack.Count>0)
                    {
                        Console.WriteLine(numStack.Max());
                    }
                }
                else if (instruction == 4)
                {
                    if (numStack.Count > 0)
                    {
                        Console.WriteLine(numStack.Min());
                    }
                }
            }

            if (numStack.Count>0)
            {
                Console.WriteLine(string.Join(", ", numStack));
            }
            
        }
    }
}