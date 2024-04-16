string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
int n=int.Parse(Console.ReadLine());
if (n > 0 && n < 8)
{
    Console.WriteLine(daysOfWeek[n - 1]);

}
else
{
    Console.WriteLine("Invalid day!");

}