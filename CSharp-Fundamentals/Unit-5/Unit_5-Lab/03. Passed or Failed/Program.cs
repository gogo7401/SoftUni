using System;

namespace _03._Passed_or_Failed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());

            if (n >= 3.0)
            {
                Console.WriteLine("Passed!");
            }
            else Console.WriteLine("Failed!");
        }
    }
}
