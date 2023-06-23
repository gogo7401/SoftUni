namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // matrix NxN
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];

            // command - left, right, up, and down
            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Fill matrix
            int startPositionRow = 0;
            int startPositionCol = 0;
            int startCountOfCoals = 0;

            for (int row = 0; row < size; row++)
            {
                char[] characters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    if (characters[col] == 's')
                    {
                        startPositionRow = row;
                        startPositionCol = col;
                    }
                    if (characters[col] == 'c')
                    {
                        startCountOfCoals++;
                    }
                    field[row, col] = characters[col];
                }
            }

            // execute recieved command
            int recivedCoals = 0;
            int rowIndex = startPositionRow;
            int colIndex = startPositionCol;

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case "left":

                        if (colIndex - 1 >= 0)
                        {
                            colIndex--;
                            if (field[rowIndex, colIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                return;
                            }
                            else if (field[rowIndex, colIndex] == 'c')
                            {
                                recivedCoals++;
                                field[rowIndex, colIndex] = '*';
                                if (recivedCoals == startCountOfCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    return;
                                }
                            }

                        }

                        break;

                    case "right":

                        if (colIndex + 1 < size)
                        {
                            colIndex++;
                            if (field[rowIndex, colIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                return;
                            }
                            else if (field[rowIndex, colIndex] == 'c')
                            {
                                recivedCoals++;
                                field[rowIndex, colIndex] = '*';
                                if (recivedCoals == startCountOfCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    return;
                                }
                            }

                        }

                        break;

                    case "up":

                        if (rowIndex - 1 >= 0)
                        {
                            rowIndex--;
                            if (field[rowIndex, colIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                return;
                            }
                            else if (field[rowIndex, colIndex] == 'c')
                            {
                                recivedCoals++;
                                field[rowIndex, colIndex] = '*';
                                if (recivedCoals == startCountOfCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    return;
                                }
                            }

                        }

                        break;

                    case "down":

                        if (rowIndex + 1 < size)
                        {
                            rowIndex++;
                            if (field[rowIndex, colIndex] == 'e')
                            {
                                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                                return;
                            }
                            else if (field[rowIndex, colIndex] == 'c')
                            {
                                recivedCoals++;
                                field[rowIndex, colIndex] = '*';
                                if (recivedCoals == startCountOfCoals)
                                {
                                    Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                    return;
                                }
                            }

                        }

                        break;

                    default:
                        break;
                }
                
                if (i == command.Length - 1)
                {
                    Console.WriteLine($"{startCountOfCoals - recivedCoals} coals left. ({rowIndex}, {colIndex})");
                    return;
                }
            }



        }
    }
}