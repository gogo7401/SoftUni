using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char [,] matrix = new char[matrixSize, matrixSize];

            ReadMatrixData(matrixSize, matrix);

            char searchedSymbol = char.Parse(Console.ReadLine());

            Boolean isFind = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == searchedSymbol)
                    {
                        isFind = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            if (!isFind)
            {
                Console.WriteLine($"{searchedSymbol} does not occur in the matrix");
            }

        }

        private static void ReadMatrixData(int matricRowsAndCols, char[,] matrix)
        {
            for (int row = 0; row < matricRowsAndCols; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < matricRowsAndCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
