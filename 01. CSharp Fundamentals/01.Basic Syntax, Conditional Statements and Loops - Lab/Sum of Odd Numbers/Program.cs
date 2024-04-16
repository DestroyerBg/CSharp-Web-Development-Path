int n = int.Parse(Console.ReadLine());
int countNumber = 1;
int sum = 0;
for (int i = 1; countNumber <= n; i+=2)
{
    Console.WriteLine(i);
    sum += i;
    countNumber++;

}
Console.WriteLine($"Sum: {sum}");