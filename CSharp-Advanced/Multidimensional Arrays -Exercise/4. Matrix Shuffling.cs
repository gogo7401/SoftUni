namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRows = dimensions[0];
            int matrixColumns = dimensions[1];

            string[,] stringMatrix = new string[matrixRows, matrixColumns];
            FillMatrix(stringMatrix);

            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row1 = 0;
                int row2 = 0;
                int col1 = 0;
                int col2 = 0;
                if (tokens.Length == 5 && tokens[0] == "swap" && int.TryParse(tokens[1], out row1) && int.TryParse(tokens[2], out col1) &&
                    int.TryParse(tokens[3], out row2) && int.TryParse(tokens[4], out col2) )
                {
                    if (row1 >= 0 && row1 < matrixRows && row2 >= 0 && row2 < matrixRows &&
                        col1 >= 0 && col1 < matrixColumns && col2 >= 0 && col2 < matrixColumns)
                    {
                        string temp = stringMatrix[row1, col1];
                        stringMatrix[row1, col1] = stringMatrix[row2, col2];
                        stringMatrix[row2, col2] = temp;
                        PrintMatrix(stringMatrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }


                input = Console.ReadLine();
            }


        }

        static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void PrintMatrix(string[,] matrix)
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