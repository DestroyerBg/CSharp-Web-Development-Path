using _03.GenericSwapMethodString;

int numberOfInputs = int.Parse(Console.ReadLine());
var listSwap = new GenericSwap<string>();
for (int i = 0; i < numberOfInputs; i++)
{
    listSwap.Add(Console.ReadLine());
}

int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int index1 = arr[0];
int index2 = arr[1];
listSwap.Swap(index1,index2);
Console.WriteLine(listSwap.ToString());