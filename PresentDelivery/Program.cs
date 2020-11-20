using System;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPresents = int.Parse(Console.ReadLine());

            int neighborhoodSize = int.Parse(Console.ReadLine());

            char[][] matrix = new char[neighborhoodSize][];

            bool santasPositionFound = false;
            int positionRow = -1;
            int positionCol = -1;

            for (int row = 0; row < neighborhoodSize; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();
                if (!santasPositionFound)
                {
                    for (int col = 0; col < input.Length; col++)
                    {
                        if (input[col] == 'S')
                        {
                            positionRow = row;
                            positionCol = col;
                            santasPositionFound = true;
                            break;
                        }
                    }
                }

                matrix[row] = input;
            }

            string command;

            while ((command = Console.ReadLine()) != "Christmas morning"
                && countOfPresents  > 0)
            {
                if (command == "up")
                {
                    if (positionRow - 1 >= 0)
                    {
                        positionRow--;

                        char symbol = matrix[positionRow][positionCol];

                        if (symbol == 'V')
                        {
                            countOfPresents--;

                        }
                        else if (symbol == 'C')
                        {
                            if (matrix[positionRow+1][positionCol] == 'X' ||
                                matrix[positionRow-1][positionCol] == 'X' ||
                                matrix[positionRow][positionCol+1] == 'X' ||
                                matrix[positionRow][positionCol-1] == 'X')
                            {
                                countOfPresents--;
                            }
                            if (matrix[positionRow + 1][positionCol] == 'V' ||
                                matrix[positionRow - 1][positionCol] == 'V' ||
                                matrix[positionRow][positionCol + 1] == 'V' ||
                                matrix[positionRow][positionCol - 1] == 'V')
                            {
                                countOfPresents--;
                            }

                        }
                        matrix[positionRow][positionCol] = 'S';
                        matrix[positionRow + 1][positionCol] = '-';
                    }
                }
                else if (command == "down")
                {

                }
                else if (command == "left")
                {

                }
                else if (command == "right")
                {

                }
            }
        }
    }
}
