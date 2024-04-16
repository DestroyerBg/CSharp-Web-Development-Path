using System;

List<int> integers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
string input = string.Empty;
while ((input = Console.ReadLine()) != "End")
{
    List<string> arguments = input.Split().ToList();
    if (arguments[0] == "Add")
    {
        int number = int.Parse(arguments[1]);
       
        integers.Add(number);
    }
    else if (arguments[0] == "Insert")
    {
        int number = int.Parse(arguments[1]);
        int index = int.Parse(arguments[2]);
        if (index > integers.Count-1 || index<0)
        {
            Console.WriteLine($"Invalid index");
            continue;
        }
        else
        {
        integers.Insert(index, number);
            
        }
    }
    else if (arguments[0] == "Remove")
    {
        int index = int.Parse(arguments[1]);
        if (index > integers.Count-1 || index < 0)
        {
            Console.WriteLine($"Invalid index");
            continue;
        }
        else
        {
        integers.RemoveAt(index);
            
        }
    }
    else if (arguments[0] == "Shift")
    {
        if (arguments[1] == "left")
        {
            int count = int.Parse(arguments[2]);
            for (int i = 0; i < count; i++)
            {
                integers.Add(integers[0]);
                integers.RemoveAt(0);




            }


        }
        else if (arguments[1] == "right")
        {
            int count = int.Parse(arguments[2]);
            for (int i = 0; i < count; i++)
            {
               integers.Insert(0, integers[integers.Count-1]);
               integers.RemoveAt(integers.Count-1);




            }
        }
    }
}

Console.WriteLine(string.Join(" ", integers));