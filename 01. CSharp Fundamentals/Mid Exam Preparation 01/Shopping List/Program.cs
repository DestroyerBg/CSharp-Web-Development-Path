List<string> listOfProducts = Console
    .ReadLine()
    .Split("!")
    .ToList();
string input = string.Empty;
while ((input = Console.ReadLine()) != "Go Shopping!")
{
    List<string> commands = input.Split().ToList();
    if (commands[0]== "Urgent")
    {
        string item = commands[1];
        if (listOfProducts.Contains(item)==false)
        {
            listOfProducts.Insert(0,item);
        }

       
    }
    else if (commands[0] == "Unnecessary")
    {
        string item = commands[1];
        if (listOfProducts.Contains(item) == true)
        {
            listOfProducts.Remove(item);
        }

    }
    else if (commands[0] == "Correct")
    {
        string oldItem= commands[1];
        string newItem= commands[2];
        if (listOfProducts.Contains(oldItem))
        {
            int index= listOfProducts.IndexOf(oldItem);
            listOfProducts.RemoveAt(index);
            listOfProducts.Insert(index,newItem);
        }
    }
    else if (commands[0] == "Rearrange")
    {
        string item= commands[1];
        if (listOfProducts.Contains(item))
        {
            int index=listOfProducts.IndexOf(item);
            listOfProducts.RemoveAt(index);
            listOfProducts.Add(item);
        }

    }
}
Console.WriteLine(string.Join(", ", listOfProducts));
