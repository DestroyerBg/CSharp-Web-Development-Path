namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfTheMatrix = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];
            int[,] matrix = ReadMatrixFromConsole(rows, cols);
            int bestSum = int.MinValue;
            int bestIndexRow = -1;
            int bestIndexCol = -1;
            for (int row = 0; row < rows-1; row++)
            {
                int currSum = 0;
                for (int col = 0; col < cols-1; col++)
                {
                    currSum = matrix[row, col]+matrix[row,col+1]+ matrix[row+1, col] + matrix[row+1, col + 1];
                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        bestIndexRow = row;
                        bestIndexCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[bestIndexRow,bestIndexCol]} {matrix[bestIndexRow, bestIndexCol+1]}");
            Console.WriteLine($"{matrix[bestIndexRow+1, bestIndexCol]} {matrix[bestIndexRow+1, bestIndexCol + 1]}");
            Console.WriteLine(bestSum);
        }

        public static int[,] ReadMatrixFromConsole(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] newElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newElements[col];
                }
            }

            return matrix;
        }
    }
}