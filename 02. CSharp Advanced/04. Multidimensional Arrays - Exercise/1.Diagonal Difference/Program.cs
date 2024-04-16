int size = int.Parse(Console.ReadLine());
int[,] matrix = ReadMatrixFromConsole(size, size);
int primaryDiagonal = 0;
int reversedDiagonal = 0;
for (int row = 0; row < size; row++)
{
    for (int col = 0; col < size; col++)
    {
        int currElement = matrix[row, col];
        if (row == col)
        {
            primaryDiagonal += currElement;
        }

        if (col == size - 1 - row)
        {
            reversedDiagonal += currElement;
        }
    }
}

Console.WriteLine(Math.Abs(primaryDiagonal-reversedDiagonal));

static int[,] ReadMatrixFromConsole(int rows, int cols)
{
    int[,] matrix = new int[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        int[] newElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}
        
