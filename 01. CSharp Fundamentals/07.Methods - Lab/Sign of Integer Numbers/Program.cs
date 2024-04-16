int n = int.Parse(Console.ReadLine());

ChecksNumber(n);

static void ChecksNumber(int n)
{
    if (n == 0)
    {
        Console.WriteLine($"The number {n} is zero.");

    }
    else if (n > 0)
    {
        Console.WriteLine($"The number {n} is positive.");

    }
    else if (n < 0)
    {
        Console.WriteLine($"The number {n} is negative.");
    }
}