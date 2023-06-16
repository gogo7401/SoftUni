namespace _1._Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matricRowsAndCols = ReadMatrixfromConsole();
            int[,] matrix = new int[matricRowsAndCols[0], matricRowsAndCols[1]];
            ReadMatrixData(matricRowsAndCols, matrix);

            int sum = 0;
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            foreach (int item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(sum);

        }

        private static void ReadMatrixData(int[] matricRowsAndCols, int[,] matrix)
        {
            for (int row = 0; row < matricRowsAndCols[0]; row++)
            {
                int[] currentRow = ReadMatrixfromConsole();

                for (int col = 0; col < matricRowsAndCols[1]; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }

        private static int[] ReadMatrixfromConsole()
        {
            return Console.ReadLine()
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
        }
    }
}
