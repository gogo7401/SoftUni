namespace _02._The_Squirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixDimensions = int.Parse(Console.ReadLine());

            char[,] field = new char[matrixDimensions, matrixDimensions];

            List<string> command = new List<string>(Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries));

            int beginRow = 0;
            int beginColumn = 0;
            int countHazelnuts = 0;

            FillMatrix(field, ref beginRow, ref beginColumn);

            int currRow = beginRow;
            int currColumn = beginColumn;

            for (int i = 0; i < command.Count; i++)
            {
                int lastRow = currRow;
                int lastColumn = currColumn;

                currRow = (command[i] == "up") ? currRow - 1 : (command[i] == "down") ? currRow + 1 : currRow;
                currColumn = (command[i] == "left") ? currColumn - 1 : (command[i] == "right") ? currColumn + 1 : currColumn;

                if (!IsCellValid(currRow, currColumn, matrixDimensions, matrixDimensions))
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");
                    return;
                }

                if (field[currRow, currColumn] == 't')
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");
                    return;
                }

                if (field[currRow, currColumn] == 'h')
                {
                    field[currRow, currColumn] = '*';
                    countHazelnuts++;
                    if (countHazelnuts == 3)
                    {
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");
                        return;
                    }
                }
            }

            Console.WriteLine("There are more hazelnuts to collect.");
            Console.WriteLine($"Hazelnuts collected: {countHazelnuts}");

        }


        static void FillMatrix(char[,] matrix, ref int beginRow, ref int beginColumn)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 's')
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