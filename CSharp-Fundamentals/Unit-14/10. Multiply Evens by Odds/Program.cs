using System;

namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int inputNumber = Math.Abs(int.Parse(input));

            int sumOfEvenDigits = GetSumOfEvenDigits(inputNumber.ToString());
            int sumOfOddDigits = GetSumOfOddDigits(inputNumber.ToString());
            GetMultipleOfEvenAndOdds(sumOfEvenDigits, sumOfOddDigits);

        }

        private static void GetMultipleOfEvenAndOdds(int sumOfEvenDigits, int sumOfOddDigits)
        {
            int result = 0;
            result = sumOfEvenDigits * sumOfOddDigits;
            Console.WriteLine(result);
        }

        private static int GetSumOfOddDigits(string input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 != 0)
                {
                    result += int.Parse(input[i].ToString());
                }
            }
            return result;
        }

        private static int GetSumOfEvenDigits(string input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    result +=  int.Parse(input[i].ToString());
                }
            }
            return result;
        }
    }
}
