int n=int.Parse(Console.ReadLine());
int sum = 0;
for (int i = 1; i <= n; i++)
{
    int charNum=(int)char.Parse(Console.ReadLine());
    sum += charNum;
}
Console.WriteLine($"The sum equals: {sum}");