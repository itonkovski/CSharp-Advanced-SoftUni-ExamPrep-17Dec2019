using System;
using System.Linq;
using System.Collections.Generic;

namespace PresentDeliveryAgain
{
    class Program
    {
        static char[][] matrix;

        static int positionRow;
        static int positionCol;
        static bool isFound = false;
        static int niceKidsCounter;
        static int kidsWithoutPresents;

        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int neighbourhoodSize = int.Parse(Console.ReadLine());

            char[][] matrix = new char[neighbourhoodSize][];

            InitializeMatrix(matrix);

            string command;

            while ((command = Console.ReadLine()) != "Christmas morning"
                && presentsCount > 0)
            {
                if (command == "up")
                {
                    positionRow--;
                    char symbol = matrix[positionRow][positionCol];
                    if (symbol == 'V')
                    {
                        presentsCount--;
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow + 1][positionCol] = '-';
                    }
                    else if (symbol == 'X')
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow + 1][positionCol] = '-';
                    }
                    else if (symbol == 'C')
                    {
                        //up
                        if (matrix[positionRow - 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow - 1][positionCol] = '-';
                        }
                        //down
                        if (matrix[positionRow + 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow + 1][positionCol] = '-';
                        }
                        //left
                        if (matrix[positionRow][positionCol - 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol - 1] = '-';
                        }
                        //right
                        if (matrix[positionRow][positionCol + 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol + 1] = '-';
                        }
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow + 1][positionCol] = '-';
                    }
                    else
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow + 1][positionCol] = '-';
                    }
                }
                else if (command == "down")
                {
                    positionRow++;
                    char symbol = matrix[positionRow][positionCol];
                    if (symbol == 'V')
                    {
                        presentsCount--;
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow - 1][positionCol] = '-';
                    }
                    else if (symbol == 'X')
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow - 1][positionCol] = '-';
                    }
                    else if (symbol == 'C')
                    {
                        //up
                        if (matrix[positionRow - 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow - 1][positionCol] = '-';
                        }
                        //down
                        if (matrix[positionRow + 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow + 1][positionCol] = '-';
                        }
                        //left
                        if (matrix[positionRow][positionCol - 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol - 1] = '-';
                        }
                        //right
                        if (matrix[positionRow][positionCol + 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol + 1] = '-';
                        }
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow - 1][positionCol] = '-';
                    }
                    else
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow - 1][positionCol] = '-';
                    }
                }
                else if (command == "left")
                {
                    positionCol--;
                    char symbol = matrix[positionRow][positionCol];
                    if (symbol == 'V')
                    {
                        presentsCount--;
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol + 1] = '-';
                    }
                    else if (symbol == 'X')
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol + 1] = '-';
                    }
                    else if (symbol == 'C')
                    {
                        //up
                        if (matrix[positionRow - 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow - 1][positionCol] = '-';
                        }
                        //down
                        if (matrix[positionRow + 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow + 1][positionCol] = '-';
                        }
                        //left
                        if (matrix[positionRow][positionCol - 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol - 1] = '-';
                        }
                        //right
                        if (matrix[positionRow][positionCol + 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol + 1] = '-';
                        }
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol + 1] = '-';
                    }
                    else
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol + 1] = '-';
                    }
                }
                else if (command == "right")
                {
                    positionCol++;
                    char symbol = matrix[positionRow][positionCol];
                    if (symbol == 'V')
                    {
                        presentsCount--;
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol - 1] = '-';
                    }
                    else if (symbol == 'X')
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol - 1] = '-';
                    }
                    else if (symbol == 'C')
                    {
                        //up
                        if (matrix[positionRow - 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow - 1][positionCol] = '-';
                        }
                        //down
                        if (matrix[positionRow + 1][positionCol] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow + 1][positionCol] = '-';
                        }
                        //left
                        if (matrix[positionRow][positionCol - 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol - 1] = '-';
                        }
                        //right
                        if (matrix[positionRow][positionCol + 1] != '-')
                        {
                            presentsCount--;
                            matrix[positionRow][positionCol + 1] = '-';
                        }
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol - 1] = '-';
                    }
                    else
                    {
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow][positionCol - 1] = '-';
                    }
                }
            }
            if (presentsCount < 0)
            {
                Console.WriteLine($"Santa ran out of presents!");
            }

            PrintMatrix(matrix);

            foreach (char[] array in matrix)
            {
                foreach (char item in array)
                {
                    if (item == 'V')
                    {
                        kidsWithoutPresents++;
                    }
                }
            }

            if (kidsWithoutPresents == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsCounter} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {kidsWithoutPresents} nice kid/s.");
            }
        }

        private static void InitializeMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                if (!isFound)
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'V')
                        {
                            niceKidsCounter++;
                        }
                        if (input[col] == 'S')
                        {
                            positionRow = row;
                            positionCol = col;
                            //isFound = true;
                            //break;
                        }
                    }
                }
                matrix[row] = input;
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
