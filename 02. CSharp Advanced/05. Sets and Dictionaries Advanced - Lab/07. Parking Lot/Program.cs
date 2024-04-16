string input = string.Empty;
var parkingLot = new HashSet<string>();
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string instruction = data[0];
    string carNumber = data[1];
    if (instruction == "IN")
    {
       parkingLot.Add(carNumber);
    }
    else if (instruction == "OUT")
    {
        if (parkingLot.Contains(carNumber))
        {
            parkingLot.Remove(carNumber);
        }
    }


}

if (parkingLot.Count>0)
{
    foreach (var carNum in parkingLot)
    {
        Console.WriteLine(carNum);
    }

    return;
}

Console.WriteLine($"Parking Lot is Empty");


