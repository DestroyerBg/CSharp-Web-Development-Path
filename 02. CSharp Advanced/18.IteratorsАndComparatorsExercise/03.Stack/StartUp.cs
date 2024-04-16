using _02.CustomStack;
var customStack = new CustomStack<string>();
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input
        .Split(new string[]{" ",", "},StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    if (data[0] == "Push")
    {
        string[] itemsToPush = data.Skip(1).ToArray();
        for (int i = 0; i < itemsToPush.Length; i++)
        {
            customStack.Push(itemsToPush[i]);
        }
    }
    else if (data[0] == "Pop")
    {
        customStack.Pop();
    }
}

foreach (var item in customStack)
{
    Console.WriteLine(item);
}
foreach (var item in customStack)
{
    Console.WriteLine(item);
}