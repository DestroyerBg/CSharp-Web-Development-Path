int[] numCollection = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int n=int.Parse(Console.ReadLine());
for (int i = 0; i < numCollection.Length; i++)
{
    for (int k = i+1; k < numCollection.Length; k++)
    {
        if (numCollection[i] + numCollection[k]==n)
        {
            Console.Write($"{numCollection[i]} {numCollection[k]} ");
            Console.WriteLine();

        }
    }

}
