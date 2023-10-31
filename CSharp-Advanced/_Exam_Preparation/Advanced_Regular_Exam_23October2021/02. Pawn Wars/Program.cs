using System;
using System.ComponentModel;

namespace _02._Pawn_Wars
{
    internal class Program
    {
        private static char[,] matrix;
        private static int whiteRow;
        private static int whiteCol;
        private static int blackRow;
        private static int blackCol;


        static void Main(string[] args)
        {
            int size = 8;

            matrix = new char[size, size];

            // fill matrix
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            // find black and white pawn position
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            while (true)
            {
                // Move white pawn
                matrix[whiteRow, whiteCol] = '-';

                if (IsInside(whiteRow - 1, whiteCol - 1) && matrix[whiteRow-1, whiteCol-1] == 'b')
                {
                    whiteRow--;
                    whiteCol--;
                    matrix[whiteRow, whiteCol] = 'w';
                    Console.WriteLine($"Game over! White capture on {(char)(whiteCol+97)}{8-whiteRow}.");
                    return;
                }

                if (IsInside(whiteRow - 1, whiteCol + 1) && matrix[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    whiteRow--;
                    whiteCol++;
                    matrix[whiteRow, whiteCol] = 'w';
                    Console.WriteLine($"Game over! White capture on {(char)(whiteCol + 97)}{8 - whiteRow}.");
                    return;
                }

                whiteRow--;
                matrix[whiteRow, whiteCol] = 'w';

                if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteCol+97)}{8-whiteRow}.");
                    return;
                }

                // Move black pawn
                matrix[blackRow, blackCol] = '-';

                if (IsInside(blackRow + 1, blackCol - 1) && matrix[blackRow + 1, blackCol - 1] == 'w')
                {
                    blackRow++;
                    blackCol--;
                    matrix[blackRow, blackCol] = 'b';
                    Console.WriteLine($"Game over! Black capture on {(char)(blackCol + 97)}{8-blackRow}.");
                    return;
                }

                if (IsInside(blackRow + 1, blackCol + 1) && matrix[blackRow + 1, blackCol + 1] == 'w')
                {
                    blackRow++;
                    blackCol++;
                    matrix[blackRow, blackCol] = 'b';
                    Console.WriteLine($"Game over! Black capture on {(char)(blackCol + 97)}{8-blackRow}.");
                    return;
                }

                blackRow++;
                matrix[blackRow, blackCol] = 'b';

                if (blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackCol + 97)}{8-blackRow}.");
                    return;
                }


            }



        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }



    }

    

}
