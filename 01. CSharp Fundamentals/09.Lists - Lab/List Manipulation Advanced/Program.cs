List<int> numbers = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
string command = string.Empty;
bool isChanged = false;
while ((command = Console.ReadLine()) != "end")
{
    List<string> arguments = command.Split().ToList();
    string argument = arguments[0];

    if (argument == "Add")
    {
        int argumentNum = int.Parse(arguments[1]);
        numbers.Add(argumentNum);
        isChanged = true;
    }
    else if (argument == "Remove")
    {
        int argumentNum = int.Parse(arguments[1]);
        numbers.Remove(argumentNum);
        isChanged = true;
    }
    else if (argument == "RemoveAt")
    {
        int argumentNum = int.Parse(arguments[1]);
        numbers.RemoveAt(argumentNum);
        isChanged = true;
    }
    else if (argument == "Insert")
    {
        int argumentNum = int.Parse(arguments[1]);
        int givenNumber = int.Parse(arguments[2]);
        numbers.Insert(givenNumber, argumentNum);
        isChanged = true;
    }
    else if (argument == "Contains")
    {
        int argumentNum = int.Parse(arguments[1]);
        if (numbers.Contains(argumentNum) == true)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No such number");
        }


    }
    else if (argument == "PrintEven")
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 0)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
        Console.WriteLine();
    }
    else if (argument == "PrintOdd")
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] % 2 == 1)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
        Console.WriteLine();
    }
    else if (argument == "GetSum")
    {
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine(sum);
    }
    else if (argument == "Filter")
    {
        string condition = arguments[1];
        int numberToCompare = int.Parse(arguments[2]);
        if (condition == "<")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < numberToCompare)
                {
                    Console.Write($"{numbers[i]} ");
                }

            }
            Console.WriteLine();
        }
        else if (condition == "<=")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= numberToCompare)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }
        else if (condition == ">")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > numberToCompare)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }
        else if (condition == ">=")
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] >= numberToCompare)
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }

    }

}
if (isChanged==true)
{
    Console.WriteLine(string.Join(" ", numbers));
}
else
{
    return;
}



