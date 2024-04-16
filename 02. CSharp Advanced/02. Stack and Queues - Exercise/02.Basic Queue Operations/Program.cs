namespace _02.Basic_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] allIndexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var numQueue = new Queue<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int numbersToDequeue = int.Parse(allIndexes[1]);
            int numberToSearch = int.Parse(allIndexes[2]);
            for (int i = 0; i < numbersToDequeue; i++)
            {
                numQueue.Dequeue();
            }

            if (numQueue.Contains(numberToSearch))
            {
                Console.WriteLine("true");
            }
            else if (numQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numQueue.Min());
            }
        }
    }
}