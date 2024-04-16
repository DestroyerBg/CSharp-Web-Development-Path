string[] input = Console.ReadLine().Split();
int sum = 0;
for (int i = 0; i < input.Length; i++)
{
    string currElement = input[i];
    try
    {
        int number = int.Parse(currElement);
        sum += number;
    }
    catch (FormatException e)
    {
        Console.WriteLine($"The element '{currElement}' is in wrong format!");
    }
    catch (OverflowException e)
    {
        Console.WriteLine($"The element '{currElement}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{currElement}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");