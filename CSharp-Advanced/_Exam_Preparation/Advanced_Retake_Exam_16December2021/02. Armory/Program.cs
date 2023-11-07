using System;

namespace _02._Armory
{
    public class Program
    {
        private static char[,] matrix;
        private static int officerRow;
        private static int officerCol;
        private static string lastDirection;
        private static int totalCoins;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            matrix = new char[size, size];

            totalCoins = 0;

            // fill matrix
            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            // find officer position
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                        break;
                    }
                }
            }

            // find mirror
            int firstSpecialRow = -1;
            int firstSpecialColumn = -1;
            int secondSpecialRow = -1;
            int secondSpecialColumn = -1;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        if (firstSpecialRow < 0 && firstSpecialColumn < 0)
                        {
                            firstSpecialRow = row;
                            firstSpecialColumn = col;
                        }
                        else
                        {
                            secondSpecialRow = row;
                            secondSpecialColumn = col;
                        }
                    }
                }
            }

            int currRow = officerRow;
            int currColumn = officerCol;


            string direction = Console.ReadLine();

            while (true)
            {
                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (direction == "up") ? currRow - 1 : (direction == "down") ? currRow + 1 : currRow;
                currColumn = (direction == "left") ? currColumn - 1 : (direction == "right") ? currColumn + 1 : currColumn;

                matrix[lastRow, lastColumn] = '-';

                if (!IsInside(currRow, currColumn))
                {
                    Console.WriteLine("I do not need more swords!");
                    Console.WriteLine($"The king paid {totalCoins} gold coins.");
                    //matrix[lastRow, lastColumn] = 'A';
                    PrintMatrix(matrix);
                    return;
                }

                if (char.IsDigit(matrix[currRow, currColumn]))
                {
                    totalCoins += int.Parse(matrix[currRow, currColumn].ToString());
                    matrix[currRow, currColumn] = 'A';
                }

                else if (matrix[currRow, currColumn] == 'M')
                {
                    matrix[currRow, currColumn] = '-';
                    if (currRow == firstSpecialRow && currColumn == firstSpecialColumn)
                    {
                        matrix[secondSpecialRow, secondSpecialColumn] = 'A';
                        currRow = secondSpecialRow;
                        currColumn = secondSpecialColumn;
                        
                    }
                    else
                    {
                        matrix[firstSpecialRow, firstSpecialColumn] = 'A';
                        currRow = firstSpecialRow;
                        currColumn = firstSpecialColumn;
                    }
                }


                if (totalCoins >=65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    Console.WriteLine($"The king paid {totalCoins} gold coins.");
                    PrintMatrix(matrix);
                    return;
                }

                direction = Console.ReadLine();

            }

            Console.WriteLine("I do not need more swords!");
            Console.WriteLine($"The king paid {totalCoins} gold coins.");
            PrintMatrix(matrix);

        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void PrintMatrix(char[,] matrixPrint)
        {
            for (int row = 0; row < matrixPrint.GetLength(0); row++)
            {
                for (int col = 0; col < matrixPrint.GetLength(1); col++)
                {
                    Console.Write(string.Format("{0}", matrixPrint[row, col]));
                }
                Console.Write(Environment.NewLine);
            }
        }

    }
}
