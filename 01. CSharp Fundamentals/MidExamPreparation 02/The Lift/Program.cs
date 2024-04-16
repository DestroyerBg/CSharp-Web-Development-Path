int peopleWaitingForTheLift = int.Parse(Console.ReadLine());
List<int> currStateOfLift = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
bool isFull = false;
for (int i = 0; i < currStateOfLift.Count; i++)
{
    if (currStateOfLift[i] + peopleWaitingForTheLift > 4)
    {
        peopleWaitingForTheLift -= 4 - currStateOfLift[i];
        currStateOfLift[i] = 4;
    }
    else if (currStateOfLift[i] + peopleWaitingForTheLift <= 4)
    {
        currStateOfLift[i] += peopleWaitingForTheLift;
        peopleWaitingForTheLift = 0;
        break;
    }

}


for (int i = 0; i < currStateOfLift.Count; i++)
{
    if (currStateOfLift[i] != 4)
    {
        isFull = false;
        break;

    }

    isFull = true;
}

if (peopleWaitingForTheLift > 0)
{
    Console.WriteLine($"There isn't enough space! {peopleWaitingForTheLift} people in a queue!");
}
else if (isFull == true && peopleWaitingForTheLift==0)
{

}
else if (isFull == false)
{
    Console.WriteLine("The lift has empty spots!");
}

Console.WriteLine(string.Join(" ",currStateOfLift));

