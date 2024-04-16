int[] sizeOfTheMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
int[,] matrix = ReadMatrixFromConsole(rows, cols);
int maxSum = int.MinValue;
int bestElementRow = -1;
int bestElementCol = -1;
for (int row = 0; row < rows - 2; row++)
{
    
    for (int col = 0; col < cols - 2; col++)
    {
       int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                  matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                  matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
        if (currSum>maxSum)
        {
            maxSum = currSum;
            bestElementRow = row;
            bestElementCol = col;
        }

    }
}
Console.WriteLine($"Sum = {maxSum}");
for (int row = bestElementRow; row < bestElementRow+3; row++)
{
    for (int col = bestElementCol; col < bestElementCol+3; col++)
    {
        Console.Write($"{matrix[row, col]} ");
    }

    Console.WriteLine();
}
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
         
