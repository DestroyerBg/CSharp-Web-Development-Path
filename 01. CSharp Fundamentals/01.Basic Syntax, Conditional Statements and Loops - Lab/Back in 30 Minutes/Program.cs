int hours = int.Parse(Console.ReadLine());
int minutes = int.Parse(Console.ReadLine());
int minutesPlusThirty = minutes + 30;
if (minutesPlusThirty > 59)
{
    hours += 1;
    minutesPlusThirty -= 60;
    if (hours > 23)
    {
        hours = 0;
        Console.WriteLine($"{hours}:{minutesPlusThirty:d2}");

    }
    else
    {

        Console.WriteLine($"{hours}:{minutesPlusThirty:d2}");
    }
    

}
else
{
    Console.WriteLine($"{hours}:{minutesPlusThirty:d2}");

}
