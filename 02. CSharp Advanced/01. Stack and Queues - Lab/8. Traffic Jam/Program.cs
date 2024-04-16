namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carPassInGreenLight = int.Parse(Console.ReadLine());
            var traffic = new Queue<string>();
            int carPassed= 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carPassInGreenLight; i++)
                    {
                        if (traffic.Count==0)
                        {
                            break;
                        }
                        Console.WriteLine($"{traffic.Dequeue()} passed!");
                        carPassed++;
                    }
                    continue;
                }
                traffic.Enqueue(input);
            }

            Console.WriteLine($"{carPassed} cars passed the crossroads.");
        }
    }
}