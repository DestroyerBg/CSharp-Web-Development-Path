namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            var ordersQueue = new Queue<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Console.WriteLine(ordersQueue.Max());
            while (ordersQueue.Count>0)
            {
                int currOrder = ordersQueue.Peek();
                if (quantityOfFood>=currOrder)
                {
                    quantityOfFood-=currOrder;
                    ordersQueue.Dequeue();
                    continue;
                }

                break;
            }

            if (ordersQueue.Count>0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}