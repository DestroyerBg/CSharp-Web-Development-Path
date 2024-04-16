namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var bottles = new Stack<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int wastedLiterWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currCup = cups.Dequeue();
                int currBottle = bottles.Pop();
                if (currBottle>=currCup)
                {
                    wastedLiterWater += currBottle - currCup;
                }
                else
                {
                    currCup-=currBottle;
                    while (currCup>0)
                    {
                        
                        currCup-=bottles.Pop();
                        if (currCup<0)
                        {
                            wastedLiterWater += currCup*-1;
                        }
                    }
                }
            }


            if (bottles.Count > 0 && cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else if (bottles.Count == 0 && cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiterWater}");
        }
    }
}