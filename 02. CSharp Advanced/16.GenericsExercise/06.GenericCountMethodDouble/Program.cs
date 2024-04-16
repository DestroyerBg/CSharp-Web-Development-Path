using _06.GenericCountMethodDouble;

int numberOfInputs = int.Parse(Console.ReadLine());
var box = new Box<double>();
for (int i = 0; i < numberOfInputs; i++)
{
    box.Add(double.Parse(Console.ReadLine()));
}
double itemToCompare = double.Parse(Console.ReadLine());
Console.WriteLine(box.FindEqual(itemToCompare));