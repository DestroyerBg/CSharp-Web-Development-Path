using _01.GenericBoxOfString;

int numberOfInputs = int.Parse(Console.ReadLine());
var box = new Box<string>();
for (int i = 0; i < numberOfInputs; i++)
{
    string input = Console.ReadLine();
    box.Add(input);
}

Console.WriteLine(box.ToString());
