namespace _8._Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            FillMatrix(matrix);

            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] target = coordinates[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int targetRow = target[0];
                int targetCol = target[1];

                int valueBomb = matrix[targetRow, targetCol];
                                
                if (valueBomb > 0)  // Една бомба не може да експлодира повече от веднъж и след като това стане, нейната стойност става 0
                {                   // Има тест Test #5 (Incorrect answer), защото ми подават два пъти една и съща бомба примерно 1,2 и след няколко бомби пак 1,2
                                    // но тази бомба вече е гръмнала и има стойност 0, затова не може пак да гърми и следва да се пропусне    
                    matrix[targetRow, targetCol] = 0;

                    BombExplosion(matrix, targetRow, targetCol, valueBomb);
                }
            }

            int aliveCells = 0;
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }

            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");


            PrintMatrix(matrix);

        }

        static void FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .Select(int.Parse)
                         .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
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

        static void BombExplosion(int[,] matrix, int targetRow, int targetCol, int valueBomb)
        {
            int startRow = targetRow - 1;
            int endRow = targetRow + 1;
            int startCol = targetCol - 1;
            int endCol = targetCol + 1;

            if (startRow < 0)
            {
                startRow = 0;
            }
            if (endRow >= matrix.GetLength(0))
            {
                endRow = matrix.GetLength(0) - 1;
            }
            if (startCol < 0)
            {
                startCol = 0;
            }
            if (endCol >= matrix.GetLength(1))
            {
                endCol = matrix.GetLength(1) - 1;
            }

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        matrix[row, col] -= valueBomb;
                    }
                }
            }


        }

    }
}