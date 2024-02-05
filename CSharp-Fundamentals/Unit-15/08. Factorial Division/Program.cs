using System;

namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            double firstNumberFactorial = GetFactorial(firstNumber);
            double secondNumberFactorial = GetFactorial(secondNumber);

            Console.WriteLine($"{firstNumberFactorial/secondNumberFactorial:f2}");
        }

        private static double GetFactorial(int number)
        {
            double factorial = 1;
            for (int i = number; i >= 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
