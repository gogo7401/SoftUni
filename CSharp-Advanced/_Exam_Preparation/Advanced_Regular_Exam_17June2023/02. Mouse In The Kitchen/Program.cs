namespace _02._Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixDimensions = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRow = matrixDimensions[0];
            int matrixColumn = matrixDimensions[1];

            char[,] cupboardArea = new char[matrixRow, matrixColumn];

            int beginRow = 0;
            int beginColumn = 0;
            int countCheese = 0;

            FillMatrix(cupboardArea, ref beginRow, ref beginColumn, ref countCheese);

            int currRow = beginRow;
            int currColumn = beginColumn;

            string input = Console.ReadLine();

            while (input != "danger")
            {
                cupboardArea[currRow, currColumn] = '*';

                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (!IsCellValid(currRow, currColumn, matrixRow, matrixColumn))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    cupboardArea[lastRow, lastColumn] = 'M';
                    PrintMatrix(cupboardArea);
                    return;
                }

                if (cupboardArea[currRow, currColumn] == 'C')
                {
                    cupboardArea[currRow, currColumn] = '*';
                    countCheese--;
                    if (countCheese == 0)
                    {
                        Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                        cupboardArea[currRow, currColumn] = 'M';
                        PrintMatrix(cupboardArea);
                        return;
                    }
                }

                if (cupboardArea[currRow, currColumn] == 'T')
                {
                    cupboardArea[currRow, currColumn] = 'M';
                    Console.WriteLine("Mouse is trapped!");
                    PrintMatrix(cupboardArea);
                    return;

                }

                if (cupboardArea[currRow, currColumn] == '@')
                {
                    currRow = lastRow;
                    currColumn = lastColumn;
                    cupboardArea[currRow, currColumn] = 'M';
                }

                input = Console.ReadLine();
            }

            cupboardArea[currRow, currColumn] = 'M';
            Console.WriteLine("Mouse will come back later!");
            PrintMatrix(cupboardArea);

        }

        static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn, ref int countCheese)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'M')
                    {
                        beginRow = row;
                        beginColumn = col;
                    }
                    if (input[col] == 'C')
                    {
                        countCheese++;
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