using _02.GenericBoxOfInteger;

int numberOfInputs = int.Parse(Console.ReadLine());
var box = new Box<int>();
for (int i = 0; i < numberOfInputs; i++)
{
    int input = int.Parse(Console.ReadLine());
    box.Add(input);
}

Console.WriteLine(box.ToString());

