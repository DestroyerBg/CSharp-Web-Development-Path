using System;
using System.Linq;

namespace SumOfCoins
{
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var possibleCoins = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int sumToBack = int.Parse(Console.ReadLine());
            var selectedCoins = ChooseCoins(possibleCoins, sumToBack);
            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            if (selectedCoins != null)
            {
                foreach (var coins in selectedCoins.OrderByDescending(n => n.Value))
                {
                    Console.WriteLine($"{coins.Value} coin(s) with value {coins.Key}");
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var sortCoins = coins.OrderByDescending(c => c).ToArray();
            var coinDictionary = new Dictionary<int, int>();
            int currSum = targetSum;
            int coinIndex = 0;
            while (currSum > 0)
            {
                int currCoin = sortCoins[coinIndex];
                if (currCoin <= currSum)
                {
                    currSum -= currCoin;
                    if (!coinDictionary.ContainsKey(currCoin))
                    {
                        coinDictionary.Add(currCoin,0);
                    }

                    coinDictionary[currCoin]++;
                }
                else
                {
                    if (coinIndex+1<=sortCoins.Length-1)
                    {
                        coinIndex++;
                    }
                }

                if (currSum < 0 )
                {
                    coinDictionary = new Dictionary<int, int>();
                    return coinDictionary;
                }
            }
            return coinDictionary;
        }
    }
}