List<int> wagons = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
int maxCapacityOfWagon = int.Parse(Console.ReadLine());
string input = string.Empty;
while ((input = Console.ReadLine()) != "end")
{
    List<string> commands = input.Split().ToList();
    if (commands[0] == "Add")
    {
        int passengers = int.Parse(commands[1]);
        wagons.Add(passengers);
    }
    else
    {
        int incomingPassengers = int.Parse(commands[0]);
        for (int i = 0; i < wagons.Count; i++)
        {
            if (incomingPassengers + wagons[i] > maxCapacityOfWagon)
            {
                continue;
            }

            wagons[i] += incomingPassengers;
            break;
        }
    }

}
Console.WriteLine(string.Join(" ", wagons));