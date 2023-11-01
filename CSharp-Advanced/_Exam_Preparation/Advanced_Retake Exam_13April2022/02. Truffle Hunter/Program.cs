using System;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());

            char[,] forest = new char[matrixDimensions, matrixDimensions];

            for (int row = 0; row < matrixDimensions; row++)
            {
                string[] inputq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrixDimensions; col++)
                {
                    forest[row, col] = char.Parse(inputq[col]);
                }
            }

            //PrintMatrix(forest);



            string input = string.Empty;
            
            int truffleBlack = 0;
            int truffleWhite = 0;
            int truffleSummer = 0;

            int truffleWild_Boar = 0;

            int end = 0;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                // Collect {row} {col}

                string[] action = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = action[0];
                int row = int.Parse(action[1]);
                int col = int.Parse(action[2]);

                if (command == "Collect")
                {
                    if (IsCellValid(row, col, matrixDimensions, matrixDimensions))
                    {
                        if (forest[row,col] == 'B')
                        {
                            truffleBlack++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'S')
                        {
                            truffleSummer++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'W')
                        {
                            truffleWhite++;
                            forest[row, col] = '-';
                        }
                    }
                    //PrintMatrix(forest);

                }
                // Wild_Boar {row} {col} {direction}
                else if (command == "Wild_Boar")
                {
                    string direction = action[3];

                    if (direction == "up")
                    {
                        for (int i = row; i >= 0; i-=2)
                        {
                            if (forest[i,col] == 'B' || forest[i, col] == 'S' || forest[i, col] == 'W')
                            {
                                forest[i, col] = '-';
                                truffleWild_Boar++;
                            }
                        }
                        
                    }
                    else if (direction == "down")
                    {
                        for (int i = row; i < forest.GetLength(0); i += 2)
                        {
                            if (forest[i, col] == 'B' || forest[i, col] == 'S' || forest[i, col] == 'W')
                            {
                                forest[i, col] = '-';
                                truffleWild_Boar++;
                            }
                        }
                    }
                    else if (direction == "left")
                    {
                        for (int i = col; i >= 0; i -= 2)
                        {
                            if (forest[row, i] == 'B' || forest[row, i] == 'S' || forest[row, i] == 'W')
                            {
                                forest[row, i] = '-';
                                truffleWild_Boar++;
                            }
                            
                        }
                    }
                    else if (direction == "right")
                    {
                        for (int i = col; i < forest.GetLength(1); i += 2)
                        {
                            if (forest[row, i] == 'B' || forest[row, i] == 'S' || forest[row, i] == 'W')
                            {
                                forest[row, i] = '-';
                                truffleWild_Boar++;
                            }
                        }
                    }
                    


                }

            }

            Console.WriteLine($"Peter manages to harvest {truffleBlack} black, {truffleSummer} summer, and {truffleWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {truffleWild_Boar} truffles.");

            PrintMatrix(forest);


        }

        static bool IsCellValid(int row, int col, int n, int m)
        {
            return row >= 0
                && row < n
                && col >= 0
                && col < m;
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
