using System;
using System.Linq;

namespace _6._Target_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input data            
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRows = dimensions[0];
            int matrixColumns = dimensions[1];
            char[,] matrix = new char[matrixRows, matrixColumns];

            char[] snake = Console.ReadLine().ToCharArray();
            
            int[] shot = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int impactRow = shot[0];
            int impactColumn = shot[1];
            int impactRadius = shot[2];


            // fill matrix with snake
            int step = -1;
            int col = matrixColumns-1;
            int idx = 0;

            for (int row = matrixRows -1; row >= 0; row--)
            {
                for (int i = 0; i < matrixColumns; i++)
                {
                    if (col == 0)
                    {
                        step = 1;
                    }

                    if (col == matrixColumns - 1)
                    {
                        step = -1;
                    }

                    
                    if (idx > snake.Length - 1)
                    {
                        idx = 0;
                    }
                    matrix[row, col] = snake[idx];
                    col += step;
                    idx++;
                }
                col -= step;
            }
            PrintMatrix(matrix);

            // destroys all symbols in the given radius
            // down
            matrix[impactRow, impactColumn] = ' ';
            int endRow = impactRow + impactRadius;
            if (impactRow + impactRadius > matrixRows -1)
            {
                endRow = matrixRows - 1;
            }
            int count = 0;
            for (int row = impactRow; row <= endRow; row++)
            {
                int beginColumn = impactColumn - impactRadius + count;
                int endColumn = impactColumn + impactRadius - count;
                if (beginColumn < 0)
                {
                    beginColumn = 0;    
                }
                if (endColumn > matrixColumns - 1)
                {
                    endColumn = matrixColumns - 1;
                }
                for (int i = beginColumn; i <= endColumn; i++)
                {
                    matrix[row,i] = ' ';
                }
                count++;
            }
            PrintMatrix(matrix);
            // up

        }

        static void PrintMatrix(char[,] matrix)
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
