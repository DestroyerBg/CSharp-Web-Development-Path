int lenght = int.Parse(Console.ReadLine());
string input = string.Empty;
int[] troops = new int[lenght];
int count = 0;
int currentCount = 0;
int index = 0;
int currArrSum = 0;
int currDna = 0;
int bestCount = 0;
int bestIndex = 0;
int bestSum = 0;
int bestDna = 1;

int[] clonedTroop = new int[troops.Length];

while ((input = Console.ReadLine()) != "Clone them!")
{
    troops = input
        .Split('!', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    currDna++;
    count = 0;
    index = 0;
    currArrSum = 0;
    currentCount = 0;
    for (int i = 0; i < troops.Length; i++)
    {
        if (troops[i] != 1)
        {
            count = 0;
            continue;
        }
        count++;

        if (count > currentCount)
        {
            currentCount = count;
            index = i;

        }
    }
        index = index - currentCount + 1;
        currArrSum = troops.Sum();
        if (currentCount > bestCount || (bestCount == currentCount && bestIndex > index) || (bestCount == currentCount && bestIndex == index && currArrSum > bestSum))
        {
            bestCount= currentCount;
            bestIndex= index;
            bestSum = currArrSum;
            bestDna= currDna;
            clonedTroop = troops;
        }
        
        
    }

   




Console.WriteLine($"Best DNA sample {bestDna} with sum: {bestSum}.");
for (int i = 0; i < clonedTroop.Length; i++)
{
    Console.Write($"{clonedTroop[i]} ");
}





