List <int> numbers=Console
    .ReadLine ()
    .Split()
    .Select(int.Parse)
    .ToList();
string command=string.Empty;
while ((command=Console.ReadLine())!= "end")
{
    List<string> arguments= command.Split().ToList();
    string argument = arguments[0];
    int argumentNum= int.Parse(arguments[1]);
    if (argument== "Add")
    { 
    numbers.Add (argumentNum);
    
    }
    else if (argument == "Remove")
    {
        numbers.Remove(argumentNum);
    }
    else if (argument == "RemoveAt")
    {
        numbers.RemoveAt(argumentNum);
    }
    else if (argument == "Insert")
    {
        int givenNumber= int.Parse(arguments[2]);
        numbers.Insert(givenNumber, argumentNum);
    }
}
Console.WriteLine(string.Join(" ", numbers));