using System.ComponentModel;
using System.Transactions;

int [] numCollection = Console
   .ReadLine()
   .Split()
   .Select(int.Parse)
   .ToArray();
int count = 0;
int bestCount = 0;
int bestCountSymbol = 0;
for (int i = 0; i < numCollection.Length; i++)
{
	for (int j = i; j < numCollection.Length; j++)
	{
		if (numCollection[i] == numCollection[j])
		{
			count++;
			if (count>bestCount )
			{
				bestCount = count;
				bestCountSymbol = numCollection[i];
			}

		
		}
		else 
		{
			count = 0;
			break; 
			
		
		}
		
	}
	count = 0;

}
for (int i = 0; i < bestCount; i++)
{
    Console.Write($"{bestCountSymbol} ");
}





