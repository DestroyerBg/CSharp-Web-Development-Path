using System.Text;
using _07.Tuple;

string[] input1 = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
StringBuilder name = new StringBuilder(input1[0] + " " + input1[1]);
string address = input1[2];
var customTuple1 = new CustomTuple<string,string>(name.ToString().TrimEnd(), address);
string[] input2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
var customTuple2 = new CustomTuple<string, int>(input2[0], int.Parse(input2[1]));
string[] input3 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
var customTuple3 = new CustomTuple<int, double>(int.Parse(input3[0]), double.Parse(input3[1]));
Console.WriteLine(customTuple1.ToString());
Console.WriteLine(customTuple2.ToString());
Console.WriteLine(customTuple3.ToString());
