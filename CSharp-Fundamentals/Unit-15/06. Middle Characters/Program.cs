using System;

namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMiddleCharacter(input);
        }

        private static void PrintMiddleCharacter(string input)
        {
            string result = "";
            int begin, end;
            if (input.Length % 2 == 0)
            {
                begin = (input.Length / 2) - 1;
                end = begin + 1;
            }
            else
            {
                begin = input.Length / 2;
                end = begin;
            }
            for (int i = begin; i <= end; i++)
            {
                result += input[i];
            }

            Console.WriteLine(result);
        }
    }
}
