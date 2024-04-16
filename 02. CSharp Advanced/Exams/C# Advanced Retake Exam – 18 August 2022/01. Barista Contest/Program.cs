using System.Security;

var coffee = new Queue<int>
(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var milk = new Stack<int>
(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var drinkDictionary = new Dictionary<string, int>();
drinkDictionary.Add("Cortado", 50);
drinkDictionary.Add("Espresso", 75);
drinkDictionary.Add("Capuccino", 100);
drinkDictionary.Add("Americano", 150);
drinkDictionary.Add("Latte", 200);
var drinksMade = new Dictionary<string, int>();
while (coffee.Any() && milk.Any())
{
    int currCoffe = coffee.Dequeue();
    int currMilk = milk.Pop();
    int multiply = currCoffe + currMilk;
    if (drinkDictionary.Any(v=>v.Value == multiply))
    {
        string drink = drinkDictionary.First(d=>d.Value == multiply).Key;
        if (!drinksMade.ContainsKey(drink))
        {
            drinksMade.Add(drink,0);
        }
        drinksMade[drink]++;
    }
    else
    {
        currMilk -= 5;
        milk.Push(currMilk);
    }
}

if (!coffee.Any() && !milk.Any())
{
    Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
}
else
{
    Console.WriteLine($"Nina needs to exercise more! She didn't use all the coffee and milk!");
}

if (coffee.Any())
{
    Console.WriteLine($"Coffee left: {string.Join(", ",coffee)}");
}
else
{
    Console.WriteLine($"Coffee left: none");
}

if (milk.Any())
{
    Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
}
else
{
    Console.WriteLine($"Milk left: none");
}

if (drinksMade.Any())
{
    foreach (var drink in drinksMade.OrderBy(n=>n.Value).ThenByDescending(n=>n.Key))
    {
        Console.WriteLine($"{drink.Key}: {drink.Value}");
    }
}

