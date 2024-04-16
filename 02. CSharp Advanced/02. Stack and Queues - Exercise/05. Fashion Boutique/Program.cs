namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothesStack = new Stack<int>
            (Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int capacityOfRack= int.Parse(Console.ReadLine());
            int totalRacks = 1;
            int currRackCapacity = capacityOfRack;
            while (clothesStack.Count>0)
            {
                int currPiece= clothesStack.Pop();
                if (currPiece<=currRackCapacity)
                {
                    currRackCapacity-=currPiece;
                }
                else if (currPiece>currRackCapacity)
                {
                    totalRacks++;
                    currRackCapacity = capacityOfRack;
                    currRackCapacity-= currPiece;
                }
                
            }

            Console.WriteLine(totalRacks);

        }
    }
}