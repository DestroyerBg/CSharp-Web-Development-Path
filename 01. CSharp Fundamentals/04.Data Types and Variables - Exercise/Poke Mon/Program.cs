int n=int.Parse(Console.ReadLine());
int m=int.Parse(Console.ReadLine());
int y=int.Parse(Console.ReadLine());
int targetCount = 0;

double percent = n * 0.5;
while (n >= m)
{
    n -= m;
    if (percent == n && y != 0)
    {
        n /= y;
    
    }
    targetCount++;

}
Console.WriteLine(n);
Console.WriteLine(targetCount);