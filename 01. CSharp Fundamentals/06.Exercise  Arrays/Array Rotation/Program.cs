int[] array = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int n=int.Parse(Console.ReadLine());
for (int rotation = 0; rotation < n; rotation++)
{
    int temp = array[0];
    for (int i = 0; i < array.Length-1; i++)
    {
        array[i] = array[i+1];
        
        
    }
    array[array.Length - 1] = temp;
}
for (int i = 0; i < array.Length; i++)
{
    Console.Write($"{array[i]} ");

}
