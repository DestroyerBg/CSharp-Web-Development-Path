using System.Data;
using System.Diagnostics.CodeAnalysis;

int[] sizeOfTheMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
string[,] matrix = ReadMatrixFromConsole(rows, cols);
string input = string.Empty;
while ((input = Console.ReadLine()) != "END")
{
    string[] data = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    if (data.Length != 5)
    {
        Console.WriteLine("Invalid input!");
        continue;
    }
    if (CheckInstruction(data[0]) == true)
    {
        int row1 = int.Parse(data[1]);
        int col1 = int.Parse(data[2]);
        int row2 = int.Parse(data[3]);
        int col2 = int.Parse(data[4]);
        Swap(row1, col1, row2, col2, matrix, rows, cols);
    }

}
static string[,] Swap(int row1, int col1, int row2, int col2, string[,] matrix, int rows, int cols)
{
    bool isValid = IsValid(row1, col1, row2, col2, matrix, rows, cols);
    if (isValid == false)
    {
        Console.WriteLine("Invalid input!");
        return matrix;
    }
    string elementOne = matrix[row1, col1];
    string elementTwo = matrix[row2, col2];
    matrix[row1, col1] = elementTwo;
    matrix[row2, col2] = elementOne;
    PrintMatrix(matrix);
    return matrix;
}

static bool CheckInstruction(string instruction)
{
    if (instruction == "swap")
    {
        return true;
    }

    Console.WriteLine("Invalid input!");
    return false;
}
static bool IsValid(int row1, int col1, int row2, int col2, string[,] matrix, int rows, int cols)
{
    if (row1 < 0 || row1 > rows || col1 < 0 || col1 > cols  ||
    row2 < 0 || row2 > rows  || col2 < 0 || col2 > cols)
    {
        return false;
    }

    return true;
}
static void PrintMatrix(string[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            Console.Write($"{matrix[row, col]} ");
        }

        Console.WriteLine();
    }
}
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


