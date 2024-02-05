using System;

namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputNumber;
            
            while ((inputNumber = Console.ReadLine()) != "END")
            {
                if (isPalindrome(inputNumber))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }

            }
        }

        private static bool isPalindrome(string inputNumber)
        {
            int middle;
            string left = "";
            string right = "";
            bool result = false;
            middle = (inputNumber.Length / 2) - 1;
            if (inputNumber.Length % 2 == 0)
            {
                for (int i = middle; i >= 0; i--)
                {
                    left += inputNumber[i];
                }
                for (int i = middle + 1; i < inputNumber.Length; i++)
                {
                    right += inputNumber[i];
                }
            }
            else
            {

                for (int i = middle; i >= 0; i--)
                {
                    left += inputNumber[i];
                }
                for (int i = middle + 2; i < inputNumber.Length; i++)
                {
                    right += inputNumber[i];
                }
            }
            if (left == right)
            {
                result = true;
            }

            return result;
        }
    }
}
