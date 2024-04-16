int evenSum = 0;
int oddSum = 0;
int diff = 0;
int[] numbers= Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i] % 2==0)
    {
        evenSum += numbers[i];
    
    }
    else if (numbers[i] % 2 == 1)
    {
        oddSum += numbers[i];
    }

}
diff = evenSum - oddSum;
Console.WriteLine(diff);

