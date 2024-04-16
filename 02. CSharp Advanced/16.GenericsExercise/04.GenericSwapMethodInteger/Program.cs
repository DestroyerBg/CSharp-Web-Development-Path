
using _04.GenericSwapMethodInteger;

int numberOfInputs = int.Parse(Console.ReadLine());
var listSwap = new GenericSwap<int>();
for (int i = 0; i < numberOfInputs; i++)
{
    listSwap.Add(int.Parse(Console.ReadLine()));
}

int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int index1 = arr[0];
int index2 = arr[1];
listSwap.Swap(index1, index2);
Console.WriteLine(listSwap.ToString());