namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrixFromConsole(sizeOfTheMatrix);
            char symbolToSearch = char.Parse(Console.ReadLine());
            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    if (matrix[row, col] == symbolToSearch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbolToSearch} does not occur in the matrix");
        }

        public static char[,] ReadMatrixFromConsole(int sizeOfTheMatrix)
        {
            char[,] matrix = new char[sizeOfTheMatrix, sizeOfTheMatrix];
            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                char[] newElements = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    matrix[row, col] = newElements[col];
                }
            }

            return matrix;
        }
    }
}