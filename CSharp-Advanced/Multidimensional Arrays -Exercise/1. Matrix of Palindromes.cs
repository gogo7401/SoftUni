using System;
using System.Linq;
using System.Text;

namespace _1._Matrix_of_Palindromes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];

            string[,] palindrom = new string[matrixRows, matrixCols];

            char[] symbols = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0;  row < matrixRows; row++)
            {
                StringBuilder cell = new StringBuilder();

                for (int i = 0; i < matrixCols; i++)
                {
                    cell.Append(symbols[row]);
                    cell.Append(symbols[i+row]);
                    cell.Append(symbols[row]);
                    palindrom[row, i] = cell.ToString();
                    cell.Clear();   
                }


            }

            for (int row = 0; row < matrixRows; row++)
            {
                for (int col = 0; col < matrixCols; col++)
                {
                    Console.Write(palindrom[row, col] + " ");
                }
                Console.WriteLine(string.Empty);
            }

        }
    }
}
