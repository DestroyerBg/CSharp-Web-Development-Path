int[] numbers = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
string condition = Console.ReadLine();
int start = numbers[0];
int end = numbers[1];
Func<int,int, List<int>> getRange = (start, end) =>
{
    var range = new List<int>();
    for (int i = start; i <= end; i++)
    {
        range.Add(i);
    }
    return range;
};
var range = getRange(start, end);
Func<int,string,bool> everOrOdd = (number, condition) =>
{
    if (condition == "even")
    {
        return number % 2 == 0;
    }
    else
    {
        return number % 2 != 0;
    }
};
var filteredNums = new List<int>();
foreach (var number in range)
{
    if (everOrOdd(number,condition))
    {
        filteredNums.Add(number);
    }
}

Console.WriteLine(string.Join(" ",filteredNums));