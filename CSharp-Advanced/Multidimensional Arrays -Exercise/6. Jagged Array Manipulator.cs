namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                int[] inputRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jagged[row] = inputRow;
            }

            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] *= 2;
                        jagged[row + 1][i] *= 2;
                    }
                }
                else
                {
                    for (int i = 0; i < jagged[row].Length; i++)
                    {
                        jagged[row][i] /= 2;
                    }
                    for (int i = 0; i < jagged[row + 1].Length; i++)
                    {
                        jagged[row + 1][i] /= 2;
                    }
                }
            }

            string input = Console.ReadLine();

            while (input.ToUpper() != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                int targetRow = int.Parse(tokens[1]);
                int targetCol = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (targetRow >= 0 && targetRow < jagged.GetLength(0) &&
                    targetCol >= 0 && targetCol < jagged[targetRow].Length)
                {
                    if (command == "Add")
                    {
                        jagged[targetRow][targetCol] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jagged[targetRow][targetCol] -= value;
                    }
                }



                input = Console.ReadLine();
            }



            PrintJagged(jagged);

        }

        static void PrintJagged(int[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));

            }
        }


    }
}