using System;
using System.Linq;

namespace _4._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];

            int[,] matrix = new int[matrixRows, matrixCols];

            FillMatrix(matrix);

            //PrintMatrix(matrix);

            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    // Calculates the sum of the elements of a 3x3 matrix
                    int sum = 0;
                    for (int i = row; i < row+3; i++)
                    {
                        for (int j = col; j < col+3; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = maxRow; i < maxRow+3; i++)
            {
                for (int j = maxCol; j < maxCol+3; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }


        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0} ", matrix[row, col]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
