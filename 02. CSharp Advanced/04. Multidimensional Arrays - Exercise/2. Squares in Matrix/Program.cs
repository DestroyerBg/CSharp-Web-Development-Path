int[] sizeOfTheMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
string[,] matrix = ReadMatrixFromConsole(rows, cols);
int totalCount = 0;
for (int row = 0; row < rows-1; row++)
{
    for (int col = 0; col < cols-1; col++)
    {
        string currElement = matrix[row, col];
        if (currElement == matrix[row,col+1] 
            && currElement == matrix[row+1,col] 
            && currElement == matrix[row+1,col+1])
        {
            totalCount++;
        }
    }
}

Console.WriteLine(totalCount);

static string[,] ReadMatrixFromConsole(int rows, int cols)
{
    string[,] matrix = new string[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        string[] newElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = newElements[col];
        }
    }

    return matrix;
}
         
