namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());

            char[,] battlefield = new char[matrixDimensions, matrixDimensions];

            int beginRow = 0;
            int beginColumn = 0;

            FillMatrix(battlefield, ref beginRow, ref beginColumn);

            int currRow = beginRow;
            int currColumn = beginColumn;
            battlefield[currRow, currColumn] = '-';
            int mineIsBlown = 0;
            int destroyedCruiser = 0;

            while (true)
            {
                string input = Console.ReadLine();

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (battlefield[currRow, currColumn] == '-')
                {
                    continue;
                }

                if (battlefield[currRow, currColumn] == '*')
                {
                    mineIsBlown++;
                    battlefield[currRow, currColumn] = '-';
                    if (mineIsBlown == 3)
                    {
                        Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{currRow}, {currColumn}]!");
                        battlefield[currRow, currColumn] = 'S';
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (battlefield[currRow, currColumn] == 'C')
                {
                    destroyedCruiser++;
                    battlefield[currRow, currColumn] = '-';
                    if (destroyedCruiser == 3)
                    {
                        Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                        battlefield[currRow, currColumn] = 'S';
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }





            }

                PrintMatrix(battlefield);
        }

        static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
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

    }
}