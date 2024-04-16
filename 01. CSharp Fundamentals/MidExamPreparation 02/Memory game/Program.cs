List<string> elements = Console
    .ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string input = string.Empty;
int movesCount = 0;
bool missionSuccessful = false;
while ((input = Console.ReadLine()) != "end")
{
    movesCount++;
    List<int> commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

    if ((commands[0] == commands[1]) || (commands[0] > elements.Count - 1 || commands[0] < 0) || (commands[1] > elements.Count - 1 || commands[1] < 0))
    {
        elements.Insert(elements.Count / 2, $"-{movesCount}a");
        elements.Insert(elements.Count / 2, $"-{movesCount}a");
        Console.WriteLine("Invalid input! Adding additional elements to the board");
        continue;
    }

    if (elements[commands[0]] == elements[commands[1]])
    {
        Console.WriteLine($"Congrats! You have found matching elements - {elements[commands[0]]}!");
        if (commands[0] < commands[1])
        {
            elements.RemoveAt(commands[1]);
            elements.RemoveAt(commands[0]);
        }
        else
        {
            elements.RemoveAt(commands[0]);
            elements.RemoveAt(commands[1]);
        }

    }

    else
    {
        Console.WriteLine("Try again!");

    }

    if (elements.Count == 0)
    {

        missionSuccessful = true;
        break;
    }
}

if (missionSuccessful == true)
{

    Console.WriteLine($"You have won in {movesCount} turns!");
}
else
{
Console.WriteLine($"Sorry you lose :(");
Console.WriteLine(string.Join(" ", elements));
    
}








