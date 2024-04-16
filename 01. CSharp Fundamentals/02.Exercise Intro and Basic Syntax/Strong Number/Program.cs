int n=int.Parse(Console.ReadLine());
int k = n;
int remainder = 0;
int fact = 1;
int sum = 0;
while (k>0)
{
    remainder = k % 10;
    k = k / 10;
    for (int i = 1; i <= remainder; i++)
    {
        fact *= i;
        
    }
    sum += fact;
    fact = 1;
    
}
if (sum == n)
{
    Console.WriteLine("yes");
}
else 
{
    Console.WriteLine("no");

}


