using System;
using System.Linq;

namespace _02._Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());

            char[,] wall = new char[dimension, dimension];

            int beginRow = 0;
            int beginColumn = 0;
            int countHoles = 1;
            int countOfRods = 0;

            FillMatrix(wall, ref beginRow, ref beginColumn);

            int currRow = beginRow;
            int currColumn = beginColumn;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                //PrintMatrix(wall);  
                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (IsCellValid(currRow, currColumn, dimension, dimension))
                {
                    if (wall[currRow, currColumn] == 'C')
                    {
                        wall[lastRow, lastColumn] = '*';
                        wall[currRow, currColumn] = 'E';
                        countHoles++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                        break;
                    }
                    else if (wall[currRow, currColumn] == 'R')
                    {
                        currRow = lastRow;
                        currColumn = lastColumn;
                        Console.WriteLine("Vanko hit a rod!");
                        countOfRods++;
                    }
                    else if (wall[currRow, currColumn] == '-')
                    {
                        wall[currRow, currColumn] = 'V';
                        wall[lastRow, lastColumn] = '*';
                        countHoles++;
                    }
                    else if (wall[currRow, currColumn] == '*')
                    {
                        wall[lastRow, lastColumn] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{currRow}, {currColumn}]!");
                        wall[currRow, currColumn] = 'V';

                    }

                }
                else
                {
                    currRow = lastRow;
                    currColumn = lastColumn;
                }             
            }

            if (input == "End")
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }

            PrintMatrix(wall);
        }

            static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    string input = Console.ReadLine();

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[col];
                        if (input[col] == 'V')
                        {
                            beginRow = row;
                            beginColumn = col;
                        }
                    }
                }
            }

            static void PrintMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(string.Format("{0}", matrix[row, col]));
                    }
                    Console.Write(Environment.NewLine);
                }
            }

            static bool IsCellValid(int row, int col, int n, int m)
            {
                return row >= 0
                    && row < n
                    && col >= 0
                    && col < m;
            }
     
    }
}
