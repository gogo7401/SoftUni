using System;

namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int smallestNumber = GetMinNumber(firstNumber, secondNumber, thirdNumber);
            Console.WriteLine(smallestNumber);
            
        }

        private static int GetMinNumber(int firstNumber, int secondNumber, int thirdNumber)
        {
            int minNumber = int.MaxValue;
            if (firstNumber <= secondNumber && firstNumber <= thirdNumber)
            {
                minNumber = firstNumber;
            }
            else if (secondNumber <= firstNumber && secondNumber <= thirdNumber)
            {
                minNumber = secondNumber;
            }
            else if (thirdNumber <= firstNumber && thirdNumber <= secondNumber)
            {
                minNumber = thirdNumber;
            }

            return minNumber;
        }
    }
}
