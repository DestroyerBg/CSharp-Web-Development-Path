using System;
using System.Globalization;

int[] arr1 = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int[] arr2 = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
bool isDifferent = false;
int sum = 0;
for (int i = 0; i < arr1.Length; i++)
{
    if (arr1[i] != arr2[i])
    {
        Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
        isDifferent = true;
        break;
        


    }
    sum += arr1[i];
    
}
if (isDifferent == false)
{
    Console.WriteLine($"Arrays are identical. Sum: {sum}");

}
else if (isDifferent==true)
{

}

