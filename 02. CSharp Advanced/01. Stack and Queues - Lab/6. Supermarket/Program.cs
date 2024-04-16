namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            var peopleQueue = new Queue<string>();
            while ((input = Console.ReadLine()) != "End")
            {
                if (input=="Paid")
                {
                    while (peopleQueue.Count>0)
                    {
                        Console.WriteLine(peopleQueue.Dequeue());
                    }
                    continue;
                }
                peopleQueue.Enqueue(input);
            }

            Console.WriteLine($"{peopleQueue.Count} people remaining.");
        }
    }
}