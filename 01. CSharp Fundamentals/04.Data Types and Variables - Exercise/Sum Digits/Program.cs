int n=int.Parse(Console.ReadLine());
int sum = 0;
while (n > 0)
{
    int currNumber = n % 10;
    sum += currNumber;
    n = n / 10;


}
Console.WriteLine(sum);