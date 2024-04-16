int[] numCollection = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int sum1 = 0;
int sum2 = 0;
bool isFound = false;
  
for (int i = 0; i < numCollection.Length; i++)
{
    for (int k = 0; k < i; k++)
    {
        sum1 += numCollection[k];
    }
    for (int l = i+1; l < numCollection.Length; l++)
    {
        sum2+= numCollection[l];
    }
    if (sum1 ==sum2) 
    {
      int arrIndex = Array.IndexOf(numCollection, numCollection[i]);
        Console.WriteLine(arrIndex);
        isFound = true;
        break;
    }
    sum1 = 0;
    sum2 = 0;

}
if (isFound==false)
{
    Console.WriteLine("no");
}