using System.ComponentModel;

int rows = int.Parse(Console.ReadLine());
int[][] matrix = ReadMatrixFromConsole(rows);
matrix = AnalyzeMatrix(matrix);
string input = string.Empty;
while ((input = Console.ReadLine()) != "End")
{
    string[] data = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .ToArray();
    string instruction = data[0];
    if (instruction == "Add")
    {
        int row = int.Parse(data[1]);
        int column = int.Parse(data[2]);
        int value = int.Parse(data[3]);
        Add(row, column, value, matrix);
    }
    else if (instruction == "Subtract")
    {
        int row = int.Parse(data[1]);
        int column = int.Parse(data[2]);
        int value = int.Parse(data[3]);
        Substract(row, column, value,matrix);
    }
}
PrintMatrix(matrix);
void PrintMatrix(int[][] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix[row].Length; col++)
        {
            Console.Write($"{matrix[row][col]} ");
        }

        Console.WriteLine();
    }
}


static int[][] ReadMatrixFromConsole(int rows)
{
    int[][] matrix = new int[rows][];
    for (int row = 0; row < rows; row++)
    {
        int[] newElements = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        matrix[row] = newElements;
    }

    return matrix;
}
static int[][] AnalyzeMatrix(int[][] matrix)
{
    for (int row = 0; row < matrix.GetLength(0)-1; row++)
    {
        if (matrix[row].Length == matrix[row+1].Length)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] *= 2;
                matrix[row + 1][col] *= 2;
            }
        }
        else 
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] /= 2;
            }

            for (int col = 0; col < matrix[row+1].Length; col++)
            {
                matrix[row+1][col] /= 2;
            }
        }
    }
    return matrix;
}

 static int[][] Add(int row, int column, int value, int[][] matrix)
{
    if (IsValid(row, column,matrix) == true)
    {
        matrix[row][column] += value;
    }

    return matrix;
}
static int[][] Substract(int row, int column, int value, int[][] matrix)
{
    if (IsValid(row, column, matrix) == true)
    {
        matrix[row][column] -= value;
    }

    return matrix;
}

static bool IsValid(int row, int column, int[][] matrix)
{
    if (row<0 || row>matrix.Length-1 || column<0 || column > matrix[row].Length-1)
    {
        return false;
    }

    return true;
}
