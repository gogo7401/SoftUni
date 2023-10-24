using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        private static int beaverRow;
        private static int beaverCol;
        private static char[,] matrix;
        private static string lastDirection;

        private static List<char> branches = new List<char>();
        private static int totalBranches = 0;

        static void Main(string[] args)
        {


            int matrixDimensions = int.Parse(Console.ReadLine());

            matrix = new char[matrixDimensions, matrixDimensions];

            for (int row = 0; row < matrixDimensions; row++)
            {
                string[] inputq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrixDimensions; col++)
                {
                    matrix[row, col] = char.Parse(inputq[col]);
                }
            }

            //find Beaver's position
            for (int row = 0; row < matrixDimensions; row++)
            {
                for (int col = 0; col < matrixDimensions; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                        break;
                    }
                }
            }

            // count branches int the begin

            int currWoodBranchCount = 0;


            for (int row = 0; row < matrixDimensions; row++)
            {
                for (int col = 0; col < matrixDimensions; col++)
                {
                    if (char.IsLower(matrix[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }


            string direction = string.Empty;

            while ((direction = Console.ReadLine()) != "end")
            {
                lastDirection = direction;

                if (direction == "up")
                {
                    Move(-1, 0);
                }
                else if (direction == "down")
                {
                    Move(1, 0);
                }
                else if (direction == "right")
                {
                    Move(0, 1);
                }
                else if (direction == "left")
                {
                    Move(0, -1);
                }

                if (totalBranches == 0)
                {
                    break;
                }
                

            }

            if (totalBranches == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches} branches left.");
            }

            PrintMatrix(matrix);



        }

        private static void Move(int row, int col)
        {
            if (!IsInside(beaverRow + row, beaverCol + col))
            {
                if (branches.Any())
                {
                    branches.Remove(branches[branches.Count - 1]);
                }
                return;
            }
            matrix[beaverRow, beaverCol] = '-';
            beaverRow += row;
            beaverCol += col;

            if (char.IsLower(matrix[beaverRow, beaverCol]))
            {
                branches.Add(matrix[beaverRow, beaverCol]);
                matrix[beaverRow, beaverCol] = 'B';
                totalBranches--;
            }
            else if (matrix[beaverRow, beaverCol] == 'F')
            {
                matrix[beaverRow, beaverCol] = '-';

                if (lastDirection == "up")
                {
                    if (beaverRow == 0)
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "down")
                {
                    if (beaverRow == matrix.GetLength(0) - 1)
                    {
                        if (char.IsLower(matrix[0, beaverCol]))
                        {
                            branches.Add(matrix[0, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[matrix.GetLength(0) - 1, beaverCol]))
                        {
                            branches.Add(matrix[matrix.GetLength(0) - 1, beaverCol]);
                            totalBranches--;
                        }
                        beaverRow = matrix.GetLength(0) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "right")
                {
                    if (beaverCol == matrix.GetLength(1) - 1)
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
                else if (lastDirection == "left")
                {
                    if (beaverCol == 0)
                    {
                        if (char.IsLower(matrix[beaverRow, matrix.GetLength(1) - 1]))
                        {
                            branches.Add(matrix[beaverRow, matrix.GetLength(1) - 1]);
                            totalBranches--;
                        }
                        beaverCol = matrix.GetLength(1) - 1;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                    else
                    {
                        if (char.IsLower(matrix[beaverRow, 0]))
                        {
                            branches.Add(matrix[beaverRow, 0]);
                            totalBranches--;
                        }
                        beaverCol = 0;
                        matrix[beaverRow, beaverCol] = 'B';
                    }
                }
            }
            else
            {
                matrix[beaverRow, beaverCol] = 'B';
            }
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
                    Console.Write(string.Format("{0} ", matrixPrint[row, col]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
