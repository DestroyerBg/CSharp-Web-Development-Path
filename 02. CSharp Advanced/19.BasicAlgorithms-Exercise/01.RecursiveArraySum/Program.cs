using System.Runtime.CompilerServices;

int[] elements = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int index = 0;
int sum = Sum(elements, index);
Console.WriteLine(sum);
static int Sum(int[] elements, int index)
{
    if (index+1 == elements.Length)
    {
        return elements[index];
    }

    int sum = elements[index++];
    return sum+ Sum(elements, index); 
}