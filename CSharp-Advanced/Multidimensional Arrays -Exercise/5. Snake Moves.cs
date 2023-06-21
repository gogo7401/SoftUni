namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] snake = Console.ReadLine().ToCharArray();

            int matrixRows = matrixSize[0];
            int matrixCols = matrixSize[1];

            char[,] matrix = new char[matrixRows, matrixCols];

            int step = 1;
            int col = 0;
            int idxSnake = 0;

            for (int row = 0; row < matrixRows; row++)
            {
                for (int i = 0; i < matrixCols; i++)
                {
                    if (col == 0)
                    {
                        step = 1;
                    }
                    if (col == matrixCols - 1)
                    {
                        step = -1;
                    }
                    matrix[row,col] = snake[idxSnake];
                    idxSnake++;
                    if (idxSnake > snake.Length-1)
                    {
                        idxSnake = 0;
                    }
                    col += step;
                }
                col -= step;

            }

            PrintMatrix(matrix);


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