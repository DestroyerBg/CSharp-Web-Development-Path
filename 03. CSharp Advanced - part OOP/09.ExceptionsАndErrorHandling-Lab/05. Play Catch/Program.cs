using System.Runtime.InteropServices;
using System.Text;

var numbers = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
int exceptionsCount = 0;
while (exceptionsCount != 3)
{
    try
    {
        string[] input = Console.ReadLine().Split();
        string instruction = input[0];
        if (instruction == "Replace")
        {
            int index = int.Parse(input[1]);
            int replace = int.Parse(input[2]);
            ReplaceElements(index,replace,numbers);
        }
        else if (instruction == "Print")
        {
            int startIndex = int.Parse(input[1]);
            int endIndex = int.Parse(input[2]);
            Print(startIndex, endIndex);
        }
        else if (instruction == "Show")
        {
           int index = int.Parse(input[1]);
            Show(index);
        }
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine($"The index does not exist!");
        exceptionsCount++;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The variable is not in the correct format!");
        exceptionsCount++;
    }

}

void Show(int index)
{
    Console.WriteLine(numbers[index]);
}

void Print(int startIndex, int endIndex)
{
    var print = new List<int>();
    for (int i = startIndex; i <= endIndex; i++)
    {
        print.Add(numbers[i]);
    }

    Console.WriteLine(string.Join(", ", print));
}

void ReplaceElements(int index, int replace, List<int> numbers)
{
    numbers[index] = replace;
}

Console.WriteLine(string.Join(", ",numbers));

