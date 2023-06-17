using System;
using System.Linq;

namespace _3._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];

            char[,] matrix = new char[matrixRows, matrixCols];

            FillMatrix(matrix);

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (matrix[row,col] == matrix[row,col+1] && matrix[row,col] == matrix[row+1,col] && matrix[row,col] == matrix[row+1,col+1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);


        }

        static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(char.Parse)
                         .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
