using System.Collections;
using System.Collections.Immutable;

int[] numbers = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
Array.Sort(numbers, new Comparator());
Console.WriteLine(string.Join(" ",numbers));
public class Comparator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        if (x % 2 == 0 && y % 2 != 0)
        {
            return -1;
        }
        else if (x % 2 != 0 && y % 2 == 0)
        {
            return 1;
        }
        return x.CompareTo(y);
    }
}