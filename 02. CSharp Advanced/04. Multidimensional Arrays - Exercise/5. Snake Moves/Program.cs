int[] sizeOfTheMatrix = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int rows = sizeOfTheMatrix[0];
int cols = sizeOfTheMatrix[1];
string word = Console.ReadLine();
char[,] matrix = new char[rows, cols];
Queue<char> queue = new Queue<char>();
FillQueue(word, queue);
for (int row = 0; row < rows; row++)
{
    if (row % 2 == 0)
    {
        for (int col = 0; col < cols; col++)
        {
            matrix[row, col] = queue.Dequeue();
            if (queue.Count > 0)
            {
                FillQueue(word, queue);
            }
        }
    }
    else if (row %2 == 1)
    {
        for (int col = cols-1; col >= 0; col--)
        {
            matrix[row, col] = queue.Dequeue();
            if (queue.Count > 0)
            {
                FillQueue(word, queue);
            }
        }
    }
}
PrintMatrix(matrix, rows, cols);
void PrintMatrix(char[,] matrix, int rows, int cols)
{
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            Console.Write($"{matrix[row, col]}");
        }

        Console.WriteLine();
    }
}

Queue<char> FillQueue(string currWord, Queue<char> chars)
{
    for (int i = 0; i < currWord.Length; i++)
    {
        chars.Enqueue(currWord[i]);
    }

    return chars;
}



