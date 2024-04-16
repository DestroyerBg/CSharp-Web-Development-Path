using System.Collections.Generic;

List<int> list = Console
    .ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();
    string input=string.Empty;
while (((input = Console.ReadLine()) != "end"))
{
    List<string> argumentList = input.Split().ToList();
    if (argumentList[0] == "Delete")
    {
        int numberToSearch = int.Parse(argumentList[1]);
        for (int i = 0; i < list.Count; i++)
        {
            if (list.Contains(numberToSearch)==true)
            {
                list.Remove(numberToSearch);
            }
            else
            {
                continue;
            }

        }
    }
   
    else if (argumentList[0] == "Insert")
    {
        int element = int.Parse(argumentList[1]);
        int position= int.Parse(argumentList[2]);
        list.Insert(position,element);
    }
}

Console.WriteLine(string.Join(" ",list));