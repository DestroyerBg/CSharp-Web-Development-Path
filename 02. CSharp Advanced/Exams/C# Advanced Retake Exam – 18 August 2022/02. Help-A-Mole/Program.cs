using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheMatrix = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrixFromConsole(sizeOfTheMatrix, sizeOfTheMatrix);
            int muleRow = -1;
            int muleCol = -1;
            int firstSpecialLocationRow = -1;
            int firstSpecialLocationCol = -1;
            int secondSpecialLocationRow = -1;
            int secondSpecialLocationCol = -1;
            for (int row = 0; row < sizeOfTheMatrix; row++)
            {
                for (int col = 0; col < sizeOfTheMatrix; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        muleRow = row;
                        muleCol = col;
                    }
                    else if (matrix[row,col] == 'S')
                    {
                        if (firstSpecialLocationRow == -1 && firstSpecialLocationCol == -1)
                        {
                            firstSpecialLocationRow = row;
                            firstSpecialLocationCol = col;
                        }
                        else
                        {
                            secondSpecialLocationRow = row;
                            secondSpecialLocationCol = col;
                        }
                    }
                }
            }

            int mulePoints = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End" && mulePoints < 25)
            {
                if (input == "up")
                {
                    if (muleRow - 1 < 0)
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                        continue;
                    }

                    matrix[muleRow, muleCol] = '-';
                    muleRow--;
                }
                else if (input == "down")
                {
                    if (muleRow + 1 > sizeOfTheMatrix - 1)
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                        continue;
                    }
                    matrix[muleRow, muleCol] = '-';
                    muleRow++;
                }
                else if (input == "left")
                {
                    if (muleCol - 1 < 0)
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                        continue;
                    }
                    matrix[muleRow, muleCol] = '-';
                    muleCol--;
                }
                else if (input == "right")
                {
                    if (muleCol + 1 > sizeOfTheMatrix - 1)
                    {
                        Console.WriteLine($"Don't try to escape the playing field!");
                        continue;
                    }
                    matrix[muleRow, muleCol] = '-';
                    muleCol++;
                }

                if (matrix[muleRow, muleCol] == 'S')
                {
                    if (muleRow == firstSpecialLocationRow && muleCol == firstSpecialLocationCol)
                    {
                        matrix[muleRow, muleCol] = '-';
                        muleRow = secondSpecialLocationRow;
                        muleCol = secondSpecialLocationCol;
                        mulePoints -= 3;
                    }
                    else
                    {
                        matrix[muleRow, muleCol] = '-';
                        muleRow = firstSpecialLocationRow;
                        muleCol = firstSpecialLocationCol;
                        mulePoints -= 3;
                    }
                }
                else if (Char.IsDigit(matrix[muleRow, muleCol]))
                {
                    mulePoints += int.Parse(matrix[muleRow, muleCol].ToString());
                }
            }

            matrix[muleRow, muleCol] = 'M';
            if (mulePoints >= 25)
            {
                Console.WriteLine($"Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {mulePoints} points.");
            }
            else
            {
                Console.WriteLine($"Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {mulePoints} points.");
            }
            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }

                Console.WriteLine();
            }
        }
        static char[,] ReadMatrixFromConsole(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string newElements = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = newElements[col];
                }
            }

            return matrix;
        }
    }
}
