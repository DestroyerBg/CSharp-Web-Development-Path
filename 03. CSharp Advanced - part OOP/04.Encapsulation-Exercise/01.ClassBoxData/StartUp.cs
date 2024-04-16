using _01.ClassBoxData;

double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());
try
{
    var paralelepiped = new Box(length, width, height);
    Console.WriteLine(paralelepiped.ToString());
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
}

