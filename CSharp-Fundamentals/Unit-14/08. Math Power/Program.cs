using System;

namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());

            double result = GetPower(baseNumber, powerNumber);
            Console.WriteLine(result);
        }

        private static double GetPower(double baseNumber, int powerNumber)
        {
            double result = 0;
            result = Math.Pow(baseNumber, powerNumber);

            return result;
        }
    }
}
