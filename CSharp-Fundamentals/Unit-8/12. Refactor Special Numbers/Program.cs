using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            int sum = 0;
            int currentDigit = 0;
            bool isSpecialNimber = false;
            for (int ch = 1; ch <= inputCount; ch++)
            {
                currentDigit = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                isSpecialNimber = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currentDigit, isSpecialNimber);
                sum = 0;
                ch = currentDigit;
            }

        }
    }
}
