try
{
    int n = int.Parse(Console.ReadLine());
    if (n < 0)
    {
        throw new Exception("Invalid number.");
    }

    Console.WriteLine($"{Math.Sqrt(n)}");
}
catch (Exception err)
{
    Console.WriteLine(err.Message);
}
finally
{
    Console.WriteLine($"Goodbye.");
}