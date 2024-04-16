using System.Runtime.ExceptionServices;

List<int> numbers = Console.
    ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
List<int> numbersTwo = Console.
    ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
List<int> combinedList= new List<int>();
if (numbers.Count>numbersTwo.Count)
{
    for (int i = 0; i < numbers.Count; i++)
    {
        combinedList.Add(numbers[i]);
        if (i>numbersTwo.Count-1)
        {
            continue;
        }
        for (int k = i; k <= i; k++)
        {
            combinedList.Add(numbersTwo[k]);
        }
    }   
Console.WriteLine(string.Join(" ", combinedList));
    
}

else if (numbersTwo.Count>numbers.Count)
{
    for (int i = 0; i < numbers.Count; i++)
    {
        combinedList.Add(numbers[i]);
        for (int k = i; k <= i; k++)
        {
            combinedList.Add(numbersTwo[k]);
        }
        

    }
    for (int i = numbers.Count; i < numbersTwo.Count; i++)
    {
        combinedList.Add(numbersTwo[i]);
    }
    Console.WriteLine(string.Join(" ", combinedList));
}
else
{
    for (int i = 0; i < numbers.Count; i++)
    {
        combinedList.Add(numbers[i]);
        for (int k = i; k <= i; k++)
        {
            combinedList.Add(numbersTwo[k]);
        }
    }
    Console.WriteLine(string.Join(" ", combinedList));
}


