using System.Diagnostics.Contracts;

int number = int.Parse(Console.ReadLine());
int sum = 0;
int numToDivide = 0;

for (int i = 1; i <= number; i++)
{
    numToDivide = i;
    while (numToDivide > 0)
    {
       int currNum = numToDivide % 10;
        sum += currNum;
        numToDivide = numToDivide / 10;
    }
    if (sum==5 || sum==7 || sum==11)
    {
        Console.WriteLine($"{i} -> True");
    }
    else
    {
        Console.WriteLine($"{i} -> False");
    }
    sum = 0;
    
}
