namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var childQueue = new Queue<string>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int tossesToEliminate= int.Parse(Console.ReadLine());
            int tossesCount = 0;
            while (childQueue.Count>1)
            {
                tossesCount++;
                string currChild = childQueue.Dequeue();
                if (tossesCount==tossesToEliminate)
                {
                    tossesCount = 0;
                    Console.WriteLine($"Removed {currChild}");
                    continue;
                }
                childQueue.Enqueue(currChild);
                
            }

            Console.WriteLine($"Last is {childQueue.Dequeue()}");
        }
    }
}