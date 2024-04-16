int wagonsCount=int.Parse(Console.ReadLine());
int[] passengers=new int[wagonsCount];
int total = 0;
for (int i = 0; i < passengers.Length; i++)
{
    int passenger = int.Parse(Console.ReadLine());
    passengers[i]= passenger;
    total += passenger;
}

for (int j = 0; j < passengers.Length; j++)
{
    Console.Write($"{passengers[j]} ");
}
Console.WriteLine();
Console.WriteLine(total);
