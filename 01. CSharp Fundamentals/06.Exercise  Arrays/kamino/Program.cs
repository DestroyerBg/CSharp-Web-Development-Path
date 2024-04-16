int n = int.Parse(Console.ReadLine());

int[] bestArray = new int[n];
int bestIndex = 0;
int bestLeng = 0;
int bestSum = 0;
int counter = 0;
int bestCounter = 0;
string input = Console.ReadLine();
char[] charSeparators = new char[] { '!' };

while (input != "Clone them!")
{
    counter++;
    int[] currentArray = new int[n];
    currentArray = input.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    int currentIndex = 0;
    int currentLeng = 0;
    int currentSum = currentArray[n - 1];
    int index = 0;
    int leng = 0;

    for (int i = 0; i < n - 1; i++)
    {
        currentSum += currentArray[i];
        if (currentArray[i] == currentArray[i + 1])
        {
            if (leng == 0) index = i;
            leng++;
        }
        else leng = 0;

        if (leng > currentLeng)
        {
            currentLeng = leng;
            currentIndex = index;
        }
    }

    if ((currentLeng > bestLeng) ||
        (currentLeng == bestLeng && currentIndex < bestIndex) ||
        (currentLeng == bestLeng && currentIndex == bestIndex && currentSum > bestSum))
    {
        bestArray = currentArray;
        bestLeng = currentLeng;
        bestIndex = currentIndex;
        bestSum = currentSum;
        bestCounter = counter;
    }
    input = Console.ReadLine();
}

Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");
for (int i = 0; i < n; i++)
{
    Console.Write(bestArray[i] + " ");
}
Console.WriteLine();
    
