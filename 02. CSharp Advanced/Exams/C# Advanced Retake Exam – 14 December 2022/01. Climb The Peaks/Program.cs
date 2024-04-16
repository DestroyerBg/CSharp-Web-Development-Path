using System.Linq.Expressions;

var portions = new Stack<int>
(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var dailyStamina = new Queue<int>
(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));
var mountainPeaks = new Dictionary<string, int>();
mountainPeaks.Add("Vihren", 80);
mountainPeaks.Add("Kutelo", 90);
mountainPeaks.Add("Banski Suhodol", 100);
mountainPeaks.Add("Polezhan", 60);
mountainPeaks.Add("Kamenitza", 70);
var peaks = new Queue<string>();
peaks.Enqueue("Vihren");
peaks.Enqueue("Kutelo");
peaks.Enqueue("Banski Suhodol");
peaks.Enqueue("Polezhan");
peaks.Enqueue("Kamenitza");
var conqueredPeaks = new Queue<string>();
for (int i = 0; i < 7; i++)
{
    int currPortion = portions.Pop();
    int currStamina = dailyStamina.Dequeue();
    string currPeak = peaks.Peek();
    if (currStamina + currPortion >= mountainPeaks[currPeak])
    {
        peaks.Dequeue();
        conqueredPeaks.Enqueue(currPeak);
    }

    if (!peaks.Any())
    {
        break;
    }
    if (!portions.Any() && !dailyStamina.Any() && peaks.Any())
    {
        break;
    }
}

if (!peaks.Any())
{
    Console.WriteLine($"Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");

}
else
{
    Console.WriteLine($"Alex failed! He has to organize his journey better next time -> @PIRINWINS");
}

if (conqueredPeaks.Any())
{
    Console.WriteLine($"Conquered peaks:");
    foreach (var peak in conqueredPeaks)
    {
        Console.WriteLine(peak);
    }
}