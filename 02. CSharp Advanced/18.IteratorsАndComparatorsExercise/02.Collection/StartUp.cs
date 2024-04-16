using _02.Collection;

string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
var iterator = new ListyIterator<string>(data);
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    if (input == "HasNext")
    {
        Console.WriteLine(iterator.HasNext());
    }
    else if (input == "Print")
    {
        Console.WriteLine(iterator.Print());
    }
    else if (input == "Move")
    {
        Console.WriteLine(iterator.Move());
    }
    else if (input == "PrintAll")
    {
        Console.WriteLine(string.Join(" ",iterator));
    }
}