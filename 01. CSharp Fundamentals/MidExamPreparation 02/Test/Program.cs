using System.Security.Cryptography;

List<string> coffeeList = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
int numberOfCommands = int.Parse(Console.ReadLine());
for (int i = 0; i < numberOfCommands; i++)
{
    string input = Console.ReadLine();
    List<string> commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
    if (commands[0] == "Include")
    {
        string coffeeToAdd = commands[1];
        coffeeList.Add(coffeeToAdd);
    }
    else if (commands[0] == "Remove")
    {
        string FirstOrLast = commands[1];
        if (FirstOrLast == "first")
        {
            int coffesToDelete = int.Parse(commands[2]);
            if (coffesToDelete >= 0 && coffesToDelete <= coffeeList.Count - 1)
            {
                for (int k = 1; k <= coffesToDelete; k++)
                {
                    coffeeList.Remove(coffeeList[0]);
                }

            }
            else if (commands[1] == "last")
            {
                int numberOfCoffees = int.Parse(commands[2]);
                if (numberOfCoffees > coffeeList.Count - 1)
                {
                    continue;
                }

                coffeeList.RemoveRange(coffeeList.Count - 1, numberOfCoffees);
            }
        }
        else if (commands[0] == "Prefer")
        {
            int coffeIndex1 = int.Parse(commands[1]);
            int coffeIndex2 = int.Parse(commands[2]);

            if ((coffeIndex1 < 0 || coffeIndex2 < 0) ||
                (coffeIndex1 > coffeeList.Count - 1 || coffeIndex2 > coffeeList.Count - 1))
            {
                continue;


            }

            string temp = coffeeList[coffeIndex1];
            string temp2 = coffeeList[coffeIndex2];
            coffeeList[coffeIndex1] = temp2;
            coffeeList[coffeIndex2] = temp;

        }
        else if (commands[0] == "Reverse")
        {
            coffeeList.Reverse();
        }
    }
}

Console.WriteLine("Coffees:");
Console.WriteLine(string.Join(" ", coffeeList));