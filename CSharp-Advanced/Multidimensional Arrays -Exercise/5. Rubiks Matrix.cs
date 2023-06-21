/* възможно е в някои от тестовете да се подават много големи стойности за разбъркване,
 * например даден ред от 3 елемента да се разбърка 2000000000 пъти (1  left 2000000000).
 * Идеята е тези два милиарда да се редуцират до максимум бройката елементи на съответния ред в случая 3
 * 
 * Затова на редове 116, 134, 152 и 170 стъпките на завъртане се делят модулно (%) на броя на елементите в реда (за Up Down)  или колоната( за Left Right)
 * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _5._Rubiks_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int matrixRow = matrixSize[0];
            int matrixCol = matrixSize[1];

            int[,] shufflingMatrix = new int[matrixRow, matrixCol];

            FillRubiksMatrix(shufflingMatrix);

            //PrintMatrix(shufflingMatrix);

            int n = int.Parse(Console.ReadLine());

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            ShufflingCommand(n, shufflingMatrix, matrixRow, matrixCol);
            
            //PrintMatrix(shufflingMatrix);

            SwapMatrix(shufflingMatrix);

           // sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            
        }

        static void SwapMatrix(int[,] matrix)
        {
            int value = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == value)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        // Swap (0, 1) with (1, 0)
                        Boolean isFind = false;
                        int swapValue1 = matrix[row, col];
                        int swapValue2 = value;
                        for (int i = row; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                if (matrix[i,j] == value)
                                {
                                    swapValue2 = matrix[i,j];
                                    matrix[i,j] = swapValue1;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                                    isFind = true;
                                    break;
                                }
                            }
                            if (isFind)
                            {
                                break;
                            }
                        }
                        matrix[row, col] = swapValue2;
                    }
                    value++;
                }
            }
        }

        static void ShufflingCommand(int n, int[,] shufflingMatrix, int matrixRow, int matrixCol)
        {

            Queue<int> queue = new Queue<int>();
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int position = int.Parse(input[0]);
                string command = input[1];
                int steps = int.Parse(input[2]);

                //Queue<int> queue = new Queue<int>();

                switch (command.ToUpper())
                {
                    case "LEFT":
                        //queue.Clear();
                        for (int col = 0; col < matrixCol; col++)
                        {
                            queue.Enqueue(shufflingMatrix[position, col]);
                        }

                        for (int j = 0; j < steps % matrixCol; j++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }

                        for (int col = 0; col < matrixCol; col++)
                        {
                            shufflingMatrix[position, col] = queue.Dequeue();
                        }
                        break;

                    case "RIGHT":
                        //queue.Clear();
                        for (int col = matrixCol-1; col >= 0; col--)
                        {
                            queue.Enqueue(shufflingMatrix[position, col]);
                        }

                        for (int j = 0; j < steps % matrixCol; j++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }

                        for (int col = matrixCol - 1; col >= 0; col--)
                        {
                            shufflingMatrix[position, col] = queue.Dequeue();
                        }
                        break;

                    case "UP":
                        //queue.Clear();
                        for (int row = 0; row < matrixRow; row++)
                        {
                            queue.Enqueue(shufflingMatrix[row, position]);
                        }

                        for (int j = 0; j < steps % matrixRow; j++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }

                        for (int row = 0; row < matrixRow; row++)
                        {
                            shufflingMatrix[row, position] = queue.Dequeue();
                        }
                        break;

                    case "DOWN":
                        //queue.Clear();
                        for (int row = matrixRow - 1; row >= 0; row--)
                        {
                            queue.Enqueue(shufflingMatrix[row, position]);
                        }

                        for (int j = 0; j < steps % matrixRow; j++)
                        {
                            queue.Enqueue(queue.Dequeue());
                        }

                        for (int row = matrixRow - 1; row >= 0; row--)
                        {
                            shufflingMatrix[row, position] = queue.Dequeue();
                        }
                        break;
                }
            }
        }

        static void FillRubiksMatrix(int[,] matrix)
        {
            int value = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = value;
                    value++;
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
    }
}
