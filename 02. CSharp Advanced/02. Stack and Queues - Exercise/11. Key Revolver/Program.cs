namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceOfTheBullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var locks = new Queue<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int valueOfTheIntelligence = int.Parse(Console.ReadLine());
            int currSizeOfBarel = sizeOfTheGunBarrel;
            int firedBullets = 0;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();
                firedBullets++;
                if (currBullet <= currLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {

                    Console.WriteLine("Ping!");
                }

                currSizeOfBarel--;
                if (currSizeOfBarel == 0 && bullets.Count > 0)
                {
                    currSizeOfBarel = sizeOfTheGunBarrel;
                    Console.WriteLine("Reloading!");
                }

            }

            if (bullets.Count >= 0 && locks.Count == 0)
            {
                decimal totalPriceForBullets = firedBullets * priceOfTheBullet;
                decimal award = valueOfTheIntelligence - totalPriceForBullets;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${award}");
            }
            else if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }


        }
    }
}
