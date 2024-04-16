namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrixFromConsole(sizeOfTheMatrix);
            int sum = 0;
            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }

        public static int[,] ReadMatrixFromConsole(int size)
        {
            int[,] matrix = new int[size,size];
            for (int row = 0; row < size; row++)
            {
                int[] newElements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = newElements[col];
                }
            }

            return matrix;
        }
    }
}