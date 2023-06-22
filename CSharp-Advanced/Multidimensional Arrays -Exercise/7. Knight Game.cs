namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = input[col];
                }
            }
            //PrintMatrix(board);

            int countOfColosion = 0;
            int maxRow = 0;
            int maxCol = 0;
            int maxColision = 0;
            int removeKnight = 0;

            while (true)
            {
                countOfColosion = 0;


                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        // if value on current cell == 'K'
                        if (board[row, col] == 'K')
                        {

                            // row - 2
                            if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2, col - 1] == 'K')
                            {
                                countOfColosion++;
                            }
                            if (row - 2 >= 0 && col + 1 < size && board[row - 2, col + 1] == 'K')
                            {
                                countOfColosion++;
                            }
                            // row - 1
                            if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1, col - 2] == 'K')
                            {
                                countOfColosion++;
                            }
                            if (row - 1 >= 0 && col + 2 < size && board[row - 1, col + 2] == 'K')
                            {
                                countOfColosion++;
                             }
                            // row + 1
                            if (row + 1 < size && col - 2 >= 0 && board[row + 1, col - 2] == 'K')
                            {
                                countOfColosion++;
                            }
                            if (row + 1 < size && col + 2 < size && board[row + 1, col + 2] == 'K')
                            {
                                countOfColosion++;
                            }
                            // row + 2
                            if (row + 2 < size && col - 1 >= 0 && board[row + 2, col - 1] == 'K')
                            {
                                countOfColosion++;
                            }
                            if (row + 2 < size && col + 1 < size && board[row + 2, col + 1] == 'K')
                            {
                                countOfColosion++;
                            }

                            if (countOfColosion > maxColision)
                            {
                                maxColision = countOfColosion;
                                maxRow = row;
                                maxCol = col;

                            }
                            countOfColosion = 0;

                        }
                    }
                }

                if (maxColision > 0)
                {
                    board[maxRow, maxCol] = '0';
                    maxRow = 0;
                    maxCol = 0;
                    maxColision = 0;
                    removeKnight++;
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine(removeKnight);

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
    }
}
