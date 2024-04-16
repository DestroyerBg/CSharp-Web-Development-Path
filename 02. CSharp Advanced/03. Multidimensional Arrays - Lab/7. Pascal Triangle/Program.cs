namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int size = int.Parse(Console.ReadLine());
                long[][] pascalTriangle = new long[size][];
                pascalTriangle[0] = new long[1] { 1 };
                for (int row = 1; row < size; row++)
                {
                    pascalTriangle[row] = new long[row + 1];
                    for (int col = 0; col < pascalTriangle[row].Length; col++)
                    {
                        if (col < pascalTriangle[row - 1].Length)
                        {
                            pascalTriangle[row][col] += pascalTriangle[row - 1][col];
                        }

                        if (col > 0)
                        {
                            pascalTriangle[row][col] += pascalTriangle[row - 1][col - 1];
                        }
                    }
                }
                PrintMatrix(pascalTriangle);
            }

        }
        private static void PrintMatrix(long[][] jaggedMatrix)
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
    }
}