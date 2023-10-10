namespace _02._Blind_Man_s_Buff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRow = matrixDimensions[0];
            int matrixColumn = matrixDimensions[1];

            char[,] gameField = new char[matrixRow, matrixColumn];

            int beginRow = 0;
            int beginColumn = 0;
            int countCheese = 0;
            int countMoves = 0;
            int countTouched = 0;

            FillMatrix(gameField, ref beginRow, ref beginColumn);

            int currRow = beginRow;
            int currColumn = beginColumn;

            string input = Console.ReadLine();

            while (input != "Finish")
            {

                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (!IsCellValid(currRow, currColumn, matrixRow, matrixColumn))
                {
                    currRow = lastRow;
                    currColumn = lastColumn;
                    input = Console.ReadLine();
                    continue;
                }

                if (gameField[currRow, currColumn] == 'O')
                {
                    currRow = lastRow;
                    currColumn = lastColumn;
                    input = Console.ReadLine();
                    continue;
                }

                if (gameField[currRow, currColumn] == '-')
                {
                    gameField[currRow, currColumn] = 'B';
                    gameField[lastRow, lastColumn] = '-';
                    countMoves++;
                        
                }

                if (gameField[currRow, currColumn] == 'P')
                {
                    gameField[currRow, currColumn] = 'B';
                    gameField[lastRow, lastColumn] = '-';
                    countMoves++;
                    countTouched++;
                    if (countTouched == 3)
                    {
                        break;
                    }
                }

                input = Console.ReadLine();

            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {countTouched} Moves made: {countMoves}");

        }

        static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = string.Concat(Console.ReadLine().Split(' ')).ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'B')
                    {
                        beginRow = row;
                        beginColumn = col;
                    }

                }
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