using System;

namespace _10._Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int currentNumber = 1; currentNumber <= n; currentNumber++)
            {
                bool sumDivisibleBy8 = GetSumDivisibleBy8(currentNumber);
                bool holdOddDigit = GetHoldOddDigit(currentNumber);

                if (sumDivisibleBy8 && holdOddDigit)
                {
                    Console.WriteLine(currentNumber);
                }
            }

        }

        private static bool GetSumDivisibleBy8(int currentNumber)
        {
            bool result = false;
            int sum = 0;
            string number = currentNumber.ToString();
            for (int i = 0; i < number.Length; i++)
            {
                sum += (int)number[i];
                
            }
            if (sum % 8 == 0)
            {
                result = true;
            }

            return result;
        }

        private static bool GetHoldOddDigit(int currentNumber)
        {
            bool result = false;
            //int sum = 0;
            string number = currentNumber.ToString();
            if (number.IndexOf('1') >= 0)
            {
                result = true;
            }
            else if (number.IndexOf('3') >= 0)
            {
                result = true;
            }
            else if (number.IndexOf('5') >= 0)
            {
                result = true;
            }
            else if (number.IndexOf('7') >= 0)
            {
                result = true;
            }
            else if (number.IndexOf('9') >= 0)
            {
                result = true;
            }

            return result;
        }
    }
}
