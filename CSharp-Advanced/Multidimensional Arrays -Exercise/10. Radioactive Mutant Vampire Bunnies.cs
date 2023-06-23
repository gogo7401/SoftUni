using System.Drawing;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRow = dimensions[0];
            int matrixColumn = dimensions[1];

            char[,] lair = new char[matrixRow, matrixColumn];

            int startPositionRow = 0;
            int startPositionCol = 0;

            for (int row = 0; row < lair.GetLength(0); row++)
            {
                string characters = Console.ReadLine();
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (characters[col] == 'P')
                    {
                        startPositionRow = row;
                        startPositionCol = col;
                    }
                    lair[row, col] = characters[col];
                }
            }

            string moves = Console.ReadLine();
            int indexRow = startPositionRow;
            int indexCol = startPositionCol;

            for (int i = 0; i < moves.Length; i++)
            {
                bool isReaches = false;
                switch (moves[i])
                {
                    case 'L':

                        if (indexCol - 1 < 0)
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            
                            PrintMatrix(lair);
                            Console.WriteLine($"won: {indexRow} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow, indexCol -1] == 'B')
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            PrintMatrix(lair);
                            Console.WriteLine($"dead: {indexRow} {indexCol-1}");
                            return;
                        }
                        else if (lair[indexRow, indexCol - 1] == '.')
                        {
                            lair[indexRow, indexCol] = '.';
                            indexCol--;
                            lair[indexRow, indexCol] = 'P';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            if (isReaches)
                            {
                                PrintMatrix(lair);
                                Console.WriteLine($"dead: {indexRow} {indexCol}");
                                return;
                            }

                        }


                        break;

                    case 'R':

                        if (indexCol + 1 > lair.GetLength(1)-1)
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                          
                            PrintMatrix(lair);
                            Console.WriteLine($"won: {indexRow} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow, indexCol +1] == 'B')
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            PrintMatrix(lair);
                            Console.WriteLine($"dead: {indexRow} {indexCol + 1}");
                            return;
                        }
                        else if (lair[indexRow, indexCol + 1] == '.')
                        {
                            lair[indexRow, indexCol] = '.';
                            indexCol++;
                            lair[indexRow, indexCol] = 'P';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            if (isReaches)
                            {
                                PrintMatrix(lair);
                                Console.WriteLine($"dead: {indexRow} {indexCol}");
                                return;
                            }

                        }

                        break;

                    case 'U':

                        if (indexRow - 1 < 0)
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                      
                            PrintMatrix(lair);
                            Console.WriteLine($"won: {indexRow} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow - 1, indexCol] == 'B')
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            PrintMatrix(lair);
                            Console.WriteLine($"dead: {indexRow - 1} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow - 1, indexCol] == '.')
                        {
                            lair[indexRow, indexCol] = '.';
                            indexRow--;
                            lair[indexRow, indexCol] = 'P';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            if (isReaches)
                            {
                                PrintMatrix(lair);
                                Console.WriteLine($"dead: {indexRow} {indexCol}");
                                return;
                            }

                        }

                        break;

                    case 'D':

                        if (indexRow + 1 > lair.GetLength(0) - 1)
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                           
                            PrintMatrix(lair);
                            Console.WriteLine($"won: {indexRow} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow + 1, indexCol] == 'B')
                        {
                            lair[indexRow, indexCol] = '.';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            PrintMatrix(lair);
                            Console.WriteLine($"dead: {indexRow + 1} {indexCol}");
                            return;
                        }
                        else if (lair[indexRow + 1, indexCol] == '.')
                        {
                            lair[indexRow, indexCol] = '.';
                            indexRow++;
                            lair[indexRow, indexCol] = 'P';
                            // зайците се размножават
                            isReaches = SpreadBunnies(lair);
                            if (isReaches)
                            {
                                PrintMatrix(lair);
                                Console.WriteLine($"dead: {indexRow} {indexCol}");
                                return;
                            }

                        }

                        break;

                    default:
                        break;
                }



            }

            PrintMatrix(lair);  

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

        static bool SpreadBunnies(char[,] lair)
        {
            bool isReaches = false;
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'B')
                    {
                        int leftCol = (col - 1 < 0) ? col : col - 1;
                        int rightCol = (col + 1 < lair.GetLength(1)) ? col + 1 : col;
                        int upRow = (row - 1 < 0) ? row : row - 1;
                        int downRow = (row + 1 < lair.GetLength(0)) ? row + 1 : row;
                        
                        // leftCol
                        if (lair[row, leftCol] == '.')
                        {
                            lair[row, leftCol] = 'N';
                        } 
                        else if (lair[row, leftCol] == 'P')
                        {
                            lair[row, leftCol] = 'N';
                            isReaches = true;
                        }

                        // rightCol
                        if (lair[row, rightCol] == '.')
                        {
                            lair[row, rightCol] = 'N';
                        }
                        else if (lair[row, rightCol] == 'P')
                        {
                            lair[row, rightCol] = 'N';
                            isReaches = true;
                        }

                        // upRow
                        if (lair[upRow, col] == '.')
                        {
                            lair[upRow, col] = 'N';
                        }
                        else if (lair[upRow, col] == 'P')
                        {
                            lair[upRow, col] = 'N';
                            isReaches = true;
                        }
                        // downRow
                        if (lair[downRow, col] == '.')
                        {
                            lair[downRow, col] = 'N';
                        }
                        else if (lair[downRow, col] == 'P')
                        {
                            lair[downRow, col] = 'N';
                            isReaches = true;
                        }
                    }
                }
            }

            // N -> B
            for (int row = 0; row < lair.GetLength(0); row++)
            {
                for (int col = 0; col < lair.GetLength(1); col++)
                {
                    if (lair[row, col] == 'N')
                    {
                        lair[row, col] = 'B';
                    }
                }
            }



            return isReaches;
        }
    }
}