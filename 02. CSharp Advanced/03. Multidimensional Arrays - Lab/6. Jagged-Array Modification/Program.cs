namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int[][] jaggedMatrix = new int[matrixRows][];
            for (int row = 0; row < matrixRows; row++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                jaggedMatrix[row] = new int[data.Length];
                for (int col = 0; col < data.Length; col++)
                {
                    jaggedMatrix[row][col] = int.Parse(data[col]);
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string instruction = data[0];
                if (instruction=="Add")
                {
                    int row = int.Parse(data[1]);
                    int col = int.Parse(data[2]);
                    int value = int.Parse(data[3]);
                    IncrementValue(row, col, value, jaggedMatrix);
                }
                else if (instruction == "Subtract")
                {
                    int row = int.Parse(data[1]);
                    int col = int.Parse(data[2]);
                    int value = int.Parse(data[3]);
                    SubstractValue(row, col, value, jaggedMatrix);
                }
            }
            PrintMatrix(jaggedMatrix);
        }

        private static void PrintMatrix(int[][] jaggedMatrix)
        {
            for (int row = 0; row < jaggedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedMatrix[row].Length; col++)
                {
                    Console.Write($"{jaggedMatrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        private static int [][] SubstractValue(int row, int col, int value, int[][] jaggedMatrix)
        {
            if (row < 0 || col < 0 || row > jaggedMatrix.Length-1 || col > jaggedMatrix[row].Length-1)
            {
                Console.WriteLine($"Invalid coordinates");
                return jaggedMatrix;
            }
            jaggedMatrix[row][col] -= value;
            return jaggedMatrix;
        }

        private static int[][] IncrementValue(int row, int col, int value, int[][] jaggedMatrix)
        {
            if (row<0 || col < 0  || row>jaggedMatrix.Length - 1 || col > jaggedMatrix[row].Length - 1)
            {
                Console.WriteLine($"Invalid coordinates");
                return jaggedMatrix;
            }

            jaggedMatrix[row][col] += value;
            return jaggedMatrix;
        }
    }
}