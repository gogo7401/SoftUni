using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine()); 
            
            int[,] matrix = new int[matrixSize, matrixSize];

            ReadMatrixData(matrixSize, matrix);

            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);
        }

        private static void ReadMatrixData(int matricRowsAndCols, int[,] matrix)
        {
            for (int row = 0; row < matricRowsAndCols; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matricRowsAndCols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }
}
