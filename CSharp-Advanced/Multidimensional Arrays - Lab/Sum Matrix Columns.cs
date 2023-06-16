using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixInfo = ReadMatrixfromConsole();
            int[,] matrix = new int[matrixInfo[0], matrixInfo[1]];
            ReadMatrixData(matrixInfo, matrix);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }

        }

        private static int[] ReadMatrixfromConsole()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }

        private static void ReadMatrixData(int[] matricRowsAndCols, int[,] matrix)
        {
            for (int row = 0; row < matricRowsAndCols[0]; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matricRowsAndCols[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

    }
}
