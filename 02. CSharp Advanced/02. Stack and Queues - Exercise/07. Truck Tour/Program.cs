namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int petrolsCount = int.Parse(Console.ReadLine());
            int bestRoute = 0;
            var wholeRoute = new Queue<int[]>();
            for (int i = 0; i < petrolsCount; i++)
            {
                wholeRoute.Enqueue(Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray());
            }

            while (true)
            {
                int currCarFuel = 0;
                foreach (var currPetrol in wholeRoute)
                {
                    int fuel = currPetrol[0];
                    int distance = currPetrol[1];
                    currCarFuel += fuel;
                    if (currCarFuel - distance < 0)
                    {
                        currCarFuel = 0;
                        break;
                    }
                    else
                    {
                        currCarFuel-=distance;
                    }
                    
                }

                if (currCarFuel>0)
                {
                    
                    break;
                }

                bestRoute++;
                int[] tempPetrol = wholeRoute.Dequeue();
                wholeRoute.Enqueue(tempPetrol);
            }

            Console.WriteLine(bestRoute);
           
            
        }
    }
}