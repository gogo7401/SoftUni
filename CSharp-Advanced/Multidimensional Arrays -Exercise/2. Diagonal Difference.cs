using System;
using System.Linq;

namespace _2._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            FillMatrix(matrix);

            int sumLeft = 0;
            int sumRight = 0;
            int count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumLeft += matrix[row, col];
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == (matrix.GetLength(1) - 1 - row))
                    {
                        sumRight += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumLeft-sumRight));


        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row  = 0; row < matrix.GetLength(0); row++)
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
    }
}
