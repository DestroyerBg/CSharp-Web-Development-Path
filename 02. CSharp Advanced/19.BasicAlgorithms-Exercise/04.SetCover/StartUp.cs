using System;
using System.Linq;

namespace SetCover
{
    using System.Collections.Generic;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int numberOfSets = int.Parse(Console.ReadLine());
            int[][] sets = new int[numberOfSets][];
            for (int row = 0; row < numberOfSets; row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                sets[row] = new int[currRow.Length];
                for (int col = 0; col < sets[row].Length; col++)
                {
                    sets[row][col] = currRow[col];
                }
            }

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ",set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] curr = sets.OrderByDescending(set => set.Count(universe.Contains)).First();
                selectedSets.Add(curr);
                sets.Remove(curr);
                foreach (var num in curr)
                {
                    universe.Remove(num);
                }
            }
            return selectedSets;
        }
    }
}
