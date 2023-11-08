using System;
using System.Collections.Generic;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());

            char[,] field = new char[matrixDimensions, matrixDimensions];

            for (int row = 0; row < matrixDimensions; row++)
            {
                string inputq = Console.ReadLine();
                for (int col = 0; col < matrixDimensions; col++)
                {
                    field[row, col] = inputq[col];
                }
            }
            int beginRow = -1;
            int beginColumn = -1;    

            //find Mole's position
            for (int row = 0; row < matrixDimensions; row++)
            {
                for (int col = 0; col < matrixDimensions; col++)
                {
                    if (field[row, col] == 'M')
                    {
                        beginRow = row;
                        beginColumn = col;
                        break;
                    }
                }
            }

            int firstSpecialRow = -1;
            int firstSpecialColumn = -1;
            int secondSpecialRow = -1;
            int secondSpecialColumn = -1;

            //find speacial locations' positions
            for (int row = 0; row < matrixDimensions; row++)
            {
                for (int col = 0; col < matrixDimensions; col++)
                {
                    if (field[row, col] == 'S')
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

            int currRow = beginRow;
            int currColumn = beginColumn;

            int molePoints = 0;

            string input = Console.ReadLine();

            while (input != "End")
            {


                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (!IsCellValid(currRow, currColumn, matrixDimensions, matrixDimensions))
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    currRow = lastRow;
                    currColumn = lastColumn;
                    input = Console.ReadLine();

                    continue;
                }

                if (field[currRow, currColumn] == '-')
                {
                    field[lastRow, lastColumn] = '-';
                    field[currRow, currColumn] = 'M';
                    input = Console.ReadLine();
 
                    continue;
                }

                if (char.IsDigit(field[currRow, currColumn]))
                {
                    molePoints += Convert.ToInt32(new string(field[currRow, currColumn], 1));
                    field[lastRow, lastColumn] = '-';
                    field[currRow, currColumn] = 'M';
                    if (molePoints >= 25) { break; }
                    input = Console.ReadLine();

                    continue;
                }

                if (field[currRow, currColumn] == 'S')
                {

                    field[lastRow, lastColumn] = '-';;

                    if (firstSpecialRow == currRow && firstSpecialColumn == currColumn)
                    {
                        field[secondSpecialRow, secondSpecialColumn] = 'M';
                        field[firstSpecialRow, firstSpecialColumn] = '-';
                        currRow = secondSpecialRow;
                        currColumn = secondSpecialColumn;
                    }
                    else if (secondSpecialRow == currRow && secondSpecialColumn == currColumn)
                    {
                        field[secondSpecialRow, secondSpecialColumn] = '-';
                        field[firstSpecialRow, firstSpecialColumn] = 'M';
                        currRow = firstSpecialRow;
                        currColumn = firstSpecialColumn;
                    }
                    molePoints -= 3;
                    input = Console.ReadLine();

                    continue;
                }

            }

            if (molePoints >= 25) 
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {molePoints} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {molePoints} points.");
            }

            PrintMatrix(field);


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
