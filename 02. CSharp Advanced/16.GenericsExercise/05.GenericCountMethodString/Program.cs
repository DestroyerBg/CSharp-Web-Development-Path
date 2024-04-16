using _05.GenericCountMethodString;

int numberOfInputs = int.Parse(Console.ReadLine());
var box = new Box<string>();
for (int i = 0; i < numberOfInputs; i++)
{
    box.Add(Console.ReadLine());
}
string itemToCompare = Console.ReadLine();
Console.WriteLine(box.FindEqual(itemToCompare));