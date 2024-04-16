using Microsoft.VisualBasic;
using System;

var monsters = new Queue<int>
(Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var attackers = new Stack<int>
(Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
int totalMonstersKilled = 0;
while (monsters.Any() && attackers.Any())
{
    if (attackers.Peek() >= monsters.Peek())
    {
        totalMonstersKilled++;
        int attack = attackers.Pop();
        if (attackers.Any())
        {
            int nextAttack = attackers.Pop() + (attack - monsters.Dequeue());
            attackers.Push(nextAttack);
            continue;
        }

        if (attack - monsters.Peek() != 0)
        {
            attackers.Push(attack - monsters.Dequeue());
            continue;
        }
        else
        {
            monsters.Dequeue();
        }
    }
    else
    {
        int currMonster = monsters.Dequeue() - attackers.Pop();
        monsters.Enqueue(currMonster);
    }
}

if (!monsters.Any())
{
    Console.WriteLine($"All monsters have been killed!");
}
if (!attackers.Any())
{
    Console.WriteLine($"The soldier has been defeated.");
}


Console.WriteLine($"Total monsters killed: {totalMonstersKilled}");