namespace _02._Delivery_Boy
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

            char[,] neighborhoodMatrix = new char[matrixRow, matrixColumn];

            int beginRow = 0;
            int beginColumn = 0;

            FillMatrix(neighborhoodMatrix, ref beginRow, ref beginColumn);

            int currRow = beginRow;
            int currColumn = beginColumn;

            //bool end = false;

            while (true)
            {
                string input = Console.ReadLine();

                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (input == "up") ? currRow - 1 : (input == "down") ? currRow + 1 : currRow;
                currColumn = (input == "left") ? currColumn - 1 : (input == "right") ? currColumn + 1 : currColumn;

                if (!IsCellValid(currRow, currColumn, matrixRow, matrixColumn))
                {
                    Console.WriteLine("The delivery is late. Order is canceled.");
                    neighborhoodMatrix[beginRow, beginColumn] = ' ';
                    PrintMatrix(neighborhoodMatrix);
                    return;
                }

                if (neighborhoodMatrix[currRow, currColumn] == 'A')
                {
                    neighborhoodMatrix[currRow, currColumn] = 'P';
                    Console.WriteLine("Pizza is delivered on time! Next order...");
                    PrintMatrix(neighborhoodMatrix);
                    return;
                }

                if (neighborhoodMatrix[currRow, currColumn] == '-')
                {
                    neighborhoodMatrix[currRow, currColumn] = '.';
                    continue;
                }

                if (neighborhoodMatrix[currRow, currColumn] == 'P')
                {
                    neighborhoodMatrix[currRow, currColumn] = 'R';
                    Console.WriteLine("Pizza is collected. 10 minutes for delivery.");
                    continue;
                }

                if (neighborhoodMatrix[currRow, currColumn] == '*')
                {
                    currRow = lastRow;
                    currColumn = lastColumn;
                }
            }


            //PrintMatrix(neighborhoodMatrix);

        }

        static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

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