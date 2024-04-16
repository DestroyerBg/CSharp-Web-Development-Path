using _08.Threeuple;
using System.Text;

string[] input1 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
StringBuilder name = new StringBuilder(input1[0] + " " + input1[1]);
var threeuple1 = new Threeuple<string, string, string>(name.ToString().TrimEnd(), input1[2], input1[3]);
string[] input2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
bool isDrunk = input2[2] == "drunk";
var threeuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), isDrunk);
string[] input3 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();
var threeuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);
Console.WriteLine(threeuple1.ToString());
Console.WriteLine(threeuple2.ToString());
Console.WriteLine(threeuple3.ToString());
