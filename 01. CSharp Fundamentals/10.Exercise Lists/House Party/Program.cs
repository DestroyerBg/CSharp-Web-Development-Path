int numberOfCommands = int.Parse(Console.ReadLine());
List<string> guestList = new List<string>();

for (int i = 0; i < numberOfCommands; i++)
{
    string input = Console.ReadLine();
    List<string> arguments = input.Split().ToList();
    if (arguments.Contains("is")==true && arguments.Contains("not")==false)
    {
        if (guestList.Contains(arguments[0]) == true)
        {
            Console.WriteLine($"{arguments[0]} is already in the list!");
        }
        else
        {
        guestList.Add(arguments[0]);
            
        }

    }
    else if (arguments.Contains("is") == true && arguments.Contains("not") == true)
    {
        if (guestList.Contains(arguments[0])==true)
        {
            guestList.Remove(arguments[0]);
        }
        else
        {
            Console.WriteLine($"{arguments[0]} is not in the list!");
        }
    }
}

for (int i = 0; i < guestList.Count; i++)
{
    Console.WriteLine($"{guestList[i]}");
}
   
    